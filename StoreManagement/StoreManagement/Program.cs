﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using StoreManagement.UI;

namespace StoreManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MDIParent());
            //Application.Run(new MDIParent1());
            //Application.Run(new GRREntryUI());
            Application.Run(new LoginUI());
            //Application.Run(new FSDInspectionSummeryEntryUI());
        }
    }
}
