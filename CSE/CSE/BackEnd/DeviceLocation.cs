using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using System.Diagnostics;

namespace CSE.BackEnd
{
    class DeviceLocation
    {
        public double Lat { get; set; }
        public double Lon { get; set; }


        public DeviceLocation() { }

        public DeviceLocation(double lat, double lon)
        {
            Lat = lat;
            Lon = lon;
            Debug.WriteLine(lat + "*" + lon);
        }

        private static GeoCoordinateWatcher watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);
        public static DeviceLocation FindLocation()
        {
            if (watcher.TryStart(false, TimeSpan.FromSeconds(5)))
            {
                Debug.WriteLine(watcher.Position.Location);
                if (watcher.Position.Location.IsUnknown)
                {
                    Debug.WriteLine("Cannot find location data");
                }
                return new DeviceLocation(
                    watcher.Position.Location.Latitude,
                    watcher.Position.Location.Longitude);
            }
            return new DeviceLocation(0, 0);


        }
    }
}