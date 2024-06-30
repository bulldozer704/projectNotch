using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private int FPS = 60;
        private Color backcolor;

        private Timer timer = new Timer();

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
            timer.Interval = 1000 / FPS;

            userPreferenceChanged = new UserPreferenceChangedEventHandler(SystemEvents_UserPreferenceChanged);
            SystemEvents.UserPreferenceChanged += userPreferenceChanged;
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void Notch_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.LWIN);
            }
        }
    }
}
