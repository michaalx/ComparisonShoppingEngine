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
	public partial class CartPage : ContentPage
	{
		public CartPage ()
		{
			InitializeComponent ();
		}
        
        async void mainToolbar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private void CheapestStoreButton_Clicked(object sender, EventArgs e)
        {

        }

        private void removeItemButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}