using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

//Using Google Places & Static Maps APIs

namespace CSE.Map
{
    public partial class StoreMap : Form
    {
        public List<string> storeInfo { get; set; }
        public string StoreName { get; set; }
        public int i = 0;
        public int zoom = 13;

        public StoreMap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                ListBox.Items.Add("\n");
                ListBox.Items.Add("* - You are here");
                ListBox.Items.Add("\n");
            }

            MapClass storeMap = new MapClass();
            storeMap.GetMap(i, zoom, "Didlaukio g. 47", StoreName);

            if (i == 0)
            {
                storeInfo = storeMap.GetStoreInfo();
                foreach (string store in storeInfo)
                {
                    ListBox.Items.Add(store);
                }
            }

            MapImage.Image = new Bitmap(storeMap.ImageName);
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
