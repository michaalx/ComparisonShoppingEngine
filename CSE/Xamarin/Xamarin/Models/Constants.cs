using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Models
{
    public static class Constants
    {
        private const string path = "http://172.24.2.123:5000/api/"; //use your IP - command, ipconfig
        private const string key = "AIzaSyDdO_LjtwvIUnXLdMYlxJkleWtwIRcI4ZE";
        private const string visionKey = "dbb60373460c424588e90266525f1b0c";
        public static string Path => path;
        public static string Key => key;
        public static string VisionKey => visionKey;
    }
}
