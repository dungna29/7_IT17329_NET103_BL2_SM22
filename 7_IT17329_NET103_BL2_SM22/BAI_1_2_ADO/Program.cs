﻿using System;
using System.Windows.Forms;

namespace BAI_1_2_ADO
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmKetNoiCSDL());
        }
    }
}