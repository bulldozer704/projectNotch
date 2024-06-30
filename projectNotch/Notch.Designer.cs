using System.Windows.Forms;

namespace projectNotch
{
    partial class Notch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 

        private void InitializeComponent()
        {
            this.timeItem1 = new projectNotch.notchItems.timeItem();
            this.powerItem1 = new projectNotch.notchItems.powerItem();
            this.SuspendLayout();
            // 
            // timeItem1
            // 
            this.timeItem1.BackColor = System.Drawing.Color.Black;
            this.timeItem1.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.timeItem1.Location = new System.Drawing.Point(6, 1);
            this.timeItem1.Name = "timeItem1";
            this.timeItem1.Size = new System.Drawing.Size(40, 12);
            this.timeItem1.TabIndex = 1;
            this.timeItem1.Text = "timeItem1";
            // 
            // powerItem1
            // 
            this.powerItem1.BackColor = System.Drawing.Color.Black;
            this.powerItem1.BatteryPercentage = 1F;
            this.powerItem1.Location = new System.Drawing.Point(134, 3);
            this.powerItem1.Name = "powerItem1";
            this.powerItem1.Size = new System.Drawing.Size(18, 12);
            this.powerItem1.TabIndex = 0;
            this.powerItem1.Text = "powerItem1";
            // 
            // Notch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::projectNotch.Properties.Resources.Notch01thinermag;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(160, 20);
            this.Controls.Add(this.timeItem1);
            this.Controls.Add(this.powerItem1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1, 1);
            this.Name = "Notch";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Notch";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.Load += new System.EventHandler(this.Notch_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Notch_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private notchItems.powerItem powerItem1;
        private notchItems.timeItem timeItem1;
    }
}

