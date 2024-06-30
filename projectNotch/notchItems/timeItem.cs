using System;
using System.Drawing;
using System.Windows.Forms;

namespace projectNotch.notchItems
{
    public class timeItem : Control
    {
        private SolidBrush brush = new SolidBrush(Color.White);
        private Timer timer = new Timer();
        private int FPS = 60;

        private string time;

        public timeItem()
        {
            this.BackColor = System.Drawing.Color.Black;
            this.Size = new System.Drawing.Size(18, 12);
            this.DoubleBuffered = true;

            timer.Interval = 1000 / FPS;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var b = DateTime.Now.ToShortTimeString();
            time = b;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(BackColor);

            e.Graphics.DrawString(time, this.Font, brush, 0, 0);
        }
    }
}
