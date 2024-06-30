using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace projectNotch
{
    public partial class Notch : Form
    { 
        private UserPreferenceChangedEventHandler userPreferenceChanged;
        private InputSimulator inputSimulator = new InputSimulator();
        private Color backcolor;

        public Notch()
        {
            InitializeComponent();
        }

        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            if (e.Category == UserPreferenceCategory.General || e.Category == UserPreferenceCategory.VisualStyle)
            {
                updatecolor();
            }
        }

        private void updatecolor()
        {
            backcolor = WinTheme.GetAccentColor();

            this.BackColor = backcolor;
        }

        private void Notch_Load(object sender, EventArgs e)
        {
            updatecolor();
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2), 0);

            userPreferenceChanged = new UserPreferenceChangedEventHandler(SystemEvents_UserPreferenceChanged);
            SystemEvents.UserPreferenceChanged += userPreferenceChanged;

            ExtendedWindowStyles.MakeWindowTopMost(this);
            ExtendedWindowStyles.MakeToolWindow(this);
        }

        private void Notch_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.LWIN);
            }
        }
    }

    public class ExtendedWindowStyles
    {
        // Import user32.dll for SetWindowLong and GetWindowLong
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOACTIVATE = 0x0010;
        private const uint SWP_SHOWWINDOW = 0x0040;

        // Constants for GetWindowLong/SetWindowLong
        private const int GWL_EXSTYLE = -20;

        // Extended window styles
        private const int WS_EX_TOPMOST = 0x00000008;
        private const int WS_EX_NOACTIVE = 0x08000000;
        private const int WS_EX_TOOLWINDOW = 0x00000080;

        public static void MakeWindowTopMost(Form form)
        {
            // Get the current extended style
            int exStyle = GetWindowLong(form.Handle, GWL_EXSTYLE);

            // Modify the extended style to add WS_EX_TOPMOST
            exStyle |= WS_EX_TOPMOST;

            int result = SetWindowLong(form.Handle, GWL_EXSTYLE, exStyle);

            if (result == 0)
            {
                int error = Marshal.GetLastWin32Error();
                MessageBox.Show($"Error setting window style: {error}");
            }

            // Set the new extended style
            SetWindowPos(form.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE | SWP_SHOWWINDOW);
        }

        public static void MakeToolWindow(Form form)
        {
            // Get the current extended style
            int exStyle = GetWindowLong(form.Handle, GWL_EXSTYLE);

            // Modify the extended style to add WS_EX_TOPMOST
            exStyle |= WS_EX_TOOLWINDOW;

            // Set the new extended style
            SetWindowLong(form.Handle, GWL_EXSTYLE, exStyle);
        }
    }
}
