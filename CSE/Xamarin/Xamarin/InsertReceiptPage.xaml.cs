using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		}

        private void browseFilesButton_Clicked(object sender, EventArgs e)
        {

        }

        private void uploadImageButton_Clicked(object sender, EventArgs e)
        {

        }

        async void mainToolbar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage());
        }
    }
}