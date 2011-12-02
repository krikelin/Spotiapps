using System;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Spofity
{
    /// <summary>
    /// This class represents a list item that can be used to sort entities in a Spotify view
    /// 
    /// </summary>
    public partial class spotiEntry : UserControl
    {
        private Color oldForeColor;
        public Color OldForeColor
        {
            get
            {
                return oldForeColor;
            }
            set
            {
                oldForeColor = value;
            }
        }
        public Color OldColor
        {
            get
            {
                return oldColor;
            }
            set
            {
                oldColor = value;
            }
        }
        private Color oldColor;
        private bool selected;
        public bool Selected
        {
            get
            {
                return selected;
                
            }
            set
            {
                selected = value;
                if (selected)
                {
                    oldForeColor = this.lName.ForeColor;

                    oldColor = this.BackColor;
                    this.BackColor = Color.FromArgb(165, 235, 255);
                    this.lName.ForeColor = Color.Black;
                  //  this.lNumber.ForeColor = Color.Black;
                    this.lTime.ForeColor = Color.Black;
                  //  this.pictureBox3.BackgroundImage = Properties.Resources.playsel;
                }
                else
                {
                    
                    
                    this.BackColor = oldColor;
             
                /*    this.lName.ForeColor = Artist.Length > 0 ? Color.Gray : Color.White;
                    this.lNumber.ForeColor = Color.FromArgb(94,94,94);*/
                    this.lTime.ForeColor = oldForeColor;
                    this.lName.ForeColor = oldForeColor;
                 //   this.lNumber.ForeColor = oldForeColor;
                    this.lTime.ForeColor = oldForeColor;
                 /*   if (!File.Exists((string)this.Tag))
                        this.Unavailable = true;*/
                    //this.pictureBox3.BackgroundImage = Properties.Resources.play;
                }
                
             
               
            }
        }
        private string title;
        public string Title
        {
            get
            {
                return lName.Text;
            }
            set
            {
                if (value.Length > 50)
                {
                    string f = value.Substring(0, 45) + "..";
                    lName.Text = f;
                }
                else
                {
                    lName.Text = value;
                }
            }
        }
        private string Zerofill(int input)
        {
            if (input < 10)
            {
                return "0" + input.ToString();
            }
            else
            {
                return input.ToString();
            }
        }
        private DateTime length;
        public string Length
        {
            get
            {
                return Zerofill(length.Minute) + ":" + Zerofill(length.Second);
            }
            set
            {
              
                length = new DateTime();

                double r = 0;
                try
                {
                    r = double.Parse(value.Split(':')[1]) + double.Parse(value.Split(':')[0]) * 60;
                }
                catch
                {
                    r = double.Parse(value);
                }
                length  = length.AddSeconds(r);
                lTime.Text = Zerofill(length.Minute) + ":" + Zerofill(length.Second);
            }
        }
        private int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
        //        this.lNumber.Text = value.ToString();
            }
        }
        private bool unavailable = false;
        public bool Unavailable
        {
            get
            {
                return unavailable;
            }
            set
            {

                unavailable = value;
                foreach (Control i in Controls)
                {
                    if (i.GetType() == typeof(Label))
                    {
              //          i.ForeColor = unavailable ? Color.FromArgb(150,120,120) : i.ForeColor;
                    }
                }
            }
        }

        public spotiEntry()
        {
            InitializeComponent();
            length = DateTime.Now;
           
         
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            oldColor = this.BackColor;
            this.Anchor = AnchorStyles.Left | AnchorStyles.Right | ~AnchorStyles.Bottom | AnchorStyles.Top;
            UserControl Host = (UserControl)this.Parent;
            this.Width = Host.Width - this.Left;
            this.lName.Font = new Font("MS Sans Serif", 8);
            this.lArtist.Font = new Font("MS Sans Serif", 8);
     //       this.lNumber.Font = new Font("MS Sans Serif", 8);
        }
        private bool even = false;
        public bool Even
        {
            get
            {
                return even;
            }
            set
            {
                even = value;
                UserControl F = (UserControl)this.Parent;
                 if (even)
                 {
                     oldColor = this.BackColor;
                     this.BackColor = F.BackColor;
                     
                 }
                 else
                 {
                     try
                     {

                         oldColor = this.BackColor;
                         this.BackColor = Color.FromArgb(F.BackColor.R + -5, F.BackColor.G + -5, F.BackColor.B + -5);
                     }
                     catch
                     {
                     }
                 }
            }
        }
        public string Artist
        {
            get
            {
                return this.lArtist.Text;
            }
            set
            {
                this.lName.ForeColor = Color.FromArgb(127, 127, 127);
                this.lArtist.Text = value;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        public bool Song
        {
            get
            {
                return this.pictureBox2.Visible;
            }
            set
            {
                this.pictureBox2.Visible = value;
                this.pictureBox3.Visible = value;
                this.lTime.Visible = value;
            }
        }
        public bool Playing
        {
            get
            {
                return this.pictureBox3.Visible;
            }
            set
            {
                if (!Playing&&value)
                {
                    spotiEntry DS = (spotiEntry)this;
                    Form1 D = (Form1)DS.ParentForm;
                    foreach (spotiEntry Entry in D.Entries)
                    {
                        Entry.Playing = false;
                       
                    }
                }
                
                this.pictureBox3.Visible = value;
               
            }
        }
        private void spotiEntry_Load(object sender, EventArgs e)
        {
            
        }
        private bool shift;
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
        public AxWMPLib.AxWindowsMediaPlayer Player;
        private void spotiEntry_DoubleClick(object sender, EventArgs e)
        {
            /*
            spotiEntry DS = (spotiEntry)sender; 
            Form1 D = (Form1)DS.ParentForm;
            try
            {
                if (File.Exists(((string)DS.Tag)))
                {
                    D.Player.URL = ("file://" + ((string)DS.Tag).Replace("\\", "/"));
                    this.Playing = true;
                }
                else
                {
                   
                }
            }
            catch
            {
              
            }*/
        }


        private void lName_DoubleClick(object sender, EventArgs e)
        {
            spotiEntry_DoubleClick(this, new EventArgs());
        }
       
        private void spotiEntry_MouseDown(object sender, MouseEventArgs e)
        {
            Form1 D = (Form1)ParentForm;

            if (D.Shift)
            {
                bool found = false;
                if (D.OldSelectedIndex > D.SelectedIndex)
                {
                    D.Entries.Reverse();
                }
                for (int i = 0; i < D.Entries.Count; i++)
                {
                    if (i == D.SelectedIndex)
                    {
                        found = false;
                    }
                    if (i == D.OldSelectedIndex)
                    {
                        found = true;
                    }
                    if (found)
                    {
                        D.Entries[i].Selected = true;
                    }
                   
                }
                if (D.OldSelectedIndex > D.SelectedIndex)
                {
                    D.Entries.Reverse();
                }
            }
            else
            {
                foreach (Control i in D.Entries)
                {
                    if (i.GetType() == typeof(spotiEntry))
                    {
                       
                            spotiEntry F = ((spotiEntry)i);
                          
                            F.Selected = false;
                          
                       
                    }
                }
            }
            spotiEntry AB = ((spotiEntry)sender);
            AB.Selected = true;
            int rs = 0;
            foreach(spotiEntry B in D.Entries)
            {
                if(B==AB)
                {
                    D.SelectedIndex=rs;
                    break;
                }
                rs++;
            }
        }

        private void lName_MouseDown(object sender, MouseEventArgs e)
        {
            spotiEntry_MouseDown(((Control)sender).Parent, new MouseEventArgs(MouseButtons.Left,0,0,0,0));

        }

        private void spotiEntry_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lTime_Click(object sender, EventArgs e)
        {

        }

        private void spotiEntry_KeyDown(object sender, KeyEventArgs e)
        {
            /*List<spotiEntry> Entries = ((Form1)ParentForm).Entries;
            List<spotiEntry> selectedItems = ((Form1)ParentForm).selectedItems;
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
            }*/
        }

        private void lArtist_Click(object sender, EventArgs e)
        {

        }
        public bool Track
        {
            get
            {
                return panel1.Visible;
            }
            set
            {
                panel1.Visible = value;
            }
        }
        private void lArtist_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
         /*   LinkLabel Sender = (LinkLabel)sender;
            if (Sender.Text != "")
            {
                Form1 D = (Form1)ParentForm;

                D.Artist = Sender.Text;
            }*/
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
