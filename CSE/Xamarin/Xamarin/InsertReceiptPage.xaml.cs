using Plugin.Media;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;

namespace Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertReceiptPage : ContentPage
    {

        string path = Models.Constants.Path;
        string key = Models.Constants.VisionKey;
        OcrResults text;
        string result;

        public InsertReceiptPage()
        {
            InitializeComponent();
            takePhoto.Clicked += async (sender, args) =>
            {
                try
                {
                    await CrossMedia.Current.Initialize();
                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await DisplayAlert("Uh oh", "No camera available. ", "OK");
                        return;
                    }

                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await DisplayAlert("Uh oh", "No camera available.", "OK");
                        return;
                    }

                    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                        Directory = "Sample",
                        Name = "test.jpg"
                    });

                    if (file == null)
                        return;
                    
                    await UseVision(file);
                    EditOcrResults(text);
                    await PutPhoto(result);
                    //Debug.WriteLine(result);

                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error  == " + e.Message);
                }
            };

            pickPhoto.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Uh oh", "Permission not granted to photos.", "OK");
                    return;
                }
                var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });
                
                if (file == null)
                    return;

                await UseVision(file);
                EditOcrResults(text);
                await PutPhoto(result);
            };
        }

        void EditOcrResults(OcrResults results)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (results != null && results.Regions != null)
            {
                stringBuilder.Append(" ");
                stringBuilder.AppendLine();
                foreach (var item in results.Regions)
                {
                    foreach (var line in item.Lines)
                    {
                        foreach (var word in line.Words)
                        {
                            stringBuilder.Append(word.Text);
                            stringBuilder.Append(" ");
                        }
                        stringBuilder.AppendLine();
                    }
                    stringBuilder.AppendLine();
                }
            }
            result = stringBuilder.ToString();
        }

        //private async Task PreparePhoto(Plugin.Media.Abstractions.MediaFile file)
        //{
        //    try
        //    {
        //        var stream = file.GetStream();
        //        var bytes = new byte[stream.Length];
        //        await stream.ReadAsync(bytes, 0, (int)stream.Length);
        //        await PutPhoto(bytes, Path.GetFileName(file.Path));
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine("Error  == " + e.Message);
        //    }
        //}

        private async Task PutPhoto(string file)
        {
            string path2 = path + "Features";
            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(file);
            var request = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(path2, request);
            Debug.WriteLine(response);
        }

        async void MainToolbar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        async Task UseVision(Plugin.Media.Abstractions.MediaFile file)
        {
            
            try
            {
                var apiRoot = "https://westcentralus.api.cognitive.microsoft.com/vision/v1.0";
                var client = new VisionServiceClient(key, apiRoot);
                using (var photoStream = file.GetStream())
                {
                    text = await client.RecognizeTextAsync(photoStream);
                }
            }
            catch(ClientException e)
            {
                Debug.WriteLine("Error  == " + e.ToString());
            }
        }
    }
}