// By: Erik Hanchett
// Date:4/09/2011
// Assignment: #7
// 

// This is the main entry point
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace XMLAssignment7
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
            Application.Run(new XMLMain());
        }
    }
}
