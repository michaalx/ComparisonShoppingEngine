using Plugin.Media;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertReceiptPage : ContentPage
    {

        string strFile = ""; 
        const string path = "http://172.26.193.238:5000/api/"; //use your IP - command, ipconfig

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
                        await DisplayAlert("Uh oh", "No camera avaialble.", "OK");
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

                    await DisplayAlert("File Location", file.Path, "OK");

                    //await PreparePhoto(file);
                    //await PutPhoto();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error  == " + e.Message);
                }
            };

            async Task PreparePhoto(Plugin.Media.Abstractions.MediaFile file)
            {
                try
                {
                    var stream = file.GetStream();
                    var bytes = new byte[stream.Length];
                    await stream.ReadAsync(bytes, 0, (int)stream.Length);
                    strFile = Convert.ToBase64String(bytes);
                    await PutPhoto();
                }
                catch(Exception e)
                {
                    Debug.WriteLine("Error  == " + e.Message);
                }
            }

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

                await PreparePhoto(file);
            };
        }

        public async Task PutPhoto()
        {
            using (var client = new RestClient(new Uri(path)))
            {
                var request = new RestRequest("Receipt/" + strFile, Method.GET);
                await client.Execute<string>(request);
            }
        }
        
        async void MainToolbar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
//file.Dispose();

//image.Source = ImageSource.FromStream(() =>
//{
//    var stream = file.GetStream();
//    file.Dispose();
//    return stream;
//});
//using (var image.Source = ImageSource.FromFile(file.Path))
//{
//    using (MemoryStream m = new MemoryStream())
//    {
//        image.Save(m, image.RawFormat);
//        byte[] imageBytes = m.ToArray();
//        // Convert byte[] to Base64 String
//        string base64String = Convert.ToBase64String(imageBytes);
//        return base64String;
//    }
//}

//image.Source = ImageSource.FromStream(() =>
//{
//    var stream = file.GetStream();
//    file.Dispose();
//    return stream;
//});

//public string ImageToString(string path)

//{

//    if (path == null)
//        throw new ArgumentNullException("path");

//    //Image im = Image.FromFile(path);
//    //MemoryStream ms = new MemoryStream();
//    //im.Save(ms, im.RawFormat);
//    //byte[] array = ms.ToArray();
//    //return Convert.ToBase64String(array);
//}