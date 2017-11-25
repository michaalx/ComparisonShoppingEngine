using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System.Diagnostics;

namespace Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GraphPage : ContentPage
    {
        public enum Store
        {
            Maxima = 0,
            IKI = 1,
            Rimi = 2,
            Lidl = 3,
            Norfa = 4
        }

        const string path = "http://192.168.0.106:5000/api/"; //use your IP - command, ipconfig
        string item;
        string storeName;
        LineSeries line;
        List<String> productList;
        Dictionary<DateTime, decimal> listForDays;
        List<Dictionary<DateTime, decimal>> listOfLists = new List<Dictionary<DateTime, decimal>>();

        public GraphPage()
        {
            InitializeComponent();
            button.IsVisible = false;
            button.IsEnabled = false;
            List<Store> stores = Enum.GetValues(typeof(Store)).Cast<Store>().ToList();
            foreach(var store in stores)
            {
                picker.Items.Add(store.ToString());
            }

            picker.SelectedIndexChanged += async (sender, args) =>
            {
                storeName = picker.SelectedItem.ToString();
                //storeName = (Store)Enum.Parse(typeof(Store), selected);
                await GetProductsData();
                list.ItemsSource = productList;
                list.ItemSelected += async (sender2, args2) =>
                {
                    item = list.SelectedItem.ToString();
                    //picker.IsVisible = false;
                    //list.IsVisible = false;
                    button.IsVisible = true;
                    button.IsEnabled = true;
                };
            };
        }
        
        public async Task GetProductsData()
        {
            try
            {
                string path1 = path + $"graph/{storeName.ToString()}";
                
                using (var client = new RestClient(new Uri(path1)))
                {
                    var request = new RestRequest(Method.GET);
                    var result = await client.Execute<IEnumerable<String>>(request);
                    productList = result.Data.ToList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error  == " + e.Message);
            }
        }

        async void mainToolbar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        async void button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StatisticsPage(item, storeName));
        }
    }
}