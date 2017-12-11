using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;

namespace Xamarin.MapModel
{
    public class PinInfo
    {
        string latlon;
        string path;
        public List<StoreInfo> stores = new List<StoreInfo>();
        private string placesPath = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=";
        string key = Models.Constants.Key;

        public PinInfo(double lat, double lon, string StoreName)
        {
            latlon = lat.ToString().Replace(",", ".") + "," + lon.ToString().Replace(",", ".");
            Debug.WriteLine(latlon);
            path = placesPath + latlon + "&rankby=distance&keyword=" + StoreName + "_parduotuve&key=" + key;
            Debug.WriteLine(path);
        }
        public async Task FindStores()
        {
            String lat;
            String lon;
            String is_open;
            String vicinity;
            String name;
            const Int32 BufferSize = 128;

            using (var client = new HttpClient()) 
            using (Stream response = await client.GetStreamAsync(path))
            using (var reader = new StreamReader(response, Encoding.UTF8, true, BufferSize))
            {
                string line;
                line = reader.ReadLine();

                while ((line = reader.ReadLine()) != null)
                {
                    while (!(line.Contains("location")))
                    {
                        line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }
                    }

                    if (line == null)
                    {
                        break;
                    }

                    lat = reader.ReadLine();
                    lat = Regex.Replace(lat, "[^0-9.]", "");
                    lon = reader.ReadLine();
                    lon = Regex.Replace(lon, "[^0-9.]", "");

                    while (!(line.Contains("name")))
                    {
                        line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }
                    }

                    name = line;
                    name = name.Replace("         \"name\" : ", "");
                    name = Regex.Replace(name, "[0-9.:,']", "");

                    while (!(line.Contains("opening_hours")))
                    {
                        line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }
                    }

                    is_open = reader.ReadLine();
                    is_open = Regex.Replace(is_open, "[0-9.: ,']", "");
                    is_open = is_open.Replace("true", " [Open].").Replace("false", " [Closed].").Replace("open_now", "").Replace("\"", "");

                    while (!(line.Contains("vicinity")))
                    {
                        line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }
                    }
                    vicinity = line;
                    vicinity = vicinity.Replace("   ", "").Replace("  ", "").Replace("\"", "").Replace("\\", "").Replace(":", "").Replace(",", "").Replace("vicinity", "").Replace("Vilnius", "");

                    stores.Add(new StoreInfo(vicinity, is_open, lat, lon, name));
                }
            }
        }
        
        public List<StoreInfo> GetStores()
        {
            return stores;
        }
    }

    public class StoreInfo
    {
        public string Vicinity { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Is_Open { get; set; }
        public string Name { get; set; }

        public StoreInfo(string vicinity, string is_open, string lat, string lon, string name)
        {
            Vicinity = vicinity;
            Lat = double.Parse(lat, System.Globalization.CultureInfo.InvariantCulture);
            Lon = double.Parse(lon, System.Globalization.CultureInfo.InvariantCulture);
            Is_Open = is_open;
            Name = name;
        }
    }
}