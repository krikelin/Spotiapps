using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using Skybound.Gecko;
using System.Text;
using System.Windows.Forms;

namespace SpotiBrowsser
{
    public class Nonsense
    {
    }
    public partial class Browser : UserControl
    {
        private string  uri;
        public Browser()
        {
          

            InitializeComponent();
        }
        
        public Browser(string Uri)
        {
            uri = Uri;
        
            InitializeComponent();
            this.webBrowser1.Navigated += new GeckoNavigatedEventHandler(webBrowser1_Navigated);
            this.webBrowser1.Navigating += new GeckoNavigatingEventHandler(webBrowser1_Navigating);
            this.webBrowser1.DocumentCompleted += new EventHandler(webBrowser1_DocumentCompleted);
        }

        void webBrowser1_DocumentCompleted(object sender, EventArgs e)
        {
      
         
        }

        void webBrowser1_Navigating(object sender, GeckoNavigatingEventArgs e)
        {
          
        }

        void webBrowser1_Navigated(object sender, GeckoNavigatedEventArgs e)
        {
      /*      GeckoElementCollection C = webBrowser1.Document.GetElementsByTagName("a");
            foreach (GeckoElement Elm in C)
            {
                if (Elm.GetAttribute("href").StartsWith("spotify:"))
                {
                    Elm.SetAttribute("href", Elm.GetAttribute("href").Replace("spotify:", "http://open.spotify.com/").re);
                }
            }*/
                
        }
        public void BrowserLoad()
        {
           
                
        }

        private void Browser_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(uri);
           
        }
        
    }
}
