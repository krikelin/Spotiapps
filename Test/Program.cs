using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Xml;
namespace SpotiApp
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
          
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);


            MainForm D = new MainForm();
            D.FormBorderStyle = FormBorderStyle.Sizable;

            Application.Run(D);


        }
    }
}
