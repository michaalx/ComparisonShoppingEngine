using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void getDataClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetDataPage());
        }

        async void uploadDataClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InsertReceiptPage());
        }

        async void logOutButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogInPage());
        }
    }
}
