﻿using System;
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
            Application.Run(new StartForm());
        }
    }
}