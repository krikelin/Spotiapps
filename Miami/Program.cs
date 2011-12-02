using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Spofity;
namespace Miami
{
    public class D
    {
    }
    public class MainForm : Form1
    {
        Feed Dw = new Feed();
            
        public override string GetURL()
        {
            return "http://open.spotify.com/user/drsounds/playlist/3MrZBl1UMhBndn3UlBe8xg";
        }
        Home D;
        Browse E;
        public MainForm()
        {
           
            D = new Home();
            E = new Browse(this);
            
            AddSection("Home", D);
            SetActiveSection("Home");
            AddSection("Emotionalizer",E);
            Feed Dx = new Feed();
            Dx.Name = "News";
            AddFeed("Home", "sp:entry", "http://www.spotify.com/se/blog/atom/", 5, new Point(32, 140), "News", A);

         
        }
        public void A(object Sender, EventArgs e)
        {
        }
    }
}
