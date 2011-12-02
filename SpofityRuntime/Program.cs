using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Xml;
using tessnet2;

namespace Spofity
{
    /// <summary>
    /// This class shall keep the GDI32 APIs used in our program.
    /// </summary>
    public class PlatformInvokeGDI32
    {

        #region Class Variables
        public const int SRCCOPY = 13369376;
        #endregion

        #region Class Functions

        [DllImport("gdi32.dll", EntryPoint = "DeleteDC")]
        public static extern IntPtr DeleteDC(IntPtr hDc);

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        public static extern IntPtr DeleteObject(IntPtr hDc);

        [DllImport("gdi32.dll", EntryPoint = "BitBlt")]
        public static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int
        wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, int RasterOp);

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleBitmap")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);
        #endregion

    }

    /// <summary>
    /// This class shall keep the User32 APIs used in our program.
    /// </summary>
    public class PlatformInvokeUSER32
    {
        #region Class Variables
        public const int SM_CXSCREEN = 0;
        public const int SM_CYSCREEN = 1;
        #endregion

        #region Class Functions
        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll", EntryPoint = "GetDC")]
        public static extern IntPtr GetDC(IntPtr ptr);

        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        public static extern int GetSystemMetrics(int abc);

        [DllImport("user32.dll", EntryPoint = "GetWindowDC")]
        public static extern IntPtr GetWindowDC(Int32 ptr);

        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);

        #endregion
    }

    /// <summary>
    /// This class shall keep all the functionality for capturing the desktop.
    /// </summary>
    public class CaptureScreen
    {

        #region Public Class Functions
        public static Bitmap GetFormImage(IntPtr Form)
        {

            //Variable to keep the handle of the btimap.
            IntPtr m_HBitmap = (IntPtr)0;

            //Variable to keep the refrence to the desktop bitmap.
            System.Drawing.Bitmap bmp = null;

            //In size variable we shall keep the size of the screen.
            SIZE size;

            //Here we get the handle to the desktop device context.
            IntPtr hDC = PlatformInvokeUSER32.GetDC(Form);

            //Here we make a compatible device context in memory for screen device context.
            IntPtr hMemDC = PlatformInvokeGDI32.CreateCompatibleDC(hDC);

            //We pass SM_CXSCREEN constant to GetSystemMetrics to get the X coordinates of screen.
            size.cx = PlatformInvokeUSER32.GetSystemMetrics(PlatformInvokeUSER32.SM_CXSCREEN);

            //We pass SM_CYSCREEN constant to GetSystemMetrics to get the Y coordinates of screen.
            size.cy = PlatformInvokeUSER32.GetSystemMetrics(PlatformInvokeUSER32.SM_CYSCREEN);

            //We create a compatible bitmap of screen size and using screen device context.
            m_HBitmap = PlatformInvokeGDI32.CreateCompatibleBitmap(hDC, size.cx, size.cy);

            //As m_HBitmap is IntPtr we can not check it against null. For this purspose IntPtr.Zero is used.
            if (m_HBitmap != IntPtr.Zero)
            {
                //Here we select the compatible bitmap in memeory device context and keeps the refrence to Old bitmap.
                IntPtr hOld = (IntPtr)PlatformInvokeGDI32.SelectObject(hMemDC, m_HBitmap);

                //We copy the Bitmap to the memory device context.
                PlatformInvokeGDI32.BitBlt(hMemDC, 0, 0, size.cx, size.cy, hDC, 0, 0, PlatformInvokeGDI32.SRCCOPY);

                //We select the old bitmap back to the memory device context.
                PlatformInvokeGDI32.SelectObject(hMemDC, hOld);

                //We delete the memory device context.
                PlatformInvokeGDI32.DeleteDC(hMemDC);

                //We release the screen device context.
                PlatformInvokeUSER32.ReleaseDC(PlatformInvokeUSER32.GetDesktopWindow(), hDC);

                //Image is created by Image bitmap handle and assigned to Bitmap variable.
                bmp = System.Drawing.Image.FromHbitmap(m_HBitmap);

                //Delete the compatible bitmap object. 
                PlatformInvokeGDI32.DeleteObject(m_HBitmap);

                return bmp;
            }
            //If m_HBitmap is null retunrn null.
            return null;
        }
        #endregion
    }

    //This structure shall be used to keep the size of the screen.
    public struct SIZE
    {
        public int cx;
        public int cy;
    }


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
        static System.Windows.Forms.Timer ST = new System.Windows.Forms.Timer();
        static Helper.RECT pos = new Helper.RECT();
        static Helper D = new Helper();
        public static IntPtr Spotify = Helper.FindWindowEx((IntPtr)null, (IntPtr)null, null, "Spotify");
        static Dictionary<string, Form1> views = new Dictionary<string, Form1>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
       
        static string URI = "";
        static Form1 d;
        [STAThread]
        static void Main(string[] args)
        {
            Ds = new Tesseract();
            OutLosning = new System.Windows.Forms.Timer();
            OutLosning.Tick += new EventHandler(OutLosning_Tick);
            OutLosning.Interval = 500;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
       
            d = new Form1();
            URI = args[0];
            InitiateExtensions();
               ST.Tick += new EventHandler(ST_Tick);
               ST.Interval = 1;
               ST.Start();
            Application.Run(new Form());

        }

        static void OutLosning_Tick(object sender, EventArgs e)
        {
            DSM();
            OutLosning.Stop();
        }
        static System.Windows.Forms.Timer OutLosning;
        static Form1 FetchView(string Value)
        {
            Form1 D = new Form1(Value);

            return D;
        }
        static string currentView = "";
        static void GetView(string View)
        {
            currentView = null;

            if (views.ContainsKey(View))
            {
                currentView = View;
                if (!views[View].Visible)
                    views[View].Visible = true;
                views[View].Tag = (object)View;
                currentView = View;
                CurrentForm = views[View];
                return;
            }
            else
            {
                /*   Form1 D = FetchView(View);
               
                   if (D.hasContent)
                   {
                       CurrentForm = D;
                       views.Add(View, D);
                       if (!views[View].Visible)
                       views[View].Visible = true;
                       views[View].Tag = (object)View;
                       currentView = View;
                       return;
                   }*/



            }
            currentView = null;


        }
        static Form CurrentForm;
        static int x;
        static Tesseract Ds;
        static void InitiateExtensions()
        {
            DirectoryInfo A = new DirectoryInfo((Application.LocalUserAppDataPath + "\\plugins"));

            d.Tag = (object)"Test";
            views.Add("Test", d);
            d.Show();
            foreach (FileInfo Fil in A.GetFiles("*.dll"))
            {
                try
                {
                    if (File.Exists(Fil.FullName.Replace(".dll", ".pdb")))
                    {
                        string AssemblyName = Fil.Name.Replace(".dll", "");

                        Assembly Asm = (Assembly)Assembly.LoadFile(Fil.FullName);



                        Form1 Extension = (Form1)Asm.CreateInstance(AssemblyName + ".MainForm");
                        Extension.Tag = (string)Extension.GetURL();

                        views.Add((string)Extension.Tag, Extension);
                    }
                }
                catch
                {
                }


            }

            foreach (FileInfo Fil in A.GetFiles("*.adress"))
            {
                try
                {

                    using (StreamReader SR = new StreamReader(Fil.Name))
                    {
                        string D = SR.ReadToEnd();
                        string[] f = D.Split(';');
                        adresses.Add(f[0], f[1]);
                    }
                }
                catch
                {
                }


            }
            
        }
        static int y = 0;
        static void DSM()
        {

            Spotify = Helper.FindWindowEx((IntPtr)null, (IntPtr)null, "SpotifyMainWindow", null);
            Helper.GetWindowRect(Spotify, ref pos);

            pos = new Helper.RECT();
            Form1 Form = d;

            Bitmap R = CaptureScreen.GetFormImage(Spotify);
            x = 0;


            int start = 22;
            int end = 302;

        
            for (x = start; x < end; x++)
            {
                Color D = R.GetPixel(x, 114);
                if (D.R == 41 && D.G == 41 && D.B == 41)
                {
                    break;
                }
            }

            // Rectangle Range = new Rectangle(new Point( 290 + x - 120, 75), new Size(200, 45));
            // Bitmap Dc = new Bitmap(R, new Size(R.Width, R.Height));
            /**
             * This idea born by physical excercise !
             * */
            if (Helper.GetForegroundWindow() == Spotify)
            {
              
               foreach(Form1 _Form in views.Values)
               {
                   if ((string)_Form.Tag == currentView)
                   {

                        _Form.TopMost = Helper.GetForegroundWindow() == Spotify;
                        if (!_Form.Visible)
                        {
                     //       _Form.Show();
                        }
                        if (Helper.GetWindowRect(Spotify, ref pos) > 0)
                        {
                            try
                            {
                                int lend = pos.Width - 30;
                                for (y = 31; y > -300; y--)
                                {
                                    Color D = R.GetPixel(pos.Width - 1 + y, 114);
                                    if (D.R == 41 && D.G == 41 && D.B == 41)
                                    {
                                        break;
                                    }
                                }
                                _Form.Left = pos.X + 236 + x - 235;
                                _Form.Top = pos.Y + 56;
                          //      _Form.Width = pos.Width - pos.X - 236 - x + 235 + y - 1;
                                _Form.Height = pos.Height - pos.Y - 56 - 41;
                            }
                            catch
                            {
                            }

                        }


                    }
                    else
                    {
                //        _Form.Visible = false;
                    }



                }
                
              
            }
            




        }
        static Dictionary<string, string> adresses;
        static bool mouseDown = false;
        static void ST_Tick(object sender, EventArgs e)
        {
            //currentView = "Test";
            Helper.GetWindowRect(Spotify, ref pos);
            foreach (Form1 _Form in views.Values)
            {
                if ((string)_Form.Tag == currentView)
                {
                 /*   if (!_Form.Visible)
                    {
                        _Form.Show();
                    }*/

                    _Form.TopMost = Helper.GetForegroundWindow() == Spotify;

                    if (Helper.GetWindowRect(Spotify, ref pos) > 0)
                    {

                        _Form.Left = pos.X + 236 + x - 235;
                        _Form.Top = pos.Y + 56;
                        _Form.Width = pos.Width - pos.X - 236 - x + 235 + y - 1;
                        _Form.Height = pos.Height - pos.Y - 56 - 41;


                    }

                }
                else
                {
           //         _Form.Visible = false;
                }



            }
            // TODO: Listen to messages and interop DSM();


           
            if (/*(System.Windows.Forms.Control.MousePosition.X  < pos.X + 320 && System.Windows.Forms.Control.MousePosition.X  > pos.X */
                System.Windows.Forms.Control.MouseButtons == MouseButtons.Left)
            {
                DSM();
              

                
            }
            if (((System.Windows.Forms.Control.MouseButtons & MouseButtons.Left) != MouseButtons.Left) && mouseDown)
            {
                try
                {
                    Thread.Sleep(130);
                    object Contents = Clipboard.ContainsText() ? Clipboard.GetDataObject() : null;
                    
                    WindowsInput.InputSimulator.SimulateKeyDown(WindowsInput.VirtualKeyCode.CONTROL);
                    WindowsInput.InputSimulator.SimulateKeyDown(WindowsInput.VirtualKeyCode.VK_C);
                    Thread.Sleep(10);
                    currentView = Clipboard.GetText(TextDataFormat.Text);
                    WindowsInput.InputSimulator.SimulateKeyUp(WindowsInput.VirtualKeyCode.VK_C);
                    WindowsInput.InputSimulator.SimulateKeyUp(WindowsInput.VirtualKeyCode.CONTROL);
                    DirectoryInfo A = new DirectoryInfo((Application.LocalUserAppDataPath + "\\plugins"));
                   
                }
                catch
                {
                }
                foreach (Form1 _Form in views.Values)
                {
                    if ((string)_Form.Tag == currentView)
                    {

                        _Form.TopMost = Helper.GetForegroundWindow() == Spotify;

                        _Form.Show();

                        if (Helper.GetWindowRect(Spotify, ref pos) > 0)
                        {
                            try
                            {
                                Bitmap R = CaptureScreen.GetFormImage(Spotify);
                                int lend = pos.Width - 30;
                                for (y = 1; y > -300; y--)
                                {
                                    Color D = R.GetPixel(pos.Width - 1 + y, 114);
                                    if (D.R == 41 && D.G == 41 && D.B == 41)
                                    {
                                        break;
                                    }
                                }
                                _Form.Left = pos.X + 236 + x - 235;
                                _Form.Top = pos.Y + 56;
                                _Form.Width = pos.Width - pos.X - 236 - x + 235 + y - 1;
                                _Form.Height = pos.Height - pos.Y - 56 - 41;
                            }
                            catch
                            {
                            }

                        }


                    }
                    else
                    {
                        _Form.Visible = false;
                    }



                }
                mouseDown = false;
            }
            else
            {
            }
            if (/*(System.Windows.Forms.Control.MousePosition.X  < pos.X + 320 && System.Windows.Forms.Control.MousePosition.X  > pos.X */
                System.Windows.Forms.Control.MouseButtons == MouseButtons.Left)
            {

                mouseDown = true;
                
            }
        }
        
    }
    
}