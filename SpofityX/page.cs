using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Spofity
{
    public partial class page : UserControl
    {
        public page()
        {
            InitializeComponent();
        }

        private void page_Load(object sender, EventArgs e)
        {

        }

        private void page_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.FromArgb(42,42, 42)), 1, 1, this.Width, 1);
        }
    }
}
