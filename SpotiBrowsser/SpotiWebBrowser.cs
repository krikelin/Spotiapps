using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace SpotiBrowsser
{
    class SpotiWebBrowser : WebBrowser
    {
       
        protected override void OnNavigated(WebBrowserNavigatedEventArgs e)
        {
            base.OnNavigated(e);
            this.Document.BackColor = Color.FromArgb(55, 55, 55);
            this.Document.ForeColor = Color.FromArgb(100, 100, 100);
           
        }
        protected override void OnNavigating(WebBrowserNavigatingEventArgs e)
        {
            base.OnNavigating(e);
            if (e.Url.ToString().StartsWith("spotify:") || e.Url.ToString().StartsWith("http://open.spotify.com"))
            {

            }

        }
       
    }
}
