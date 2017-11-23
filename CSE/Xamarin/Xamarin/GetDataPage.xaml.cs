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
	public partial class GetDataPage : ContentPage
	{
		public GetDataPage ()
		{
			InitializeComponent ();
		}

        async void mainToolbar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage());
        }

        async private void compareProductButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CompareProductPricesPage());
        }

        async private void popularProductsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PopularProductsPage());
        }

        async private void statisticsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GraphPage());
        }
    }
}