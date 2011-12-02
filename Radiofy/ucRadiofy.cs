using System;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Net;
using Spofity;
using SpofityRuntime;
namespace Radiofy
{

    public partial class Form2 : UserControl
    {
        public Radiofy.Form2 host;
        public List<string> bannedSpots;
        public class Show
        {
            private string name;

            private Uri uri;
            public Uri URI
            {
                get
                {
                    return uri;
                }
                set
                {
                    uri = value;
                }
            }
            public Show(Uri ur)
            {
                uri = ur;
            }
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }

            }
        }
        public Stack<Show> upcomingShows;
        public class Feed
        {
            Form2 host;
            public Feed(Form2 host)
            {
                this.host = host;
            }
            private DateTime hour;
            public DateTime Hour
            {
                get
                {
                    return hour;
                }
                set
                {
                    hour = value;
                }
            }
            private int day = 0;
            public int Day
            {
                get
                {
                    return day;
                }
                set
                {
                    day = value;
                }
            }
            public bool Backyard
            {
                get
                {
                    return backyard;
                }
                set
                {
                    backyard = value;
                }
            }
            bool backyard = false;
            public Show FetchLatest()
            {

                XmlDocument N = new XmlDocument();
                N.Load(uri.ToString());

                /*   if (lastHeadline != currentHeadline)
                   {
                   
                      Show D = new Show(new Uri(N.GetElementsByTagName("enclosure")[N.GetElementsByTagName("enclosure").Count - 1].Attributes["url"].Value));
                      lastHeadline = currentHeadline;
                      return D;
                   }*/
                var length = N.GetElementsByTagName("item").Count;
                int x = 0;
                foreach (XmlElement Item in N.GetElementsByTagName("item"))
                {
                    if (x == 0 || x == length - 1)
                    {
                        string currentHeadline = Item.GetElementsByTagName("title")[0].InnerText;
                        if (firstHeadline != currentHeadline)
                        {
                            try
                            {

                                Show D = new Show(new Uri(Item.GetElementsByTagName("enclosure")[0].Attributes["url"].Value));
                                D.Name = currentHeadline;
                                firstHeadline = currentHeadline;
                                DateTime R = DateTime.Parse(Item.GetElementsByTagName("pubDate")[0].InnerText);

                                TimeSpan Diff = DateTime.Now.Subtract(Hour);
                                TimeSpan Piff = DateTime.Now.Subtract(R);
                                int Day = (int)R.DayOfWeek;
                                bool isToday = R.Day == DateTime.Now.Day && R.Year == DateTime.Now.Year && R.Month == DateTime.Now.Month;
                                if (Diff.TotalMinutes <= 30 && Diff.TotalMinutes >= -30 && !host.bannedSpots.Exists(i => D.URI.ToString() == i) && ((Math.Round(Piff.TotalDays) - Day) == day))
                                {
                                    host.bannedSpots.Add(D.URI.ToString());
                                    return D;
                                }
                            }
                            catch
                            {
                                return null;
                            }
                        }
                    }
                    x++;
                }
                return null;
            }


            private string name;
            private Uri uri;
            private string lastHeadline;
            public string LastHeadline
            {
                get
                {
                    return lastHeadline;
                }
                set
                {
                    lastHeadline = value;
                }
            }
            private string firstHeadline;
            public string FirstHeadline
            {
                get
                {
                    return firstHeadline;
                }
                set
                {
                    firstHeadline = value;
                }
            }
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            public Uri Uri
            {
                get
                {
                    return uri;
                }
                set
                {
                    uri = value;
                }
            }


        }
        private Dictionary<string, Feed> feeds;
        public Dictionary<string, Feed> Feeds
        {
            get
            {
                return feeds;
            }
            set
            {
                feeds = value;
            }
        }
        private Form1 currentPage;
        private void goBack()
        {
            if (form1l.Pop() != null)
            {
                this.currentPage.Visible = false;
                form1r.Push(currentPage);
                currentPage = form1l.Pop();
                currentPage.Show();
            }


        }
        private void goForward()
        {
            if (form1r.Pop() != null)
            {
                this.currentPage.Visible = false;
                form1l.Push(currentPage);
                currentPage = form1r.Pop();
                currentPage.Show();
            }


        }
        private Stack<Form1> form1l;
        public Stack<Form1> Form1L
        {
            get
            {
                return form1l;
            }
            set
            {
                form1l = value;
            }
        }
        private Stack<Form1> form1r;
        public Stack<Form1> Form1R
        {
            get
            {
                return form1r;
            }
            set
            {
                form1r = value;
            }
        }
        public Form2()
        {
            InitializeComponent();
            form1l = new Stack<Form1>();
            form1r = new Stack<Form1>();
            feeds = new Dictionary<string, Feed>();
            bannedSpots = new List<string>();
        }
        public Panel ContentPanel
        {
            get
            {
                /*  return this.splitContainer1.Panel2;*/
                return null;
            }
        }
        public void AddFeed(string URI)
        {
            Feed A = new Feed(this);
            A.Uri = new Uri(URI);
            A.LastHeadline = "";

        }
        public AxWMPLib.AxWindowsMediaPlayer player
        {
            get
            {
                return axWindowsMediaPlayer1;
            }
        }
        public void Next()
        {

            string stream = "";
            stream += "IfWinExist, Spotify \n";
            stream += "{\n";
            stream += " ControlSend, , ^{right},Spotify \n";
            stream += "}";
            using (StreamWriter SW = new StreamWriter("C:\\control"))
            {
                SW.Write(stream);
                SW.Close();
            }
            Process.Start(Application.ExecutablePath + "\\AutoHotKey\\AutoHotKey.Exe", "C:\\control");

        }
        public void Pause()
        {

            string stream = "";

            stream += "ControlSend, ahk_parent, {Space}, ahk_class SpotifyMainWindow \n";

            using (StreamWriter SW = new StreamWriter("C:\\control", false))
            {
                SW.Write(stream);
                SW.Close();
            }
            string r = Application.ExecutablePath.Replace("\\Spofity.EXE", "");
            Process.Start(r + "\\AutoHotKey\\AutoHotKey.Exe", "C:\\control");

        }
        string currentSong = "";
        bool loaded = false;
        private Show currentShow;
        private void Form2_Load(object sender, EventArgs e)
        {


            upcomingShows = new Stack<Show>();
            LoadFile();

        }
        private void SaveFile(string Text)
        {
            using (StreamWriter SR = new StreamWriter(Application.UserAppDataPath + "\\feeds.csv", false))
            {

                SR.Write(Text);
                SR.Close();
            }
            LoadFile();
        }
        private void LoadFile()
        {
            Feeds = new Dictionary<string, Feed>();

            if (!File.Exists(Application.UserAppDataPath + "\\feeds.csv"))
            {

                using (StreamWriter SR = new StreamWriter(Application.UserAppDataPath + "\\feeds.csv"))
                {
                    SR.WriteLine("");
                    SR.Close();
                }
            }
            try
            {
                using (StreamReader SR = new StreamReader(Application.UserAppDataPath + "\\feeds.csv"))
                {
                    String S;
                    while ((S = SR.ReadLine()) != null)
                    {
                        if (S != "")
                        {
                            string[] dr = S.Split(';');

                            Feed R = new Feed(this) { Uri = new Uri(dr[1]) };
                            DateTime MR;
                            if (DateTime.TryParse(dr[0], out MR))
                                R.Hour = MR;
                            int days = 0;
                            if (int.TryParse(dr[2], out days))
                                R.Day = days;

                            Feeds.Add(S, R);
                        }
                    }
                }
            }
            catch
            {

            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void spotifyButton1_Load(object sender, EventArgs e)
        {

        }

        private void spotifyButton1_Click(object sender, EventArgs e)
        {
            try
            {
                /*     Form1 D = new Form1(comboBox1.Text);
                     this.currentPage = D;
                     D.Dock = DockStyle.Fill;
                     D.Show();
                     this.ContentPanel.Controls.Add(D);*/
            }
            catch
            {
            }
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowTextLength(IntPtr hWnd);
        public static string GetText(IntPtr hWnd)
        {
            // Allocate correct string length first
            int length = Form2.GetWindowTextLength(hWnd);
            StringBuilder sb = new StringBuilder(length + 1);
            GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }
        private void GetSpotify()
        {

        }
        Thread SecondThread;
        bool pending = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GetText(Program.Spotify) != "Spotify")
                currentSong = GetText(Program.Spotify);
            if (!pending)
            {

                label3.Text = "Fetching";
                if (SecondThread == null)
                {

                    SecondThread = new Thread(new ThreadStart(Update));
                }
                if (SecondThread.ThreadState != System.Threading.ThreadState.Running)
                {
                    try
                    {
                        SecondThread.Start();
                    }
                    catch
                    {
                        if (SecondThread.ThreadState == System.Threading.ThreadState.Stopped)
                        {
                            SecondThread = new Thread(Update);
                            SecondThread.Start();
                        }
                    }
                }
                else
                {
                    label3.Text = "Ready";
                }


            }
            else
            {
                if (GetText(Program.Spotify) != "Spotify")
                {
                    pending = false;
                    currentSong = GetText(Program.Spotify);

                }
            }
            lNextShow.Text = "Spotify Music Session";
            foreach (Show d in upcomingShows)
            {
                lNextShow.Text = d.Name;
                break;
            }
            if (currentShow != null)
            {
                this.lCurShow.Text = currentShow.Name;
            }
            else
            {
                this.lCurShow.Text = "Spotify Music Session";
            }

        }
        private void Update()
        {
            foreach (Feed a in Feeds.Values)
            {
                Show D = a.FetchLatest();
                if (D != null)
                {
                    upcomingShows.Push(D);

                }
            }

        }
        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {

        }
        string megaraSong = "";
        private void axWindowsMediaPlayer1_StatusChange(object sender, EventArgs e)
        {
            if (!pending)
            {
                if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
                {
                    if (GetText(Program.Spotify) == "Spotify")
                    {
                        if (!checkBox1.Checked)
                        {
                            try
                            {
                                Show d = upcomingShows.Pop();
                                axWindowsMediaPlayer1.URL = d.URI.ToString();
                                currentSong = GetText(Program.Spotify);
                            }
                            catch
                            {

                                Pause();
                                currentSong = GetText(Program.Spotify);



                            }
                        }
                        else
                        {
                            Pause();
                            currentSong = GetText(Program.Spotify);
                        }

                    }

                }
            }
        }

        private void axWindowsMediaPlayer1_EndOfStream(object sender, AxWMPLib._WMPOCXEvents_EndOfStreamEvent e)
        {

        }

        private void axWindowsMediaPlayer1_MediaChange(object sender, AxWMPLib._WMPOCXEvents_MediaChangeEvent e)
        {

        }

        private void axWindowsMediaPlayer1_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {


            if (!pending)
            {

                if (GetText(Program.Spotify) != currentSong && GetText(Program.Spotify) != "Spotify" && currentSong != "Spotify")
                {
                    try
                    {
                        if (upcomingShows.Peek() != null)
                        {
                            megaraSong = GetText(Program.Spotify);
                            Show d = upcomingShows.Pop();
                            Pause();


                            axWindowsMediaPlayer1.URL = d.URI.ToString();
                            currentSong = GetText(Program.Spotify);
                        }
                    }
                    catch
                    {

                    }

                }
            }

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void spotifyPanel2_Load(object sender, EventArgs e)
        {

        }
    }
}
