using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace Spofity
{
    public partial class pane : UserControl
    {
        private UserControl sect;
        public UserControl Sect
        {
            get
            {
                return sect;
            }
            set
            {
                sect = value;
            }
        }
        private bool active;
        public bool Active
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
            }
        }
        public pane()
        {
            InitializeComponent();
        }

        private void pane_Load(object sender, EventArgs e)
        {

        }
        public void DoMouseDown()
        {
            this.pane_MouseDown((object)this, null);
        }
        public string Label
        {
            get
            {
                return this.label1.Text;
            }
            set
            {
                this.label1.Text = value;
            }
        }
        public Panel panel1;
        private void pane_Paint(object sender, PaintEventArgs e)
        {
            if (this.active)
            {
                this.label1.ForeColor = Color.White;
                e.Graphics.DrawImage(Properties.Resources.section, 0, 0, this.Width, this.Height);
            }   
            else
            {
                this.label1.ForeColor = Color.Black;
                e.Graphics.DrawImage(Properties.Resources.ascendia,0,0,this.Width,this.Height);
              //  e.Graphics.DrawLine(new Pen(Color.FromArgb(188,188,188)), new Point(0, 0), new Point(0, this.Height-2));
                e.Graphics.DrawLine(new Pen(Color.FromArgb(188, 188, 188)), new Point(this.Width - 1, 0), new Point(this.Width - 1, this.Height - 2));
                e.Graphics.DrawLine(new Pen(Color.FromArgb(118, 118, 118)), new Point(this.Width - 2, 0), new Point(this.Width - 2, this.Height - 2));
            }
        }

        private void pane_MouseDown(object sender, MouseEventArgs e)
        {
            
            foreach (Control I in this.panel1.Controls)
            {
                if (I.GetType() == typeof(pane))
                {
                    pane D = (pane)I;

                    if (sender == (object)D)
                    {
                        D.Active = true;
                        D.Sect.Show();
                    }
                    else
                    {
                        D.Active = false;
                        D.Sect.Hide();
                    }
                    D.Refresh();
                }
            }
          
        }
        public Label Label1
        {
            get
            {
                return label1;
            }
            set
            {
                label1 = value;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void label1_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (Control I in this.panel1.Controls)
            {
                if (I.GetType() == typeof(pane))
                {
                    pane D = (pane)I;

                    if (((Control)sender).Parent == (object)D || sender == (object)D)
                    {
                        D.Active = true;
                        D.Sect.Show();
                    }
                    else
                    {
                        D.Active = false;
                        D.Sect.Hide();
                    }
                    D.Refresh();
                }
            }
        
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }
    }
}
