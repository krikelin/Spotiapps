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
    public partial class spotifyButton : UserControl
    {
        private bool down=false;
        private bool insideGroup = false;
        public bool InsideGroup
        {
            get
            {
                return insideGroup;
            }
            set
            {
                insideGroup = value;
            }
        }
        private string label;
        public string Label
        {
            get
            {
                return label;
            }
            set
            {
                label = value;
            }
        }
        public spotifyButton()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(spotifyButton_MouseDown);
            this.MouseUp += new MouseEventHandler(spotifyButton_MouseUp);
         
        }

        void spotifyButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.down = false;
            this.Refresh();
        }

        void spotifyButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.down = true;
            this.Refresh();
        }
        
        private void spotifyButton_Paint(object sender, PaintEventArgs e)
        {
            Image D  = null;

            if (down)
            {
                if (insideGroup)
                {
                    D = Properties.Resources.buttondownx;
                }
                else
                {
                    D = Properties.Resources.buttondown;
                }
            }
            else
            {
                if (insideGroup)
                {
                    D = Properties.Resources.buttonx;
                }
                else
                {
                    D = Properties.Resources.button;
                }
            }
            e.Graphics.DrawImage(D, 0, 0, new Rectangle(0, 0, 10, D.Height), GraphicsUnit.Pixel);
            for (int i = 0; i < this.Width / 10 - 1; i++)
            {
                e.Graphics.DrawImage(D, 10 + 10 * i, 0, new Rectangle(10, 0,10, D.Height), GraphicsUnit.Pixel);
            }
            e.Graphics.DrawImage(D, this.Width - 10, 0, new Rectangle(D.Width - 10, 0, 10, D.Height),GraphicsUnit.Pixel);
            e.Graphics.DrawString(this.label, new Font("MS Sans Serif", 8), new SolidBrush(Color.Black), new Point(2, 2));
        }

        private void spotifyButton_Load(object sender, EventArgs e)
        {

        }

        private void spotifyButton_FontChanged(object sender, EventArgs e)
        {

        }

        private void spotifyButton_MouseDown_1(object sender, MouseEventArgs e)
        {
            
        }

        private void spotifyButton_MouseUp_1(object sender, MouseEventArgs e)
        {

        }
    }
}
