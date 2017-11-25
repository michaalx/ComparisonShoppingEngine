using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        const string path = "http://192.168.0.106:5000/api/"; //use your IP - command, ipconfig
        List<Tuple<string, string, decimal>> productList;

        public PopularProductsPage ()
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
                    var result = await client.Execute<List<Tuple<string, string, decimal>>>(request);
                    productList = result.Data;
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
            var cell = new DataTemplate(typeof(TextCell));

            foreach(var item in productList)
            {

            }
            //ListView.ItemsSource = productList.Item1;
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