using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Spofity
{
    public partial class spotiImage : UserControl
    {
        public Image Picture
        {
            get
            {
                return this.pictureBox2.BackgroundImage;
            }
            set
            {
                this.pictureBox2.BackgroundImage = value;
            }
        }
        public spotiImage()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
