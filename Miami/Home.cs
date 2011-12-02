using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using Spofity;
namespace Miami
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            
        }

        private void Home_Load(object sender, EventArgs e)
        {
            WebClient D = new WebClient();
            D.DownloadStringCompleted += new DownloadStringCompletedEventHandler(D_DownloadStringCompleted);
            D.DownloadStringAsync(new Uri("http://www.xpandify.com/rss.php"));
            
           
        }

        void D_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            
        }

        private void ucSection1_Load(object sender, EventArgs e)
        {

        }

        private void spotifySmallLabel1_Load(object sender, EventArgs e)
        {

        }

        private void pane1_Load(object sender, EventArgs e)
        {

        }
    }
}
