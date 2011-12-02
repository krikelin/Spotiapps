using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace Spofity
{
    public partial class spotifyPanel : UserControl
    {
        public spotifyPanel()
        {
            InitializeComponent();
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
        private void spotifyPanel_Load(object sender, EventArgs e)
        {
            
        }

        private void spotifyPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(104, 104, 104)), new Rectangle(12, 30, this.Width - 10, this.Height - 40));

        }

        private void spotifyPanel_Load_1(object sender, EventArgs e)
        {

        }
    }
}
