using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

//Using Google Maps Geocoding API

namespace CSE.Map
{
    public class DeviceLocation
    {

        public double Lat { get; set; }
        public double Lon { get; set; }
        public static List<DeviceLocation> Locations { get; set; }
        const string GGeoCodeJsonServiceUrl = "https://maps.googleapis.com/maps/api/geocode/json?address={0}&key={1}";
        public string Key { get; set; }
        public Result Stat { get; set; }

        public enum Result
        {
            OK,
            ZERO_RESULTS,
            OVER_QUERY_LIMIT,
            REQUEST_DENIED,
            INVALID_REQUEST,
            UNKNOWN_ERROR

        }
        
        public DeviceLocation(string address)
        {
            Key = "AIzaSyBGWA-e4F9FXwBrc1aCnq31m6LujasAchg";
            try
            {
                GeoCodeInfo(address);
            }

            catch (MissingFieldException e)
            {
                throw new MissingFieldException("Wrong Address.");
            }
        }

        public Location GeoCodeInfo(string address)
        {

            if (string.IsNullOrEmpty(Key))
            {
                throw new MissingFieldException("Your Google API Key is missing");
            }

            if (string.IsNullOrEmpty(address))
            {
                throw new MissingFieldException("Wrong Address.");
            }

            using (var client = new WebClient())
            {
                string formatAddress = string.Format(GGeoCodeJsonServiceUrl, address, Key);
                var result = client.DownloadString(formatAddress);
                var O = JsonConvert.DeserializeObject<GeoJsonResult>(result);

                if (Stat == Result.OK)
                {
                    Lat = O.results[0].geometry.Location.lat;
                    Lon = O.results[0].geometry.Location.lng;
                }
                return O.results[0].geometry.Location;
            }
        }

        private void SetGeoResultFlag(string status)
        {
            switch (status)
            {
                case "OK":
                    Stat = Result.OK;
                    break;
                case "ZERO_RESULTS":
                    Stat = Result.ZERO_RESULTS;
                    break;
                case "OVER_QUERY_LIMIT":
                    Stat = Result.OVER_QUERY_LIMIT;
                    break;
                case "REQUEST_DENIED":
                    Stat = Result.REQUEST_DENIED;
                    break;
                case "INVALID_REQUEST":
                    Stat = Result.INVALID_REQUEST;
                    break;
                case "UNKNOWN_ERROR":
                    Stat = Result.UNKNOWN_ERROR;
                    break;
            }
        }
    }
}


