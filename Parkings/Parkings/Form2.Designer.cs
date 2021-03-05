
namespace Parkings
{
    partial class Form2
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
        private void InitializeComponent()
        {
            this.userControl23 = new Parkings.UserControl2();
            this.userControl22 = new Parkings.UserControl2();
            this.userControl21 = new Parkings.UserControl2();
            this.SuspendLayout();
            // 
            // userControl23
            // 
            this.userControl23.Location = new System.Drawing.Point(243, 12);
            this.userControl23.Name = "userControl23";
            this.userControl23.ParkingLotId = 1;
            this.userControl23.ParkingPositionId = 3;
            this.userControl23.Size = new System.Drawing.Size(100, 200);
            this.userControl23.TabIndex = 2;
            // 
            // userControl22
            // 
            this.userControl22.Location = new System.Drawing.Point(126, 12);
            this.userControl22.Name = "userControl22";
            this.userControl22.ParkingLotId = 1;
            this.userControl22.ParkingPositionId = 2;
            this.userControl22.Size = new System.Drawing.Size(100, 200);
            this.userControl22.TabIndex = 1;
            // 
            // userControl21
            // 
            this.userControl21.BackColor = System.Drawing.SystemColors.Control;
            this.userControl21.Location = new System.Drawing.Point(12, 12);
            this.userControl21.Name = "userControl21";
            this.userControl21.ParkingLotId = 1;
            this.userControl21.ParkingPositionId = 1;
            this.userControl21.Size = new System.Drawing.Size(98, 200);
            this.userControl21.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.userControl23);
            this.Controls.Add(this.userControl22);
            this.Controls.Add(this.userControl21);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "Form2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControl2 userControl21;
        private UserControl2 userControl22;
        private UserControl2 userControl23;
    }
}