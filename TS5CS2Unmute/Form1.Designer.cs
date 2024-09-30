namespace TS5CS2Unmute
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            labelStatus = new Label();
            labelCS2File = new Label();
            buttonAssign = new Button();
            toolTipAssign = new ToolTip(components);
            buttonGSIDownload = new Button();
            SuspendLayout();
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(12, 9);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(167, 15);
            labelStatus.TabIndex = 0;
            labelStatus.Text = "Not Conntected to Teamspeak";
            // 
            // labelCS2File
            // 
            labelCS2File.AutoSize = true;
            labelCS2File.Location = new Point(12, 24);
            labelCS2File.Name = "labelCS2File";
            labelCS2File.Size = new Size(0, 15);
            labelCS2File.TabIndex = 1;
            // 
            // buttonAssign
            // 
            buttonAssign.Location = new Point(618, 9);
            buttonAssign.Name = "buttonAssign";
            buttonAssign.Size = new Size(170, 23);
            buttonAssign.TabIndex = 2;
            buttonAssign.Text = "Assign Hotkey in 5 Seconds";
            buttonAssign.UseVisualStyleBackColor = true;
            buttonAssign.Click += buttonAssign_Click;
            // 
            // buttonGSIDownload
            // 
            buttonGSIDownload.Location = new Point(12, 42);
            buttonGSIDownload.Name = "buttonGSIDownload";
            buttonGSIDownload.Size = new Size(253, 23);
            buttonGSIDownload.TabIndex = 3;
            buttonGSIDownload.Text = "Download Game State Integration File";
            buttonGSIDownload.UseVisualStyleBackColor = true;
            buttonGSIDownload.Click += buttonGSIDownload_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonGSIDownload);
            Controls.Add(buttonAssign);
            Controls.Add(labelCS2File);
            Controls.Add(labelStatus);
            Name = "Form1";
            Text = "Teamspeak 5 CS2 Auto Unmute";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelStatus;
        private Label labelCS2File;
        private Button buttonAssign;
        private ToolTip toolTipAssign;
        private Button buttonGSIDownload;
    }
}
