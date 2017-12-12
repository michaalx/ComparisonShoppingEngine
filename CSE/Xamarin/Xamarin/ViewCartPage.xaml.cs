using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
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
    public partial class ViewCartPage : ContentPage
    {
        List<string> _selected = new List<string>();
        Dictionary<decimal, string> cheapest;
        const string path = "http://192.168.0.106:5000/api/"; //use your IP - command, ipconfig

        public ViewCartPage(List<string> selected)
        {
            InitializeComponent();
            _selected = selected;
            ListView.ItemsSource = _selected;
        }

        async void ResumeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage(_selected));
        }

        async void CheapestStoreButton_Clicked(object sender, EventArgs e)
        {
            //await GetCheapest();
            await Navigation.PushAsync(new MapPage());
        }

        async Task GetCheapest()
        {
            string path2 = path;
            using (var client = new RestClient(new Uri(path2)))
            {
                var request = new RestRequest("CheapestStore", Method.GET);
                request.AddParameter("products", _selected);
                //request.AddBody(selected);
                var result = await client.Execute<Dictionary<decimal, string>>(request);
                cheapest = result.Data;
            }
        }

        async void MainToolbar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}