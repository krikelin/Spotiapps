/**
 * (C) 2010 Alexander Forselius. released  under the GNU Publical License
 * */
using System;
using System.Xml.Serialization;
using System.Threading;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Xml;

namespace Spofity
{

    /// <summary>
    /// A GUI extension for Spotify must always inherit from this class. 
    /// </summary>
    public partial  class Form1 : Form
    {
       
       
        #region HelperClasses
        /// <summary>
        /// Adds a textbox in the view
        /// </summary>
        /// <param name="B">The pane to add to</param>
        /// <param name="Text">Text content</param>
        /// <param name="Bounds">The control bounds</param>
        /// <returns>TextBox</returns>
        public TextBox AddTextBox(UserControl B, string Text, Rectangle Bounds)
        {
            Label RDescription = new Label();
            TextBox D = new TextBox();

            D.Bounds = Bounds;
            RDescription.Text = Text;
            RDescription.Bounds = Bounds;
            RDescription.Top -= D.Height;
            B.Controls.Add(D);
            B.Controls.Add(RDescription);
            return D;
        }
        /// <summary>
        /// Add a label to the view and return the new label as a Label object
        /// </summary>
        /// <param name="B">The target pane</param>
        /// <param name="text">the text of the pane</param>
        /// <param name="size">the size of the text</param>
        /// <param name="Colour">The colour</param>
        /// <param name="Location">The location of the text</param>
        /// <returns>Label</returns>
        public Label AddText(UserControl B, string text, int size, Color Colour, Point Location)
        {
            Label Caption = new Label();
            Caption.Text = text;
            Caption.AutoSize = true;
            Caption.Location = Location;
            Caption.ForeColor = Colour;
            Caption.Font = new Font("MS Sans Serif", size);

            B.Controls.Add(Caption);
            return Caption;
        }
        /// <summary>
        /// Adds a section to the Spotify View, for viewing and managing content, like those on the artist view
        /// </summary>
        /// <param name="B">The UserControl of the current view page</param>
        /// <param name="text">The etxt</param>
        /// <param name="Location">a Point for the target location</param>
        /// <returns>the Section </returns>
        public ucSection AddSection(Control B, string text, Rectangle Location)
        {
            ucSection Section = new ucSection();
            Section.Title = text;
            Section.Bounds = Location;
            B.Controls.Add(Section);
            Section.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            return Section;
        }
        /// <summary>
        /// Adds a cover image, for usage with a playlist or a album, like those in the artist view.
        /// </summary>
        /// <param name="B">UserControl of the target view</param>
        /// <param name="Source">The URL/Path to the image file</param>
        /// <param name="Location">The Point of the target Location</param>
        /// <returns>Cover</returns>
        public spotiImage AddImage(UserControl B, Image Source, Rectangle Location)
        {

            spotiImage Section = new  spotiImage();
            Section.Bounds = Location;

            Section.Picture = Source;

            B.Controls.Add(Section);
            return Section;
        }
        /// <summary>
        /// Adds a Button that shares a Spotify theme
        /// </summary>
        /// <param name="B">The UserControl of the target view</param>
        /// <param name="Text">The text of the button</param>
        /// <param name="Bounds">The Rectangle bounds</param>
        /// <param name="Click">A reference to a EventHandler handling the click on the button</param>
        /// <returns>Returns the new button</returns>
        public spotifyButton AddButton(UserControl B, string Text, Rectangle Bounds, EventHandler Click)
        {
            spotifyButton Button = new spotifyButton();
            Button.Label = Text;
            Button.Bounds = Bounds;
            Button.Click += new EventHandler(Click);
            B.Controls.Add(Button);
            return Button;
        }
        #endregion
        public class Form
        {
            private List<Control> fields;
            public List<Control> Fields
            {
                get
                {
                    return fields;
                }
                set
                {
                    fields = value;
                }
            }
        }
        private string nspace;
        public class Elm
        {
            private int type;
            private string Token;
        }
        private Stack<Element> newElements;
        /// <summary>
        /// Set the current view view (Depredicted)
        /// </summary>
        /// <remarks>Depredicted</remarks>
        /// <param name="view"></param>
        public void SetView(pane view)
        {
            view.Active = true;
            foreach (Control X in elements.Values)
            {
                if (((Element)X.Tag).GetAttribute("section") == view.Label)
                {
                    X.Show();
                }
                else
                {
                    X.Hide();
                }
            }
        }

        private Dictionary<string, Control> elements;
        public string Artist
        {
            get
            {
                return artist;
            }
            set
            {
                artist = value;
                LoadLibrary(URI, artist);
            }
        }
        /// <summary>
        /// Returns a list of playlist entries in the current view
        /// </summary>
        public List<spotiEntry> Entries
        {
            get
            {
                List<spotiEntry> entries = new List<spotiEntry>();
                foreach (Control entry in ActiveUserControl.Controls)
                {
                    if (entry.GetType() == typeof(spotiEntry))
                    {
                        entries.Add((spotiEntry)entry);
                    }
                }
                return entries;
            }
        }
        public List<pane> panes
        {
            get
            {
                List<pane> panex = new List<pane>();
                foreach (Control X in panes)
                {
                    if (X.GetType() == typeof(pane))
                    {
                        panex.Add((pane)X);
                   } 
                }
                return panex;
            }
        }
        public virtual string GetURL()
        {
            return "NULL";
        }
        int oldSelectedIndex = 0;
        int selectedIndex = 0;
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
            }
        }
        public int OldSelectedIndex
        {
            get
            {
                return oldSelectedIndex;
            }
            set
            {
                oldSelectedIndex = value;
            }
        }
        private string playlistURI;
        public string PlaylistURI
        {
            get
            {
                return playlistURI;
            }
            set
            {
                playlistURI = value;
            }
        }
        /// <summary>
        /// Returns the UserControl for the current selected view
        /// </summary>
        public UserControl ActiveUserControl
        {
            get
            {
                foreach (Control d in panel1.Controls)
                {
                    if (d.GetType() == typeof(pane))
                    {
                        if (((pane)d).Active)
                        {
                            return ((pane)d).Sect;
                        }
                    }
                }
                return null;
            }
        }
        public List<spotiEntry> selectedItems
        {
            get
            {
                List<spotiEntry> entries = new List<spotiEntry>();
                foreach (Control i in this.ContentPanel.Controls)
                {
                    if (i.GetType() == typeof(spotiEntry))
                    {
                        if (((spotiEntry)i).Selected)
                            Entries.Add((spotiEntry)i);
                    }
                }
                return entries;
            }
        }
        public void AddSection(string name)
        {
            pane D = new pane();
            D.Click += new EventHandler(D_Click);
        }
        /// <summary>
        /// This function will open the target URL in the Spotify, and automatically hide the spotiApp view
        /// until the user returns to the associated playlist.
        /// </summary>
        /// <param name="URI">The Spotify URI</param>
        public void OpenSpotifyLink(string URI)
        {
            Process.Start(@"C:\Program Files\Spotify\spotify.exe", "/uri " + URI);
        }
        void D_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        public Panel ContentPanel
        {
            get
            {
                return contentPanel;
            }
        }
        public string GetFolder(string URI)
        {
            string[] fr = URI.Split('\\');
            string d = "";
            for (var i = 0; i < fr.Length - 1; i++)
            {
                d += fr[i] + "\\";
            }
            return d;
        }
        string folder;
        string artist;
        public bool hasContent = false;
        public void LoadLibrary(string URI, string Filter)
        {
            top = 0;

            folder = URI;
            if (Filter == "")
            {
                DirectoryInfo R = new DirectoryInfo(URI);
                Filter = R.GetFiles("*.artist")[0].Name.Replace(".artist", "");
                this.comboBox1.Items.Clear();
                foreach (FileInfo Art in R.GetFiles("*.artist"))
                {
                    this.comboBox1.Items.Add((string)Art.Name.Replace(".artist", ""));
                }
            }
            artist = Filter.Replace(".artist", "");
            this.ContentPanel.Controls.Clear();
            top += 10;
            if (URI.EndsWith(".album"))
            {
                folder = GetFolder(URI);
                AddAlbum(URI);
            }
            else
            {

                AddReleaseSection("Top Hit", artist);
                AddReleaseSection("Album", artist);
                AddReleaseSection("Single", artist);
            }

        }
        public void AddReleaseSection(string name, string Filter)
        {
            DirectoryInfo DI = new DirectoryInfo(folder);
            DirectoryInfo DI2 = new DirectoryInfo(folder + "\\Release");
            if (DI2.GetFiles("*." + name.ToLower()).Length > 0)
            {
         //       AddSection(name + "s");
            }
            var c = DI2.GetFiles("*." + name.ToLower());
            var i = 0;
            for (int x = 0; x < c.Length; x++)
            {

                AddAlbum(c[x].FullName);

            }
        }
        private Bitmap _backBuffer;
        /// <summary>
        /// Clears the content tagget with the feed string from the view.
        /// </summary>
        /// <param name="feed">The feed tag value</param>
        public void ClearFeed(string feed)
        {
            foreach (UserControl a in sects.Values)
            {
                Stack<Control> removeControls = new Stack<Control>();

                foreach (Control b in a.Controls)
                {
                    if (b.Tag != null)
                    {
                        try
                        {
                            if (((Element)b.Tag).Feed == feed)
                            {
                                removeControls.Push(b);
                            }
                        }
                        catch
                        {
                        }
                    }

                }
                while (removeControls.Count > 0)
                {
                    Control X = removeControls.Pop();
                    a.Controls.Remove(X);
                    elements.Remove(((Element)X.Tag).GetAttribute("name"));

                }
            }

        }


        protected override void OnPaint(PaintEventArgs e)
        {

            if (_backBuffer == null)
            {

                _backBuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);

            }

            Graphics g = Graphics.FromImage(_backBuffer);



            //Paint your graphics on g here



            g.Dispose();



            //Copy the back buffer to the screen



            e.Graphics.DrawImageUnscaled(_backBuffer, 0, 0);



            //base.OnPaint (e); //optional but not recommended

        }



        protected override void OnPaintBackground(PaintEventArgs pevent)
        {

            //Don't allow the background to paint

        }



        protected override void OnSizeChanged(EventArgs e)
        {

            if (_backBuffer != null)
            {

                _backBuffer.Dispose();

                _backBuffer = null;

            }

            base.OnSizeChanged(e);

        }
        /// <summary>
        /// Adds a new view to the Spotify view and returns the UserControl associated with the view.
        /// 
        /// </summary>
        /// <param name="name">The name of the view</param>
        /// <returns>The UserControl belonging to the view</returns>
        public UserControl AddSection(string name,UserControl playLists)
        {
            
            pane Playlists = new pane();
            Playlists.Sect = playLists;
            Playlists.Label = name;
            Playlists.Dock = DockStyle.Left;
            Playlists.panel1 = this.panel1;
            Playlists.Width = Playlists.Label1.Width > 80 ? Playlists.Label1.Width+20 : 80;
            Playlists.Label1.Left = Playlists.Width / 4;
            playLists.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(Playlists);
            this.ContentPanel.Controls.Add(playLists);
            Sects.Add(name, playLists);
            Playlists.Sect = playLists;
            return playLists;
        }
        public Panel ContentCanel
        {
            get
            {
                return contentPanel;
            }
            set
            {
                contentPanel = value;
            }
        }
        private Dictionary<string, UserControl> sects;
        public Dictionary<string, UserControl> Sects
        {
            get
            {
                return sects;
            }
            set
            {
                sects = value;
            }
        }
        public Panel Header
        {
            get
            {
                return panel1;
            }
            set
            {
                panel1 = value;
            }
        }
        /// <summary>
        /// Elements that are queued for be placed at runtime is stored in this box. Remote content should always be fetched at a separe
        /// thread and according elements be placed in this stack.
        /// </summary>
        public Stack<Element> NewElements
        {
            get
            {
                return newElements;
            }
            set
            {
                newElements = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetSource(string name)
        {
            if (File.Exists("sites.txt"))
            {
                using (StreamReader SR = new StreamReader("sites.txt"))
                {
                    string line;
                    while ((line = SR.ReadLine()) != null)
                    {
                        string[] d = line.Split('=');
                        if (d[0] == name)
                        {
                            this.nspace = URI;
                            this.hasContent = true;
                            return d[1];
                        }
                    }

                }
            }
     /*       WebClient DR = new WebClient();
            string URL = DR.DownloadString("http://spotiapps.krakelin.com/page=?=" + URI);
            this.nspace = URI;
            this.hasContent = true;
            return URL;*/
            this.hasContent = false;
            this.URI = "";
            return "";
            
        }


        /// <summary>
        /// Creates a form by predifined URI;
        /// </summary>
        /// <param name="URI"></param>
        public Form1(string URI)
        {
            
 Sects = new Dictionary<string, UserControl>();
            newElements = new Stack<Element>();
            elements = new Dictionary<string, Control>();
            InitializeComponent();
             if(URI=="")
             {
                 hasContent=false;
                 return;
             }
             string source = GetSource(URI);
             if (source == "")
             {
                 hasContent = false;
                 return;
             }



     /*     Skybound.Gecko.Xpcom.Initialize();
            
             D = new SpotiBrowsser.Browser(source);
             D.Show();
             D.BrowserLoad();
             D.webBrowser1.Navigated += new Skybound.Gecko.GeckoNavigatedEventHandler(webBrowser1_Navigated);
             D.webBrowser1.Navigating += new Skybound.Gecko.GeckoNavigatingEventHandler(webBrowser1_Navigating);
      /*       foreach (HtmlElement RN in D.webBrowser1.Document.GetElementsByTagName("a"))
             {
                 if (RN.OffsetRectangle.Y < 320)
                 {
                     SpotiBrowsser.Browser B = new SpotiBrowsser.Browser(RN.GetAttribute("href"));
                     AddSection(RN.InnerText, B);
                 }
             }*/
        
             feeds = new List<Feed>();
             Sects = new Dictionary<string, UserControl>();
             this.ShowInTaskbar = false;
             this.Text = "Custom Spotifyview";
             try
             {
                 Spofity D;
                 newElements = new Stack<Element>();
                 elements = new Dictionary<string, Control>();
                 string domain = "localhost";
                 XmlDocument RS = new XmlDocument();
                 string appPath = Application.LocalUserAppDataPath + "\\" + URI;



                 try
                 {
                     RS.Load("http://" + domain + "/quote.php?q=" + URI + "");
                     using (StreamWriter SW = new StreamWriter(appPath))
                     {
                         SW.Write(RS.InnerText);
                         SW.Close();
                     }
                 }
                 catch
                 {
                     if (File.Exists(Application.LocalUserAppDataPath + "\\" + URI))
                     {
                         D = new Spofity(appPath);

                         this.Show();

                     }
                     else
                     {
                         this.hasContent = false;
                         return;
                     }
                 }
                
                 D = new Spofity("http://" + domain + "/quote.php?q=" + URI + "");
                
                
                 foreach (Section R in D.View.Sections)
                 {
                    
                     UserControl F = new UserControl();
                     Sects.Add(R.Name, F);
                     F.Dock = DockStyle.Fill;
                     pane X = new pane();
                     X.Sect = F;
                     X.panel1 = this.panel1;
                     X.Label = R.Name;
                    
                     X.Dock = DockStyle.Left;
                     foreach (Element Ds in R.Elements)
                     {
                         Ds.Attributes.Add(new Attribute() { name = "section", value = R.Name });
                         newElements.Push(Ds);
                     }
                     this.panel1.Controls.Add(X);
                     this.ContentPanel.Controls.Add(F);
                     X.Show();
                 }

            
                 this.hasContent = true;
                 this.Show();
                 this.label1.Text = this.Text;
                
             }
             catch
             {
                 this.hasContent = false;
             }
         

               
        
        }
/*
        void webBrowser1_Navigating(object sender, Skybound.Gecko.GeckoNavigatingEventArgs e)
        {
            if (e.Uri.ToString().StartsWith("spotify:") || e.Uri.ToString().StartsWith("http://open.spotify.com"))
            {
                this.OpenSpotifyLink(e.Uri.ToString());

            }
        }

        void webBrowser1_Navigated(object sender, Skybound.Gecko.GeckoNavigatedEventArgs e)
        {
            if (e.Uri.ToString().StartsWith("spotify:") || e.Uri.ToString().StartsWith("http://open.spotify.com"))
            {
                this.OpenSpotifyLink(e.Uri.ToString());
                
            }
        }*/

        void X_MouseDown(object sender, MouseEventArgs e)
        {
            pane X = (pane)sender;
            SetView(X);
        }

        void X_Click(object sender, EventArgs e)
        {
            pane X = (pane)sender;
            SetView(X);
            
        }
        public bool HasContent
        {
            get
            {
                return hasContent;
            }
            set
            {
                hasContent = value;
            }
        }
        public Form1(string URI, string Filter)
        {
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            
            DS = new BufferedGraphicsContext();
            
            newElements = new Stack<Element>();
            InitializeComponent();
          
            LoadLibrary(URI, Filter);
            this.URI = URI;

        }

        void ContentPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control.GetType() == typeof(spotiEntry))
            {
                e.Control.Anchor = AnchorStyles.Right;
            }
        }
        int album = 0;
        int top = 0;
        public void AddElmSection(string Name)
        {
            UserControl DX = new UserControl();
            Label RX = new Label();
            RX.AutoSize = true;
            RX.Text = Name;
            RX.Font = new Font("Arial", 10);
            RX.ForeColor = Color.White;
            DX.BackColor = Color.Gray;
            DX.Controls.Add(RX);
            RX.Left = 2;
            RX.Top = 2;

            DX.Left = 0;
            DX.Top = top;
            DX.Height = 24;
            DX.Width = this.Width;
            DX.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            DX.Anchor = ~AnchorStyles.Bottom;
            if (this.ContentPanel.Controls.Count > 0)
            {
                if (this.ContentPanel.Controls[this.ContentPanel.Controls.Count - 1].GetType() == typeof(UserControl))
                {
                    this.ContentPanel.Controls.Remove(ContentPanel.Controls[this.ContentPanel.Controls.Count - 1]);
                }
            }
            this.ContentPanel.Controls.Add(DX);

            top += DX.Height;
        }
       public void UpdateFeed(Feed feed)
        {
            if (currentFeed != null)
            {
                return;
            }
            currentFeed = feed;
            Stack<Control> removeControls = new Stack<Control>();
            foreach (Control x in this.ContentPanel.Controls)
            {
                foreach (Control i in x.Controls)
                {
                    if (i.Tag.GetType() == typeof(Element))
                    {
                        if (((Element)i.Tag).Feed == feed.Name)
                        {
                            removeControls.Push(i);
                        }
                    }
                }
            }
            while (removeControls.Count > 0)
            {
                Control d = removeControls.Pop();
                d.Parent.Controls.Remove(d);
            }
            WebClient D = new WebClient();
            D.DownloadStringCompleted+=new DownloadStringCompletedEventHandler(D_DownloadStringCompleted);
            D.DownloadStringAsync(new Uri(feed.URL));
          
            
        }
        Feed currentFeed;
        void D_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            XmlDocument D = new XmlDocument();
            XmlDocument RS = new XmlDocument();
            RS.LoadXml(e.Result);
           foreach(XmlElement RN in RS.GetElementsByTagName("element"))
            {
                Element El = new Element(0,0,0,0);
                El.Feed = currentFeed.Name;
                foreach (XmlElement RNS in RN.GetElementsByTagName("attribute"))
                {
                    Attribute r = new Attribute();
                    r.name = RNS.GetAttribute("name");
                    r.value = RNS.GetAttribute("value");
                    El.Attributes.Add(r);
                }
                newElements.Push(El);
            }
           currentFeed = null;
        }
        public static long GetDSSDuration(string fileName)
        {
            FileInfo fi = new FileInfo(fileName);
            long size = fi.Length;

            long length = (long)(((size * 1.1869) - ((size / 1054) * 210)) / 1054);

            if (length > 1000)
            {
                length = (long)(length * (0.61 + ((length / 100) * 0.0005)));
            }
            else
            {
                length = (long)(length * (0.61 + ((length / 100) * 0.0015)));
            }

            return length;
        }
        public void AddAlbum(string URI)
        {

            top += 30;
            using (StreamReader SR = new StreamReader(URI))
            {
                Label Nimda = new Label();

                Nimda.AutoSize = true;
                Nimda.Text = SR.ReadLine();
                Label Year = new Label();
                Year.Text = "(" + DateTime.Now.Year.ToString() + ")";

               Year.Font = new Font("Arial", 10);
                Year.ForeColor = Color.Gray;
               Nimda.Font = new Font("Arial Black", 10);
                top += 10;
                Nimda.Top = top;
                top += 40;
                Nimda.Left = 220;
                Nimda.ForeColor = Color.FromArgb(255, 255, 255);
                Year.Left = Nimda.Left + Nimda.Text.Length * (int)Nimda.Font.Size;
                Year.Top = Nimda.Top;
                PictureBox D = new PictureBox();
                PictureBox C = new PictureBox();
                C.BackgroundImage = Properties.Resources.cord;
                try
                {
                    D.BackgroundImage = Bitmap.FromFile(folder + "\\" + "covers\\" + Nimda.Text + ".png");
                }
                catch
                {
                    D.BackgroundImage = Bitmap.FromFile(folder + "\\" + "covers\\" + Nimda.Text + ".jpg");
                }
                D.BackgroundImageLayout = ImageLayout.Stretch;
                D.Width = 133;
                D.Height = 133;
                D.Left = 50;
                D.Top = top - 30;
                C.Left = D.Left - 4;
                C.Top = D.Top - 3;
                C.Width = C.BackgroundImage.Width;
                C.Height = C.BackgroundImage.Height;

                int countTrack = 0;
                string track;
                int CD = 1;
                bool foundArtist = false;
                while ((track = SR.ReadLine()) != null)
                {

                    String Artist = "";
                    String[] ds = track.Split(';');
                    if (ds.Length > 1)
                    {
                        Artist = ds[1];
                    }
                    if (Artist == artist || (artist == "" && Artist == ""))
                        foundArtist = true;


                }
                if (!foundArtist)
                {
                    top -= 80;
                    return;
                }
                SR.BaseStream.Seek(0, SeekOrigin.Begin);
                SR.ReadLine();
                while ((track = SR.ReadLine()) != null)
                {


                    string[] sp = track.Split(';');
                    if (track == "---")
                    {

                        top += 33;

                        CDNotice Dx = new CDNotice();
                        Dx.Number = CD.ToString();
                        CD++;
                        Dx.Left = 220;
                        Dx.Top = top - 23;
                        this.ContentPanel.Controls.Add(Dx);
                        continue;
                    }
                    spotiEntry A = new spotiEntry();

                    A.Title = sp[0];
                    System.Media.SoundPlayer Ds = new SoundPlayer(folder + ("\\WAV\\" + sp[0].Replace(":", "_") + ".wav"));
                    if (File.Exists(folder + ("\\WAV\\" + sp[0].Replace(":", "_") + ".wav")))
                    {
                        decimal d = (decimal)GetDSSDuration((folder + ("\\WAV\\" + sp[0].Replace(":", "_") + ".wav")));
                        A.Length = Math.Round(d).ToString();

                    }
                    A.Number = countTrack + 1;
                    A.Tag = (object)folder + ("\\WAV\\" + sp[0].Replace(":", "_") + ".wav");
                    A.Anchor = AnchorStyles.Right | AnchorStyles.Left;
                    A.Anchor = ~AnchorStyles.Bottom;
                    A.Top = top;
                    A.Left = 220;
                    A.Width = this.Width - 220;
                    this.ContentPanel.Controls.Add(A);
                    countTrack++;

                  //  A.Even = countTrack % 2 == 0;
                    top += A.Height;
                    if (sp.Length > 1 && sp[1] != artist)
                    {
                        A.Artist = sp[1];
                    }
                    else
                    {
                        A.Artist = "";
                    }

                    A.Unavailable = !File.Exists(folder + "\\WAV\\" + sp[0].Replace(":", "_") + ".wav");

                }

                if (countTrack * 16 < D.Height + 40)
                {
                    top += (D.Height + 20) - countTrack * 16;
                }
                else
                {
                    top += 20;
                }

                this.ContentPanel.Controls.Add(D);
                this.ContentPanel.Controls.Add(C);
                this.ContentPanel.Controls.Add(Nimda);
                this.ContentPanel.Controls.Add(Year);

                UserControl x = new UserControl();
                x.Left = 0;
                x.Top = top;
                x.Width = this.Width;
                x.Height = 1;
                x.BackColor = Color.Black;
                this.ContentPanel.Controls.Add(x);
                x.Anchor = AnchorStyles.Right | AnchorStyles.Left;
                x.Anchor = ~AnchorStyles.Bottom;
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {

        }

        void Content_BeginLoading()
        {


        }
        void FinishedLoad()
        {

        }
        void D_MouseDown(object sender, MouseEventArgs e)
        {



        }
        
        private Spofity content;
        public Spofity Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }
        private string uri = "";
        public string URI
        {
            get
            {
                return uri;
            }
            set
            {
                uri = value;
            }
        }

        public Form1()
        {
            InitializeComponent();
            Sects = new Dictionary<string, UserControl>();
            elements = new Dictionary<string, Control>();
            newElements = new Stack<Element>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            /*    
                 DwmSetWindowAttribute(Spotify, (uint)DWMWINDOWATTRIBUTE.DWMWA_NCRENDERING_ENABLED, (IntPtr)Spotify, (IntPtr)sizeof(int));
                 DwmSetWindowAttribute(Spotify, (uint)DWMWINDOWATTRIBUTE.DWMWA_ALLOW_NCPAINT, IntPtr.Zero,IntPtr.Zero);
                 */


            //   Form Ds = (Form)Form.FromHandle(Spotify);


            /*
            VistaControls.Dwm.Margins D =  new   VistaControls.Dwm.Margins() { Bottom = -1, Left = -1, Top = -1, Right = -1 };
            
            VistaControls.Dwm.DwmManager.EnableGlassSheet(Spotify);
           
            {
             //   MessageBox.Show(a.ToString());
            }*/



        }
        bool s = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
           if (newElements.Count > 0)
            {
                
                Element D = newElements.Pop();
                Control F = new Control();
                Type d = Type.GetType(D.Type);
                switch (D.Type)
                {
                    case "sp:label":
                        F = new Label();
                        F.Text = D.GetAttribute("label");
                        ((Label)F).AutoSize = true;
                        F.Font = new Font("MS Sans Serif", int.Parse(D.GetAttribute("size")));
                        break;
                    case "sp:button":
                        F = new spotifyButton();
                        F.Click  += new EventHandler(F_Click);
                       
                        break;
                    case "sp:group":

                        break;
                    case "sp:cover":
                        F = new spotiImage();
                        string ImageURI = D.GetAttribute("image");
                        Stream Fx;
                        if (ImageURI.StartsWith("http://"))
                        {
                            WebClient R = new WebClient();
                            Fx = R.OpenRead(ImageURI);
                        }
                        else
                        {
                            Fx = new FileStream(ImageURI, FileMode.Open);

                        }
                        ((spotiImage)F).Picture = Bitmap.FromStream(Fx);
                        Fx.Close();
                        break;
                    case "sp:link":
                        F = new LinkLabel();
                        F.Text = D.GetAttribute("label");
                        ((LinkLabel)F).AutoSize = true;
                        ((LinkLabel)F).LinkColor = Color.FromArgb(133, 133, 133);
                        F.Font = new Font("MS Sans Serif", int.Parse(D.GetAttribute("size")));
                        F.Click += new EventHandler(F_Click);
                        F.Tag = (object)D.GetAttribute("href");
                        ((LinkLabel)F).LinkBehavior = LinkBehavior.HoverUnderline;

                        break;
                    case "sp:entry":
                        F = new spotiEntry();
                        F.Text = D.GetAttribute("label");
                        ((spotiEntry)F).Title = D.GetAttribute("title");
                        ((spotiEntry)F).Artist=D.GetAttribute("artist");
                       
                        F.Font = new Font("Tahoma", 8.25f);
                        F.DoubleClick += new EventHandler(F_Click);
                        F.Tag = (object)D.GetAttribute("href");
                        ((spotiEntry)F).Song = false;
                        break;
                    default:
                       

                        F = (Control)Activator.CreateInstance(d);
                        /// Set object properties

                        foreach (Attribute Attribs in D.Attributes)
                        {
                            try
                            {
                                _PropertyInfo X = d.GetProperty(Attribs.name);
                                X.SetValue(F, Attribs.value, null);
                            }
                            catch
                            {
                            }
                        }
                        break;
                }
                try
                {
                    
                    F.Left = int.Parse(D.GetAttribute("x"));
                    F.Top = int.Parse(D.GetAttribute("y"));
                    F.Width = int.Parse(D.GetAttribute("width"));
                    F.Height = int.Parse(D.GetAttribute("height"));
                    
                }
                catch
                {
                }

               


                try
                {
                    F.Tag = (object)D;
                    this.sects[D.GetAttribute("section")].Controls.Add(F);
                    elements.Add(D.GetAttribute("Name"), F);
                    if (F.GetType() == typeof(spotiEntry))
                    {
                        ((spotiEntry)F).Even = bool.Parse(D.GetAttribute("even"));
                        ((spotiEntry)F).OldColor = F.BackColor;
                    }
                }
                catch
                {
                }
            }
        }
        public string GetURIFromPage(Uri Uri)
        {
            WebClient DS = new WebClient();
            String Content = DS.DownloadString( Uri);
            string ps = Content.Substring(Content.IndexOf("spotify:"), 153);
            int i = 0;
            foreach (char d in ps)
            {
                if (d == '\"')
                {
                    break;
                }
                i++;
            }
            string n = ps.Substring(0, i);
            return n;
        }
        public List<Feed> Feeds
        {
            get
            {
                return feeds;
            }
            set
            {
                feeds = value;
            }
        }
        /// <summary>
        /// Adds dynamic set of controls that are bound to a particular feed. They will be removed when updating the feed.
        /// </summary>
        /// <param name="Section">The section of the SpotiApp the feed will be applied to</param>
        /// <param name="elementType">Type of elements that can be created.</param>
        /// <param name="URI">The URI to the feed (must be RSS 2.0)</param>
        /// <param name="limit">The limit of amount elements to add</param>
        /// <param name="Location">Location of the feed</param>
        /// <param name="nspace">Space of the feed</param>
        /// <param name="Enter">Event that occur when the user activates the feed elements,</param>
        public void AddFeed(String Section,string elementType, string URI, int limit, Point Location, string nspace,EventHandler Enter)
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

                    Element Name = new Element(Location.X,Location.Y,120,32);
                    Name.Type = elementType;
                    Name.Attributes.Add(new Attribute() { name = "x", value = Location.X.ToString() });
                    Name.Attributes.Add(new Attribute() { name = "y", value = (Location.Y + i * 20).ToString() });
                    Name.Attributes.Add(new Attribute() { name = "title", value = name });
                    Name.Attributes.Add(new Attribute() { name = "href", value = url });
                    Name.Attributes.Add(new Attribute() { name = "artist", value = "Playlist" });
                    Name.Feed = nspace;
                    Name.OnClick += Enter;
                    Name.Attributes.Add(new Attribute() { name = "section", value = Section });
                    Name.Attributes.Add(new Attribute() { name = "size", value = "10" });
                    Name.Attributes.Add(new Attribute() { name = "name", value = "playlist-" + name });
                    Name.Attributes.Add(new Attribute() { name = "even", value = (i % 2 == 0).ToString() });
                    this.NewElements.Push(Name);
                    i++;
                }
            }
            catch
            {
            }

        }
        void F_Click(object sender, EventArgs e)
        {
            Control D = (Control)sender;
            try
            {
                Element F = (Element)D.Tag;
                F.Click(sender, e);
            }
            catch
            {
            }
         //   Process.Start("spotify", (string)D.Tag);
            
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // turn on WS_EX_TOOLWINDOW style bit
                cp.ExStyle |= 0x80;
                return cp;
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        BufferedGraphicsContext DS;
        BufferedGraphicsManager FS;
        private void ContentPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }
      
        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void SetActiveSection(string name)
        {
            foreach (Control a in panel1.Controls)
            {
                if (a.GetType() == typeof(pane))
                {
                    if (((pane)a).Label == name)
                    {
                        ((pane)a).DoMouseDown();
                    }
                }
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Content.loadThread.ThreadState == System.Threading.ThreadState.Stopped)
            {
                FinishedLoad();
                timer2.Stop();
            }

        }
        bool shift = false;
        private void frmPreview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
                LoadLibrary(URI, artist);


        }
        public AxWMPLib.AxWindowsMediaPlayer Player
        {
            get
            {
                return this.axWindowsMediaPlayer1;
            }
        }
        private void frmPreview_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                bool found = false;
                if (!e.Shift)
                {
                    foreach (spotiEntry Entry in Entries)
                    {
                        Entry.Selected = false;
                    }
                }
                if (selectedItems.Count > 0)
                    foreach (spotiEntry Entry in Entries)
                    {
                        if (Entry == selectedItems[0])
                        {
                            found = true;
                            continue;
                        }
                        if (found)
                        {
                            Entry.Selected = true;
                        }
                    }
            }
            if (e.KeyData == Keys.Up)
            {
                Entries.Reverse();
                bool found = false;
                if (!e.Shift)
                {

                    foreach (spotiEntry Entry in Entries)
                    {
                        Entry.Selected = false;
                    }

                }
                if (selectedItems.Count > 0)
                    foreach (spotiEntry Entry in Entries)
                    {
                        if (Entry == selectedItems[0])
                        {
                            found = true;
                            continue;
                        }
                        if (found)
                        {
                            Entry.Selected = true;
                        }
                    }
                Entries.Reverse();
            }
        }
       
        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }
        public bool Shift
        {
            get
            {
                return shift;
            }
            set
            {
                shift = value;
            }
        }
       List<Feed> feeds;
        private void ContentPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void pane1_DoubleClick(object sender, EventArgs e)
        {
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadLibrary(this.URI, ((string)comboBox1.Text).Replace(".artist", ""));
        }

        private void Form1_Activated(object sender, EventArgs e)
        {

        }

        private void ContentPanel_VisibleChanged(object sender, EventArgs e)
        {
       
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
          
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            
         
           
        }
        void F()
        {
            try
            {
                if (newElements.Count == 0)
                {
                    Spofity D = new Spofity("http://localhost/quote.php?q=" + this.nspace);
                    foreach (Section R in D.View.Sections)
                    {
                        foreach (Element Ds in R.Elements)
                        {
                            Ds.Attributes.Add(new Attribute() { name = "section", value = R.Name });
                            newElements.Push(Ds);
                        }
                    }
                }
            }
            
            catch
            {
            }
            
        }
        bool hasNewElements = false;
        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
           
           /* if (Visible)
            {
                if (newElements.Count > 0)
                {
                    elements.Clear();
                    foreach (UserControl a in Sects.Values)
                    {
                        a.Controls.Clear();
                    }
                    
                }

                
            }*/
           
        }
        private bool testMode = false;
        public bool TestMode
        {
            get
            {
                return testMode;
            }
            set { testMode = value; }
        }
        private void Form1_Activated_1(object sender, EventArgs e)
        {
            /* if(!testMode)
                 if (Program.Spotify != Helper.GetForegroundWindow())
                 {
                     Helper.SetForegroundWindow(Program.Spotify);
                 }*/
        }
    }
}
