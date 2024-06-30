using System;
using System.Drawing;
using System.Windows.Forms;

namespace projectNotch.notchItems
{
    public class powerItem : Control
    {
        private float batteryPercentage = 0.2f;
        private int charging = 0;
        private SolidBrush brush = new SolidBrush(Color.White);
        private Timer timer = new Timer();
        private int FPS = 60;

        public float BatteryPercentage
        {
            get { return batteryPercentage; }
            set { batteryPercentage = value; Invalidate(); }
        }

        public powerItem()
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
            var b = (SystemInformation.PowerStatus.BatteryLifePercent);
            var c = (SystemInformation.PowerStatus.PowerLineStatus);
            batteryPercentage = b;
            charging = ((int)c);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(BackColor);

            e.Graphics.DrawImage(global::projectNotch.Properties.Resources.battery, 0, 0);

            switch (batteryPercentage)
            {
                case 0.1f:
                    brush = new SolidBrush(Color.Red);
                    break;
                case 0.2f:
                    brush = new SolidBrush(Color.Orange);
                    break;
                case 0.3f:
                    brush = new SolidBrush(Color.Yellow);
                    break;
                case var _ when (batteryPercentage >= 0.4f):
                    brush = new SolidBrush(Color.White);
                    break;
            }

            switch (charging)
            {
                case 1:
                    brush = new SolidBrush(Color.Green);
                    break;
            }

            e.Graphics.FillRectangle(brush, 3, 3, (batteryPercentage * 10), 6);

        }
    }
}
