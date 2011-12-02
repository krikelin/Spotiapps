using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        public Form1(string URI)
        {
            InitializeComponent();
            Content = new Spofity(URI);
            Content.BeginLoading += new Spofity.ActionEvent(Content_BeginLoading);
            Content.FinishedLoading += new Spofity.ActionEvent(FinishedLoad);
            Content.LoadData();
            timer2.Start();
        }
        public List<spotiEntry> SelectedNodes
        {
           
            get
            {
                List<spotiEntry> nodes = new List<spotiEntry>();
                foreach (spotiEntry a in this.panel1.Controls)
                {
                    if(a.Selected)
                        nodes.Add(a);
                }
                return nodes;
            }
        }
        public void ClearSelected()
        {
            foreach (spotiEntry a in this.panel1.Controls)
            {
                a.Selected = false;
            }
        }
 
        public void GetSelectedNodes(bool multiple,int y)
        {
           
            if (multiple)
            {
                int i = 0;
                foreach (spotiEntry a in this.panel1.Controls)
                {
                    if (i >= selectedIndex && y < a.Top+a.Bottom)
                    {
                        a.Selected = true;
                    }
                }
            }
            else
            {
                 int j = 0;
                foreach (spotiEntry entry in panel1.Controls)
                {
                    if (y > entry.Top && y < entry.Bottom)
                    {
                        entry.Selected = true;
                        selectedIndex = j;
                        break;
                    }
                    j++;
                }
            }

        }
        void Content_BeginLoading()
        {
            this.label1.Text = "Loading page";

        }
        void FinishedLoad()
        {
            this.label1.Text = "Finished";
            for (int i = Content.View.Sections.Count - 1; i >= 0; i--)
            {
                Section d = Content.View.Sections[i];
                pane D = new pane();
                D.Label = d.Name;
                D.Show();
                D.Dock = DockStyle.Left;
                D.Width = 75;
                D.Height = this.panel1.Height;
                D.Sect = new Panel();
                panel1.Controls.Add(D);
                D.panel1 = this.panel1;
                this.contentPanel.Controls.Add(D.Sect);
                D.Sect.Dock = DockStyle.Fill;
                D.Sect.Show();
                //D.Sect.MouseDown += new MouseEventHandler(D_MouseDown);
                foreach (Element a in d.Elements)
                {
                    switch (a.Type)
                    {
                        case "sp:group":
                            spotifyPanel sp = new spotifyPanel();
                            sp.Label = a.GetAttribute("label");
                            sp.Width = int.Parse(a.GetAttribute("width"));
                            sp.Height = int.Parse(a.GetAttribute("height"));
                            sp.Left = int.Parse(a.GetAttribute("x"));
                            sp.Top = int.Parse(a.GetAttribute("y"));
                            D.Sect.Controls.Add(sp);
                            sp.Show();
                            break;
                        case "sp:label":
                            Label spx = new Label();
                            if (a.GetAttribute("autoSize") != "")
                            {
                                spx.AutoSize = bool.Parse(a.GetAttribute("autoSize"));

                            }

                            spx.Text = a.GetAttribute("label");
                            spx.Width = int.Parse(a.GetAttribute("width"));
                            spx.Height = int.Parse(a.GetAttribute("height"));
                            spx.Left = int.Parse(a.GetAttribute("x"));
                            spx.Top = int.Parse(a.GetAttribute("y"));

                            spx.ForeColor = Color.Gray;
                            spx.BackColor = Color.Transparent;



                            D.Sect.Controls.Add(spx);
                            spx.Show();
                            break;

                        default:
                            break;
                    }

                }

                if (i == 0)
                {
                    D.label1_MouseDown((object)D, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                }
                foreach (Control spx in D.Sect.Controls)
                {
                    if (spx.GetType() == typeof(Label))
                        foreach (Control Cont in D.Sect.Controls)
                        {
                            if (Cont.GetType() == typeof(spotifyPanel))
                            {

                                spotifyPanel SD = (spotifyPanel)Cont;
                                if (spx.Left > SD.Left && spx.Top > SD.Top && spx.Left < SD.Width + SD.Left && spx.Top < SD.Height + SD.Top)

                                    spx.ForeColor = Color.Black;
                                spx.BackColor = Color.FromArgb(104, 104, 104);


                            }
                        }
                }
            }
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

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
