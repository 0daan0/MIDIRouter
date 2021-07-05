namespace MIDIRouter
{
    partial class logging
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
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.LoggingWindow = new System.Windows.Forms.RichTextBox();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.LoggingWindow);
            this.groupBox7.Location = new System.Drawing.Point(12, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(979, 759);
            this.groupBox7.TabIndex = 26;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Log";
            // 
            // LoggingWindow
            // 
            this.LoggingWindow.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.LoggingWindow.Location = new System.Drawing.Point(6, 19);
            this.LoggingWindow.Name = "LoggingWindow";
            this.LoggingWindow.ReadOnly = true;
            this.LoggingWindow.Size = new System.Drawing.Size(967, 734);
            this.LoggingWindow.TabIndex = 0;
            this.LoggingWindow.Text = "";
            // 
            // logging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 783);
            this.Controls.Add(this.groupBox7);
            this.Name = "logging";
            this.Text = "logging";
            this.Load += new System.EventHandler(this.logging_Load);
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RichTextBox LoggingWindow;
    }
}