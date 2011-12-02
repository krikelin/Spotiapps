using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;
namespace Spofity
{
    public partial class Form1 : Form
    {
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
        public List<spotiEntry> Entries
        {
            get
            {
                List<spotiEntry> entries = new List<spotiEntry>();
                foreach (Control entry in this.ContentPanel.Controls)
                {
                    if (entry.GetType() == typeof(spotiEntry))
                    {
                        entries.Add((spotiEntry)entry);
                    }
                }
                return entries;
            }
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
            string d ="";
            for (var i = 0; i < fr.Length - 1; i++)
            {
                d += fr[i] + "\\";
            }
            return d;
        }
        string folder;
        string artist;
        
        public void LoadLibrary(string URI,string Filter)
        {
            top = 0;
            
            folder = URI;
            if (Filter == "")
            {
                DirectoryInfo R = new DirectoryInfo(URI);
                Filter = R.GetFiles("*.artist")[0].Name.Replace(".artist","");
                this.comboBox1.Items.Clear();
                foreach (FileInfo Art in R.GetFiles("*.artist"))
                {
                    this.comboBox1.Items.Add((string)Art.Name.Replace(".artist", ""));
                }
            }
            artist = Filter.Replace(".artist","");
            this.ContentPanel.Controls.Clear();
            top += 10;
            if (URI.EndsWith(".album"))
            {
                folder = GetFolder(URI);
                AddAlbum(URI);
            }
            else
            {


                AddReleaseSection("Album",artist);
                AddReleaseSection("Single", artist);
            }
            
        }
        public void AddReleaseSection(string name,string Filter)
        {
            DirectoryInfo DI = new DirectoryInfo(folder);
            DirectoryInfo DI2 = new DirectoryInfo(folder+"\\Release");
            if (DI2.GetFiles("*."+name.ToLower()).Length > 0)
            {
                AddSection(name+"s");
            }
            var c = DI2.GetFiles("*." + name.ToLower());
            var i = 0;
            for (int x=0; x < c.Length; x++)
            {
               
                AddAlbum(c[x].FullName);
             
            }
        }
        public Form1(string URI,string Filter)
        {
          
            InitializeComponent();
            LoadLibrary(URI, Filter);
            this.URI = URI;

        }

        void contentPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control.GetType() == typeof(spotiEntry))
            {
                e.Control.Anchor = AnchorStyles.Right;
            }
        }
        int album = 0;
        int top = 0;
        public void AddSection(string Name)
        {
            Panel DX = new Panel();
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
            if (this.contentPanel.Controls.Count > 0 )
            {
                if (this.ContentPanel.Controls[this.ContentPanel.Controls.Count - 1].GetType() == typeof(Panel))
                {
                    this.contentPanel.Controls.Remove(ContentPanel.Controls[this.ContentPanel.Controls.Count - 1]);
                }
            }
             this.contentPanel.Controls.Add(DX);
            
            top += DX.Height;
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
                Year.ForeColor = Color.White;
                Nimda.Font = new Font("Arial Black", 10);
                top += 10;
                Nimda.Top = top;
                top += 40;
                Nimda.Left = 220;
                Nimda.ForeColor = Color.FromArgb(255, 255, 255);
                Year.Left = Nimda.Left + Nimda.Text.Length*(int)Nimda.Font.Size;
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
                D.Top = top-30;
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
                    String[] ds  = track.Split(';');
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
                        Dx.Top = top-23;
                        this.contentPanel.Controls.Add(Dx);
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
                    A.Number = countTrack+1;
                    A.Tag = (object)folder + ("\\WAV\\" + sp[0].Replace(":", "_") + ".wav");
                    A.Anchor = AnchorStyles.Right | AnchorStyles.Left;
                    A.Anchor = ~AnchorStyles.Bottom;
                    A.Top = top; 
                    A.Left = 220;
                    A.Width = this.Width - 220;
                    this.contentPanel.Controls.Add(A);
                    countTrack++;
                   
                    A.Even = countTrack % 2 == 0;
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

                this.contentPanel.Controls.Add(D);
                this.contentPanel.Controls.Add(C);
                this.contentPanel.Controls.Add(Nimda);
                this.contentPanel.Controls.Add(Year);

                Panel x = new Panel();
                x.Left = 0;
                x.Top = top;
                x.Width = this.Width;
                x.Height = 1;
                x.BackColor = Color.Black;
                this.contentPanel.Controls.Add(x);
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

        private void contentPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            if(e.KeyData == Keys.F5)
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
                if(selectedItems.Count>0)
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
                if(selectedItems.Count>0)
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
        private void contentPanel_Paint_1(object sender, PaintEventArgs e)
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
    }
}
