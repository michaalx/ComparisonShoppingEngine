using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;
using System.Threading.Tasks;
using Plugin.Permissions.Abstractions;

namespace Xamarin
{
    public partial class MapPage : ContentPage
    {
        Plugin.Geolocator.Abstractions.Position savedPosition;
        Map map;
        string storeName = "maxima";

        public MapPage()
        {
            InitializeComponent();
            GetMap();
        }

        async Task GetLocation()
        {
            try
            {
                var hasPermission = await Models.PluginPermission.CheckPermissions(Permission.Location);
                if (!hasPermission)
                    return;
                
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 500;

                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

                if (position == null)
                {
                    await DisplayAlert("Uh oh", "Null GPS.", "OK");
                    return;
                }
                savedPosition = position;
            }
            catch (Exception)
            {
                await DisplayAlert("Uh oh", "Something went wrong. Try turning on your GPS.", "OK");
                await Navigation.PushAsync(new CartPage());
            }
        }

        async void GetMap()
        {
            await GetLocation();
            map = new Map(
                MapSpan.FromCenterAndRadius(
                new Position(savedPosition.Latitude, savedPosition.Longitude), Distance.FromMiles(2)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            await GetPins();
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            Content = stack;
        }

        async Task GetPins()
        {
            var stores = new MapModel.PinInfo(savedPosition.Latitude, savedPosition.Longitude, storeName);
            await stores.FindStores();
            var storeList = stores.GetStores();

            foreach(var store in storeList)
            {
                var position = new Position(store.Lat, store.Lon); 
                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = position,
                    Label = store.Name,
                    Address = store.Vicinity
                };
                map.Pins.Add(pin);
            }
        }
    }
}