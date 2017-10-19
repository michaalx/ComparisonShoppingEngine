using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;

//Using Google Places & Static Maps APIs

namespace CSE.Map
{
    public partial class StoreMap : Form
    {
        private char rank = 'A';
        private int i = 0;
        private int zoom = 12;
        private static string Address { get; set; }
        private DeviceLocation location; 
        double lat;
        double lon;
        string latlng;
        string path;
        public string StoreName { get; set; }
        string Key = "AIzaSyBGWA-e4F9FXwBrc1aCnq31m6LujasAchg";

        public class StoreInfo
        {
            public string Vicinity { get; set; }
            public string Coordinates { get; set; }

            public StoreInfo(string vicinity, string coordinates)
            {
                Vicinity = vicinity;
                Coordinates = coordinates;
            }
        }

        public List<StoreInfo> stores = new List<StoreInfo>();

        public StoreMap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                Address = "Didlaukio g. 47";
                location = new DeviceLocation(Address);
                lat = location.Lat;
                lon = location.Lon;
                StoreName = "IKI";
                latlng = lat.ToString().Replace(",", ".") + "," + lon.ToString().Replace(",", ".");

                ListBox.Items.Add("\n");
                ListBox.Items.Add("* - You are here");
                ListBox.Items.Add("\n");

                path = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + latlng + "&rankby=distance&keyword=" + StoreName + "_parduotuve&key=" + Key;
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFile(path, "map.txt");
                }
                FindStores();
            }

            path = "https://maps.googleapis.com/maps/api/staticmap?center=" + latlng + "&zoom=" + zoom + "&size=500x500&markers=color:red%7Clabel:*%7C" + latlng;
             foreach (StoreInfo store in stores)
             {
                 path += "&markers=color:blue%7Clabel:" + rank + "%7C" + store.Coordinates;
                 if (i == 0)
                     ListBox.Items.Add(rank.ToString() + " - " + StoreName + store.Vicinity);
                 rank++;
             }
            
            path += "&key=" + Key;
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile(path, "map" + i.ToString() + ".png");
                MapImage.Image = new Bitmap("map" + i.ToString() + ".png");
                i++;
            }
        }

        public void FindStores()
        {
            String lat;
            String lon;
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

                    while (!(line.Contains("vicinity")))
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

                    line = line.Replace("   ", "").Replace("  ", "").Replace("\"", "").Replace("\\", "").Replace(":", "").Replace(",", "").Replace("vicinity", "");
                    stores.Add(new StoreInfo(line, lat + "," + lon));
                }
            }
        }

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            if (zoom < 20)
            {
                zoom++;
                i++;
                button1_Click(null, null);
            }
            else return;
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            if (zoom != 0)
            {
                zoom--;
                i++;
                button1_Click(null, null);
            }
            else return;
        }

        private void StoreMap_Shown(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }
    }
}
