using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using IWshRuntimeLibrary;
namespace SpotiAppInstaller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class Helper
    {
        public static string currentView = "";
        public struct Margins
        {
            public int Left, Top, Right, Bottom;
        }
        //if Vista enable non-client painting
        /*
        if (Environment.OSVersion.Version.Major > 6)

        {

        User32.DWMNCRENDERINGPOLICY ncrp = 
        User32.DWMNCRENDERINGPOLICY.DWMNCRP_DISABLED;

        User32.DwmSetWindowAttribute(this.Handle, 
        (uint)User32.DWMWINDOWATTRIBUTE.DWMWA_NCRENDERING_ENABLED, (IntPtr)ncrp, 
        (IntPtr)sizeof(int));

        User32.DwmSetWindowAttribute(this.Handle, 
        (uint)User32.DWMWINDOWATTRIBUTE.DWMWA_ALLOW_NCPAINT, IntPtr.Zero, 
        IntPtr.Zero);

        }


        And in library I used:*/
        public enum DWMWINDOWATTRIBUTE
        {

            DWMWA_NCRENDERING_ENABLED = 1, // [get] Is non-client rendering enabled/disabled

            DWMWA_NCRENDERING_POLICY, // [set] Non-client rendering policy DWMWA_TRANSITIONS_FORCEDISABLED, // [set] Potentially enable/forcibly disable transitions

            DWMWA_ALLOW_NCPAINT, // [set] Allow contents rendered in the non-client area to be visible on the DWM-drawn frame.

            DWMWA_CAPTION_BUTTON_BOUNDS, // [get] Bounds of the caption button area in window-relative space.

            DWMWA_NONCLIENT_RTL_LAYOUT, // [set] Is non-client content RTL mirrored

            DWMWA_FORCE_ICONIC_REPRESENTATION, // [set] Force this window to display iconic thumbnails.

            DWMWA_FLIP3D_POLICY, // [set] Designates how Flip3D will treat the window.

            DWMWA_EXTENDED_FRAME_BOUNDS, // [get] Gets the extended frame bounds rectangle in screen space

            DWMWA_LAST

        };

        // Non-client rendering policy attribute values

        public enum DWMNCRENDERINGPOLICY
        {

            DWMNCRP_USEWINDOWSTYLE, // Enable/disable non-client rendering based on window style

            DWMNCRP_DISABLED, // Disabled non-client rendering; window style is ignored
            DWMNCRP_ENABLED, // Enabled non-client rendering; window style is ignored

            DWMNCRP_LAST

        };
       
        [DllImport("user32.dll")]
        public static extern void ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern void SetForegroundWindow(IntPtr Window);
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, uint dwAttribute, IntPtr pvAttribute, IntPtr uhwnd);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint MSG, object wParam, object lParam);
        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        IntPtr Spotify;
        IntPtr ncrp;
        int WS_CAPTION = 12582912;
        int WS_MINIMIZEBOX = 131072;
        int WS_MAXIMIZEBOX = 65536;
        int WS_SYSMENU = 524288;
        int WS_THICKFRAME = 262144;
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int X;
            public int Y;
            public int Width;
            public int Height;
        }
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(int hWnd, ref Margins Mgns);

    }
        private void Form1_Load(object sender, EventArgs e)
        {
            output = new Stack<string>();
        }
   
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            while (output.Count > 0)
            {
                textBox3.Text += output.Pop() + "\n";
            }
            if (Helper.FindWindow("SpotifyMainWindow", null) != 0)
            {
                label5.Visible = true;
                button1.Enabled = false;
            }
            else
            {
                label5.Visible = false;
                button1.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(textBox1.Text+"\\spotify.exe"))
            {
                MessageBox.Show("Correct");
            }

        }
        Stack<String> output;
        private void Install()
        {
            try
            {
                output.Push("Creating SpotiApps directory");

                DirectoryInfo D = Directory.CreateDirectory(textBox2.Text);
                DirectoryInfo InstallationFiles = new DirectoryInfo(Application.StartupPath + "\\SpotiApps");
                output.Push("Copying program files into the installation folder");
            
                foreach (FileInfo R in InstallationFiles.GetFiles())
                {
                    R.CopyTo(D.Name);

                }
                output.Push("Installing SpotiApps together with Spotify");
                using (StreamWriter SW = new StreamWriter(InstallationFiles.FullName+"\\Settings.txt"))
                {
                    SW.WriteLine(textBox1.Text);
                    SW.WriteLine(textBox2.Text);
                    SW.Close();
                }
                FileInfo RP = new FileInfo(InstallationFiles.FullName + "\\spotify.exe");
                RP.CopyTo(InstallationFiles.FullName + "\\SpotifyCore.exe");
                RP.Delete();
                FileInfo RS = new FileInfo(D.FullName + "\\SpofityRuntime.exe");
                RS.CopyTo("C:\\Program Files\\Spotify\\Spotify.exe");
                output.Push("Merged SpotiApps with Spotfy.");
                output.Push("Ready.");

            }


            catch (Exception e)
            {
                output.Push("Error during installation. Error was \n " + e.Message);

            }
        }   
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.TrimEnd('\\');
            textBox2.Text = textBox2.Text.TrimEnd('\\');
        }
    }
}
