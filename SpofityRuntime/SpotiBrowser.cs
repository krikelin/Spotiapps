using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spofity;
namespace SpotiBrowsser
{
    public class Nonsens
    {
    }
    public class MainForm : Form1
    {
        private string site;
        public MainForm(string Site)
        {
            site = Site;
        }
        Browser CM;
        protected override void OnLoad(EventArgs e)
        {
            CM = new Browser(Site);
            AddSection("Browse", CM);
            SetActiveSection("Browser");
        }
      

    }
}
