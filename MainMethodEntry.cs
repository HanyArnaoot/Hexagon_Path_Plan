﻿using System;
using System.Windows.Forms;

// INSTANT C# TASK: Some settings from the original VB Application.myapp file may not be directly convertible to C#.

namespace WindowsApp2
{
    static class MainMethodEntry
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new FrmGui());
        }
    }
}