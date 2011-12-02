using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
namespace Miami
{
    public partial class Browse : UserControl
    {
        private MainForm host;
        public Browse()
        {
            InitializeComponent();
        }
        public Browse(MainForm Host)   
        {
            InitializeComponent();
            host = Host;
        }

        private void spotifyButton1_Load(object sender, EventArgs e)
        {
         


        }
        private void GF(object sender, EventArgs e)
        {
            Spofity.Element Sender = (Spofity.Element)((Control)sender).Tag;
            this.host.OpenSpotifyLink(host.GetURIFromPage(new Uri(Sender.GetAttribute("href"))));
        }
        bool progressing = false;
        private void spotifyButton1_ChangeUICues(object sender, UICuesEventArgs e)
        {
            
        }

        void X_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            
        }

        private void Browse_Load(object sender, EventArgs e)
        {
        
        }

        private void spotifyButton1_Click(object sender, EventArgs e)
        {
            host.AddFeed("Emotionalizer", "sp:entry", "http://www.totalspotify.com/rsssearch.php?search=" + comboBox1.Text + "&tag=true", 10, new Point(10, 60), "sresult", new EventHandler(GF));

        }
    }
}
