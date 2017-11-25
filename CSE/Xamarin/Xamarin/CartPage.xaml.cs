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

namespace Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {

        const string path = "http://192.168.0.106:5000/api/";
        List<string> list;
        List<string> selected = new List<string>();
        string item;
        //IEnumerable<string> selectedEn;

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
                    var result = await client.Execute<IEnumerable<String>>(request);
                    list = result.Data.ToList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error  == " + e.Message);
            }
        }

        async Task GetCheapest()
        {
            string path2 = path;
            using (var client = new RestClient(new Uri(path2)))
            {
                var request = new RestRequest("CheapestStore", Method.GET);
                request.AddParameter("products", selected);
                //request.Parameters.Add("products", selected);
                var result = await client.Execute<IEnumerable<String>>(request);
                list = result.Data.ToList();
            }
        }

        public async void GetData()
        {
            await GetAPIData();
            ListView.ItemsSource = list;
        }

        //public IEnumerable<string> GetEn()
        //{
        //    return selected;
        //}

        async void MainToolbar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        async void CheapestStoreButton_Clicked(object sender, EventArgs e)
        {
            //selectedEn = GetEn();
            await GetCheapest();
            //await Navigation.PushAsync(new MapPage());
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