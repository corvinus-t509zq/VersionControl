
namespace Mikulas
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.CreateTimer = new System.Windows.Forms.Timer(this.components);
            this.ConveyorTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(-5, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(985, 172);
            this.mainPanel.TabIndex = 0;
            // 
            // CreateTimer
            // 
            this.CreateTimer.Enabled = true;
            this.CreateTimer.Interval = 3000;
            this.CreateTimer.Tick += new System.EventHandler(this.CreateTimer_Tick);
            // 
            // ConveyorTimer
            // 
            this.ConveyorTimer.Enabled = true;
            this.ConveyorTimer.Interval = 10;
            this.ConveyorTimer.Tick += new System.EventHandler(this.ConveyorTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 450);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer CreateTimer;
        private System.Windows.Forms.Timer ConveyorTimer;
    }
}

