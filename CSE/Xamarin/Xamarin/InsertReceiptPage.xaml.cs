using Plugin.Media;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InsertReceiptPage : ContentPage
	{
		public InsertReceiptPage ()
		{
			InitializeComponent ();
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

                    //image.Source = ImageSource.FromStream(() =>
                    //{
                    //    var stream = file.GetStream();
                    //    file.Dispose();
                    //    return stream;
                    //});
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error  == "+ e.Message);
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

                //image.Source = ImageSource.FromStream(() =>
                //{
                //    var stream = file.GetStream();
                //    file.Dispose();
                //    return stream;
                //});
            };
        }
        
        async void MainToolbar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}