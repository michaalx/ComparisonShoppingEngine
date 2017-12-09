using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Models
{
    public static class Constants
    {
        private const string path = "http://192.168.0.106:5000/api/"; //use your IP - command, ipconfig
        private const string key = "AIzaSyBGWA-e4F9FXwBrc1aCnq31m6LujasAchg";
        public static string Path => path;
        public static string Key => key;
    }
}
