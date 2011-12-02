using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spofity
{
    public partial class pane : UserControl
    {
        private Panel sect;
        public Panel Sect
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void label1_MouseDown(object sender, MouseEventArgs e)
        {
       /*     foreach (Control I in this.panel1.Controls)
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
            }*/
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }
    }
}
