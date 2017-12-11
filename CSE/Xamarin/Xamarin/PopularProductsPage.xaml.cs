using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopularProductsPage : ContentPage
    {
        string path = Models.Constants.Path;
        List<string> productList;
        List<string> selected = new List<string>();
        string item;

        public PopularProductsPage()
        {
            InitializeComponent();
            CreateList();
        }

        public async Task GetProductsData()
        {
            try
            {
                string path1 = path + "PopularProducts";

                using (var client = new RestClient(new Uri(path1)))
                {
                    var request = new RestRequest(Method.GET);
                    var result = await client.Execute<List<string>>(request);
                    productList = result.Data.Distinct().ToList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error  == " + e.Message);
            }
        }

        async void CreateList()
        {
            await GetProductsData();

            ListView.ItemsSource = productList;
        }

        async void mainToolbar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private void RemoveItemButton_Clicked(object sender, EventArgs e)
        {
            selected.Remove(item);
        }

        private void AddItemButton_Clicked(object sender, EventArgs e)
        {
            selected.Add(item);
        }

        async void ViewCartButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewCartPage(selected));
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            item = ListView.SelectedItem.ToString();
        }
    }
}