using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Spofity;
namespace Spofity
{
    public partial class frmCheckup : Form
    {
        public Dictionary<string, Form1> forms;
        public frmCheckup(Dictionary<string, Form1> f)
        {
            InitializeComponent();
            forms = f;
            pos += this.app1.Left + this.app1.Width ;
            foreach (KeyValuePair<string, Form1> v in f)
            {
                this.AddAssembly(v.Value, v.Key);
            }
            app1.panel1 = this;
        }
        public frmCheckup()
        {
            InitializeComponent();
        
        }
        string currentButton;
        int pos = 0;
        public void AddAssembly(Form1 Assembly,string Title)
        {
            app d = new app();
            d.Click += new EventHandler(Click);
            d.Tag = (object)Assembly;
           
            
            d.Label = Title;
            d.Width = 120;
            d.Top = app1.Top;
            d.Left =  (pos);
            d.Show();
            d.panel1 = this;
            pos++;
            this.Controls.Add(d);
            pos += d.Width + 10;
        }
        public delegate void SwitchDelegate(object sender,string form);
        public event SwitchDelegate Switch;
        public void Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string,Form1> d in forms)
            {
                d.Value.Hide();
            }
            string fr="";
            Form1 r = (Form1)((app)sender).Tag;
            foreach (KeyValuePair<string, Form1> d in forms)
            {
                if (d.Value == r)
                {
                    fr = d.Key;
                }
            }

            
            
            
            
            Switch(this,fr);
            r.Show();
        }
        private void frmCheckup_Load(object sender, EventArgs e)
        {
            
        }

        private void spotifyButton1_Load(object sender, EventArgs e)
        {
            
        }

        private void spotifyButton1_Click(object sender, EventArgs e)
        {
            foreach (Form1 d in forms.Values)
            {
                d.Hide();
            }
        }

        private void ucPage1_Load(object sender, EventArgs e)
        {

        }

        private void app1_Click(object sender, EventArgs e)
        {

        }

        private void app1_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (Form1 d in this.forms.Values)
            {
                d.Hide();
            }
        }
    }
}
