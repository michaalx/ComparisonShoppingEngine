using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSE.FrontEnd;

namespace CSE
{
    static class Program
    {
        //hello
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new regFrm());
            Application.Run(new StartForm());

        }
    }
}

/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSE.FrontEnd;
using System.Device.Location;
using CSE.BackEnd;

namespace CSE
{
    static class Program
    {
        //hello
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new regFrm());
            DeviceLocation loc = new DeviceLocation();
            loc = DeviceLocation.FindLocation();
            Application.Run(new StartForm());
        }
    }
}
*/