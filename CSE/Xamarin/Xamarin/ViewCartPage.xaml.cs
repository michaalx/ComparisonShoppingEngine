using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
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
        Dictionary<string, decimal> cheapest;
        string path = Models.Constants.Path;
        string storeName;
        string storePrice;

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
            cheapest = await GetCheapest();
            foreach (var dict in cheapest)
            {
                storeName = dict.Key.ToString();
                storePrice = dict.Value.ToString("#.##");
            }

            await DisplayAlert("Cheapest store found", $"Cart price at {storeName}: {storePrice}€.", "OK");

            await Navigation.PushAsync(new MapPage(storeName));
        }

        private async Task<Dictionary<string, decimal>> GetCheapest()
        {
            var path2 = path + "Store";
            try
            {
                HttpClient client = new HttpClient();
                var json = JsonConvert.SerializeObject(_selected);
                var request = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(path2, request);
                if (!response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("ERROR:  Products Not Posted." + response.ReasonPhrase);
                    return null;
                }
                var responseJson = await response.Content.ReadAsStringAsync();
                var store = JsonConvert.DeserializeObject<Dictionary<string, decimal>>(responseJson);
                return store;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception == " + e.Message);
                return null;
            }
        }

        async void MainToolbar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}