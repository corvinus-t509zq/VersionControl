
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelNext = new System.Windows.Forms.Label();
            this.buttonColor = new System.Windows.Forms.Button();
            this.buttonPresent = new System.Windows.Forms.Button();
            this.buttonPresentColor1 = new System.Windows.Forms.Button();
            this.buttonPresentColor2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(2, 279);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "CAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(155, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "BALL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelNext
            // 
            this.labelNext.AutoSize = true;
            this.labelNext.Location = new System.Drawing.Point(615, 9);
            this.labelNext.Name = "labelNext";
            this.labelNext.Size = new System.Drawing.Size(101, 20);
            this.labelNext.TabIndex = 2;
            this.labelNext.Text = "Coming next:";
            // 
            // buttonColor
            // 
            this.buttonColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonColor.Location = new System.Drawing.Point(155, 73);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(81, 40);
            this.buttonColor.TabIndex = 0;
            this.buttonColor.UseVisualStyleBackColor = false;
            this.buttonColor.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonPresent
            // 
            this.buttonPresent.Location = new System.Drawing.Point(280, 33);
            this.buttonPresent.Name = "buttonPresent";
            this.buttonPresent.Size = new System.Drawing.Size(110, 34);
            this.buttonPresent.TabIndex = 3;
            this.buttonPresent.Text = "PRESENT";
            this.buttonPresent.UseVisualStyleBackColor = true;
            this.buttonPresent.Click += new System.EventHandler(this.buttonPresent_Click);
            // 
            // buttonPresentColor1
            // 
            this.buttonPresentColor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonPresentColor1.Location = new System.Drawing.Point(280, 73);
            this.buttonPresentColor1.Name = "buttonPresentColor1";
            this.buttonPresentColor1.Size = new System.Drawing.Size(110, 40);
            this.buttonPresentColor1.TabIndex = 4;
            this.buttonPresentColor1.UseVisualStyleBackColor = false;
            this.buttonPresentColor1.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonPresentColor2
            // 
            this.buttonPresentColor2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonPresentColor2.Location = new System.Drawing.Point(280, 119);
            this.buttonPresentColor2.Name = "buttonPresentColor2";
            this.buttonPresentColor2.Size = new System.Drawing.Size(110, 40);
            this.buttonPresentColor2.TabIndex = 5;
            this.buttonPresentColor2.UseVisualStyleBackColor = false;
            this.buttonPresentColor2.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 450);
            this.Controls.Add(this.buttonPresentColor2);
            this.Controls.Add(this.buttonPresentColor1);
            this.Controls.Add(this.buttonPresent);
            this.Controls.Add(this.buttonColor);
            this.Controls.Add(this.labelNext);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer CreateTimer;
        private System.Windows.Forms.Timer ConveyorTimer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelNext;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.Button buttonPresent;
        private System.Windows.Forms.Button buttonPresentColor1;
        private System.Windows.Forms.Button buttonPresentColor2;
    }
}

