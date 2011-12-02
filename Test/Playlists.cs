using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using Spofity;
namespace SpotiApp
{
    public partial class Playlists : UserControl
    {
        public MainForm host;

        void AddFeed(String Section, string URI, int limit, Point Location, string nspace)
        {
            try
            {
                XmlDocument DR = new XmlDocument();
                DR.Load(URI);

                int i = 0;

                foreach (XmlElement D in DR.GetElementsByTagName("item"))
                {
                    if (i == limit)
                    {
                        break;
                    }
                    string name = D.GetElementsByTagName("title")[0].InnerText;
                    string description = "";
                    try
                    {
                        description = D.GetElementsByTagName("description")[0].InnerText;
                    }
                    catch
                    {
                    }
                    string url = D.GetElementsByTagName("link")[0].InnerText;

                    Spofity.Element Name = new Spofity.Element();
                    Name.Type = "sp:entry";
                    Name.Attributes.Add(new Spofity.Attribute() { name = "x", value = Location.X.ToString() });
                    Name.Attributes.Add(new Spofity.Attribute() { name = "y", value = (Location.Y + i * 20).ToString() });
                    Name.Attributes.Add(new Spofity.Attribute() { name = "title", value = name });
                    Name.Attributes.Add(new Spofity.Attribute() { name = "href", value = url });
                    Name.Attributes.Add(new Spofity.Attribute() { name = "artist", value = "Playlist" });
                    Name.Feed = nspace;
                    Name.OnClick += new EventHandler(Name_OnClick);
                    Name.Attributes.Add(new Spofity.Attribute() { name = "section", value = Section });
                    Name.Attributes.Add(new Spofity.Attribute() { name = "size", value = "10" });
                    Name.Attributes.Add(new Spofity.Attribute() { name = "name", value = "playlist-" + name });
                    Name.Attributes.Add(new Spofity.Attribute() { name = "even", value = (i % 2 == 0).ToString() });
                    host.NewElements.Push(Name);
                    i++;
                }
            }
            catch
            {
            }

        }
        void Name_OnClick(object Sender,EventArgs e)
        {

           
        }
        public void SearchPlaylists(object param)
        {
            AddFeed("Playlists", "http://feeds.feedburner.com/" + (string)param + "SpotifyPlaylists?format=xml", 100, new Point(3, 230), "SearchResult");

        }
        public Playlists()
        {
            InitializeComponent();
         
        }
        public Playlists(MainForm Host)
        {
            InitializeComponent();
            host = Host;
        }

        private void spotifyButton1_Load(object sender, EventArgs e)
        {

        }

        private void Playlists_Load(object sender, EventArgs e)
        {

        }

        private void spotifyButton1_Click(object sender, EventArgs e)
        {
            Thread D = new Thread(SearchPlaylists);
            D.Start((string)textBox1.Text);
        }
    }
}
