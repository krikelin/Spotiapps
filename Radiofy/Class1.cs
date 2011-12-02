using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.IO;
using System.Drawing.Design;
using System.Threading;
using System.Xml;
using System.Reflection;
using Spofity;
namespace SpotiApp
{
    public class DS
    {
    }
    public class MainForm : Form1
    {


        Radiofy.Form2 DS;
        string feed = "http://www.xpandify.com/rss.php";
        protected override void OnLoad(EventArgs e)
        {
            DS = new Radiofy.Form2();
            base.OnLoad(e);

       
            AddSection("Radiofy",DS);
            DS.host = this;

            AddSection("Home", D);
            SetActiveSection("Home");
            /*    mainPanel.Dock = DockStyle.Fill;
                playLists.Dock = DockStyle.Fill;*/
            //   C = AddSection("Submit Playlist");

            //  AddSection("Playlists");

            //    AddSection("Home");
            /* AddText(B,"New Playlists (Xpandify)", 10, Color.FromArgb(120, 170, 120), new Point(42, 230));
          
             AddSection(A, "Playlist Browser", new Rectangle(0, 52,this.Width,32));
             String[] Genres = Properties.Resources.genres.Split('\n');
             int i=0;
             ComboBox D = new ComboBox();
             D.DropDownStyle = ComboBoxStyle.DropDownList;
             foreach (String Genre in Genres)
             {
                 D.Items.Add(Genre);   
             }
             D.SelectedValueChanged += new EventHandler(D_SelectedValueChanged);
             D.Bounds = new Rectangle(2, 2, 120, 32);
             A.Controls.Add(D);
             AddSection(B, "Home", new Rectangle(2, 140, this.ContentPanel.Width, 32));
             Image Df = Properties.Resources.logo;
             AddImage(B, Df, new Rectangle(2, 2, Df.Width, Df.Height));
            /* spotifyButton DN = new spotifyButton();;
             DN.Left = 320;
             DN.Top = 10;
             DN.Width = 70;
             DN.Click += new EventHandler(DN_Click);
             DN.Label = "Update";
             B.Controls.Add(DN);*/
            // AddButton(B, "Update", new Rectangle(Df.Width, 2, 82, 50), DN_Click);
            // SetActiveSection("Home");
            // Fetch latest playlis from xpandify  (http://www.xpandify.com/rss.php)
            //    UpdateFeed();
            /*
                        TextBox Name = AddTextBox(C, "Name", new Rectangle(124, 214, 320, 32));
                        TextBox URI = AddTextBox(C, "URI", new Rectangle(124, 176, 320, 32));
                        TextBox Desc = AddTextBox(C, "Description", new Rectangle(124, 306, 320, 32));
                        Desc.Multiline = true;
                        spotifyButton BtnSubmit = AddButton(C, "Submit", new Rectangle(4, 420, 120, 32),new EventHandler(Submit));Ä*/
        }
        void Submit(object sender, EventArgs e)
        {

        }

        void SSubmit()
        {
        }

        void D_SelectedValueChanged(object sender, EventArgs e)
        {
            this.ClearFeed("GPL");
            ComboBox D = (ComboBox)sender;
            string Genre = (string)D.SelectedText;
            Thread N = new Thread(Open);
            N.Start((object)Genre.Replace("\r", ""));
        }
        void GClick(object sender, EventArgs e)
        {
            this.ClearFeed("GPL");
            spotifyButton D = (spotifyButton)sender;
            string Genre = (string)D.Tag;
            Thread N = new Thread(Open);
            N.Start((object)Genre.Replace("\r", ""));
        }
        void Open(object Params)
        {

            AddFeed("Playlists", "sp:entry", "http://feeds.feedburner.com/" + (string)Params + "SpotifyPlaylists?format=xml", 20, new Point(325, 120), "GPL", new EventHandler(GClick));
        }
        void DN_Click(object sender, EventArgs e)
        {
            UpdateFeed();
        }
        void UpdateFeed()
        {
            this.ClearFeed(feed);
            Thread D = new Thread(GetPage);
            D.Start();
        }
        void GetPage()
        {



            AddFeed("Home", "sp:entry", "http://www.xpandify.com/rss.php", 5, new Point(42, 270), feed, new EventHandler(GClick));

            //     AddFeed("Home", "http://www.spotify.com/se/blog/rss", 5, new Point(342, 270), feed);

        }


        void Name_OnClick(object sender, EventArgs e)
        {
            Element Sender = (Element)((Control)sender).Tag;
            this.OpenSpotifyLink(GetURIFromPage(new Uri(Sender.GetAttribute("href"))));
        }
    }
}
