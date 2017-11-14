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
	public partial class PopularProductsPage : ContentPage
	{
		public PopularProductsPage ()
		{
			InitializeComponent ();
		}

        async void mainToolbar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private void addToCartButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}