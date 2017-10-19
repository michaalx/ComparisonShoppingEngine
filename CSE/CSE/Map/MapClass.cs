using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;

namespace CSE.Map
{
    public class MapClass
    {
        private char rank = 'A';
        private static string Address { get; set; }
        private DeviceLocation location;
        double lat;
        double lon;
        string latlng;
        string path;
        public string StoreName { get; set; }
        string key = "AIzaSyBGWA-e4F9FXwBrc1aCnq31m6LujasAchg";
        public List<StoreInfo> stores = new List<StoreInfo>();
        public List<String> storeInfo = new List<String>();
        public string ImageName { get; set; }
        private string staticMapPath = "https://maps.googleapis.com/maps/api/staticmap?center=";
        private string placesPath = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=";

        public string Key
        {
            get { return key; }
            private set { key = value; }
        }
        public string StaticMapPath
         {
            get { return staticMapPath; }
            private set { staticMapPath = value; }
        }
        public string PlacesPath
        {
            get { return placesPath; } 
            private set { placesPath = value; }
        }
        
        public void GetMap(int i, int zoom)
        {
            Address = "Naugarduko g. 24";
            location = new DeviceLocation(Address);
            lat = location.Lat;
            lon = location.Lon;
            StoreName = "IKI";
            latlng = lat.ToString().Replace(",", ".") + "," + lon.ToString().Replace(",", ".");

            path =  PlacesPath + latlng + "&rankby=distance&keyword=" + StoreName + "_parduotuve&key=" + Key;
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile(path, "map.txt");
            }
            FindStores();
          

            path = StaticMapPath + latlng + "&zoom=" + zoom + "&size=500x500&markers=color:red%7Clabel:*%7C" + latlng;
            
            foreach (StoreInfo store in stores)
            {
                path += "&markers=color:blue%7Clabel:" + rank + "%7C" + store.Coordinates;
                rank++;
            }

            path += "&key=" + Key;
            using (WebClient wc = new WebClient())
            {
                ImageName = "map" + i.ToString() + ".png";
                wc.DownloadFile(path, ImageName);
            }
        }
        
        public void FindStores()
        {
            String lat;
            String lon;
            String is_open;
            String vicinity;
            const Int32 BufferSize = 128;

            using (var fileStream = File.OpenRead("map.txt"))
            using (var reader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
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
                    is_open = is_open.Replace("true", " [Open].").Replace("false", " [Closed].").Replace("open_now","").Replace("\"","");

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

                    stores.Add(new StoreInfo(vicinity, is_open, lat + "," + lon));
                }
            }
        }

        public List<string> GetStoreInfo()
        {
            List<String> storeInfo = new List<string>();
            rank = 'A';
            foreach (StoreInfo store in stores)
            {
                storeInfo.Add(rank.ToString() + " - " + StoreName + store.Vicinity + store.Is_Open);
                rank++;
            }
            return storeInfo;
        }

        public class StoreInfo
        {
            public string Vicinity { get; set; }
            public string Coordinates { get; set; }
            public string Is_Open { get; set; }

            public StoreInfo(string vicinity, string is_open, string coordinates)
            {
                Vicinity = vicinity;
                Coordinates = coordinates;
                Is_Open = is_open;
            }
        }
    }
}
