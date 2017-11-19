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
	public partial class CompareProductPricesPage : ContentPage
	{
		public CompareProductPricesPage ()
		{
			InitializeComponent ();
		}
        
        async void Main_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage());
        }

        private void AddToCartButton_Clicked(object sender, EventArgs e)
        {

        }

        async void ShowCartButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage());
        }
    }
}