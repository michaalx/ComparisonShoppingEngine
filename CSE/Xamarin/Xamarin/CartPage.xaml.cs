using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Net.Http;

namespace Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {

        const string path = "http://192.168.8.108:5000/api/";
        List<string> list;
        List<string> selected = new List<string>();
        string item;

        public CartPage()
        {
            InitializeComponent();
            GetData();
        }

        public async Task GetAPIData()
        {
            try
            {
                string path1 = path + "Store";
                using (var client = new RestClient(new Uri(path1)))
                {
                    var request = new RestRequest(Method.GET);
                    var result = await client.Execute<IEnumerable<string>>(request);
                    list = result.Data.ToList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error  == " + e.Message);
            }
        }

        private async Task<Dictionary<string,decimal>> GetCheapest()
        {
            var path2 = path + "Store";
            try
            {
                HttpClient client = new HttpClient();
                var json = JsonConvert.SerializeObject(selected);
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

        public async void GetData()
        {
            await GetAPIData();
            ListView.ItemsSource = list;
        }

        async void MainToolbar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        async void CheapestStoreButton_Clicked(object sender, EventArgs e)
        {
            await GetCheapest();
        }

        private void RemoveItemButton_Clicked(object sender, EventArgs e)
        {
            selected.Remove(item);
        }

        private void AddItemButton_Clicked(object sender, EventArgs e)
        {
            selected.Add(item);
        }

        private void ListViewSelected(object sender, EventArgs e)
        {
            item = ListView.SelectedItem.ToString();
        }
    }
}