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
    public partial class SLabel : UserControl
    {
        public SLabel()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(SLabel_Paint);
        }
       
        public string Label
        {
            get
            {
                return Text;
            }
            set { Text = value; }
        
        }
        void SLabel_Paint(object sender, PaintEventArgs e)
        {
            if (Text.Contains('\n'))
            {
                int i = 0;
                foreach (string d in Text.Split('\n'))
                {
                    e.Graphics.DrawString(d, this.Font, new SolidBrush(Color.FromArgb(42, 42, 42)), new Point(1, 1+i*(int)this.Font.GetHeight()));
                    e.Graphics.DrawString(d, this.Font, new SolidBrush(ForeColor), new Point(0, 0 + i * (int)this.Font.GetHeight()));
                    i++;
                }
            }
            else
            {
                e.Graphics.DrawString(Text, this.Font, new SolidBrush(Color.FromArgb(42, 42, 42)), new Point(1, 1));
                e.Graphics.DrawString(Text, this.Font, new SolidBrush(ForeColor), new Point(0, 0));
            }
        }

        private void SLabel_Load(object sender, EventArgs e)
        {
           
        }
    }
}
