namespace ImageRecognitionApp
{
    partial class MainForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AlgorithmSelectBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.StartImageProcessingButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ImageResultsPanel = new System.Windows.Forms.Panel();
            this.LoadImageButton = new System.Windows.Forms.Button();
            this.LoadVideoButton = new System.Windows.Forms.Button();
            this.saveImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(318, 574);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add algorithm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 729);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1817, 50);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // AlgorithmSelectBox
            // 
            this.AlgorithmSelectBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AlgorithmSelectBox.FormattingEnabled = true;
            this.AlgorithmSelectBox.Location = new System.Drawing.Point(12, 574);
            this.AlgorithmSelectBox.Name = "AlgorithmSelectBox";
            this.AlgorithmSelectBox.Size = new System.Drawing.Size(300, 21);
            this.AlgorithmSelectBox.TabIndex = 0;
            this.AlgorithmSelectBox.Text = "-";
            this.AlgorithmSelectBox.SelectedIndexChanged += new System.EventHandler(this.AlgorithmSelectBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 607);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1817, 122);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image processing algorithm parameters";
            // 
            // StartImageProcessingButton
            // 
            this.StartImageProcessingButton.Location = new System.Drawing.Point(1416, 574);
            this.StartImageProcessingButton.Name = "StartImageProcessingButton";
            this.StartImageProcessingButton.Size = new System.Drawing.Size(395, 23);
            this.StartImageProcessingButton.TabIndex = 0;
            this.StartImageProcessingButton.Text = "Start processing";
            this.StartImageProcessingButton.UseVisualStyleBackColor = true;
            this.StartImageProcessingButton.Click += new System.EventHandler(this.StartImageProcessingButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.ImageResultsPanel);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1817, 543);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Results";
            // 
            // ImageResultsPanel
            // 
            this.ImageResultsPanel.AutoScroll = true;
            this.ImageResultsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ImageResultsPanel.Location = new System.Drawing.Point(3, 16);
            this.ImageResultsPanel.Name = "ImageResultsPanel";
            this.ImageResultsPanel.Size = new System.Drawing.Size(1811, 524);
            this.ImageResultsPanel.TabIndex = 0;
            // 
            // LoadImageButton
            // 
            this.LoadImageButton.Location = new System.Drawing.Point(12, 545);
            this.LoadImageButton.Name = "LoadImageButton";
            this.LoadImageButton.Size = new System.Drawing.Size(146, 23);
            this.LoadImageButton.TabIndex = 0;
            this.LoadImageButton.Text = "Load image";
            this.LoadImageButton.UseVisualStyleBackColor = true;
            this.LoadImageButton.Click += new System.EventHandler(this.LoadImageButton_Click);
            // 
            // LoadVideoButton
            // 
            this.LoadVideoButton.Location = new System.Drawing.Point(164, 545);
            this.LoadVideoButton.Name = "LoadVideoButton";
            this.LoadVideoButton.Size = new System.Drawing.Size(146, 23);
            this.LoadVideoButton.TabIndex = 10;
            this.LoadVideoButton.Text = "Load video";
            this.LoadVideoButton.UseVisualStyleBackColor = true;
            this.LoadVideoButton.Click += new System.EventHandler(this.LoadVideoButton_Click);
            // 
            // saveImageDialog
            // 
            this.saveImageDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveImageDialog_FileOk);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1817, 779);
            this.Controls.Add(this.LoadVideoButton);
            this.Controls.Add(this.LoadImageButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.StartImageProcessingButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.AlgorithmSelectBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "Image processing and object detection app";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox AlgorithmSelectBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button StartImageProcessingButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel ImageResultsPanel;
        private System.Windows.Forms.Button LoadImageButton;
        private System.Windows.Forms.Button LoadVideoButton;
        private System.Windows.Forms.SaveFileDialog saveImageDialog;
    }
}

