using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Spofity
{
    public partial class ucPage : UserControl
    {
        public ucPage()
        {
            InitializeComponent();
        }
        private string title;
        public string Title
        {
            get
            {
                return title;

            }
            set
            {
                title = value;
            }
        }
        private void ucSection_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString(title, new Font("MS Sans Serif", 16, FontStyle.Bold), new SolidBrush(Color.FromArgb(188,188,188)), new Point(3, 3));
            e.Graphics.DrawString(title, new Font("MS Sans Serif", 16, FontStyle.Bold), new SolidBrush(Color.FromArgb(70, 70, 70)), new Point(2, 2));
        }

        private void ucSection_Load(object sender, EventArgs e)
        {

        }
    }
}
