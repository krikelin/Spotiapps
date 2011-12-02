using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace Spofity
{
    public class Helper
    {
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
    static class Program
    {
        static string GetURI()
        {
            return "";
        }
        static Timer ST = new Timer();
        static Helper.RECT pos = new Helper.RECT();
        static Helper D = new Helper();
        public static IntPtr Spotify = Helper.FindWindowEx((IntPtr)null, (IntPtr)null, null, "Spotify");
        static List<Form1> views = new List<Form1>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        static string URI = "";
        static Form1 d;
        [STAThread]
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);

            d = new Form1(args[0], "");
            URI = args[0];
            views.Add(d);
            ST.Tick += new EventHandler(ST_Tick);
            ST.Interval = 1;
            ST.Start();
            Application.Run(d);


        }

        static void ST_Tick(object sender, EventArgs e)
        {
            /*   Spotify = Helper.FindWindowEx((IntPtr)null, (IntPtr)null, null, "Spotify");
            
               pos = new Helper.RECT();
               Form1 Form = d;
               
                 
                       Form.TopMost = Helper.GetForegroundWindow() == Spotify;
                    
                       if (Helper.GetWindowRect(Spotify, ref pos)>0)
                       {
                           Form.Left = pos.X + 236;
                           Form.Top = pos.Y + 56;
                           Form.Width = pos.Width - pos.X - 236;
                           Form.Height = pos.Height - pos.Y - 56 - 41;


                       }
                
                
                

              */

        }
    }
}