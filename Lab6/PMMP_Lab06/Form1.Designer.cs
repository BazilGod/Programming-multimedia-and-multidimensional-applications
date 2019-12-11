namespace PMMP_Lab06
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Cam_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Camera_Selection = new System.Windows.Forms.ComboBox();
            this.captureButton = new System.Windows.Forms.Button();
            this.RetrieveBgrFrame = new System.Windows.Forms.CheckBox();
            this.captureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.captureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Cam_lbl
            // 
            this.Cam_lbl.AutoSize = true;
            this.Cam_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cam_lbl.Location = new System.Drawing.Point(10, 23);
            this.Cam_lbl.Name = "Cam_lbl";
            this.Cam_lbl.Size = new System.Drawing.Size(99, 16);
            this.Cam_lbl.TabIndex = 5;
            this.Cam_lbl.Text = "Camera View";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(705, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Camera";
            // 
            // Camera_Selection
            // 
            this.Camera_Selection.FormattingEnabled = true;
            this.Camera_Selection.Location = new System.Drawing.Point(708, 56);
            this.Camera_Selection.Name = "Camera_Selection";
            this.Camera_Selection.Size = new System.Drawing.Size(230, 21);
            this.Camera_Selection.TabIndex = 6;
            // 
            // captureButton
            // 
            this.captureButton.Enabled = false;
            this.captureButton.Location = new System.Drawing.Point(959, 56);
            this.captureButton.Name = "captureButton";
            this.captureButton.Size = new System.Drawing.Size(102, 29);
            this.captureButton.TabIndex = 8;
            this.captureButton.Text = "Start Capture";
            this.captureButton.UseVisualStyleBackColor = true;
            this.captureButton.Click += new System.EventHandler(this.CaptureButton_Click);
            // 
            // RetrieveBgrFrame
            // 
            this.RetrieveBgrFrame.AutoSize = true;
            this.RetrieveBgrFrame.Checked = true;
            this.RetrieveBgrFrame.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RetrieveBgrFrame.Location = new System.Drawing.Point(708, 105);
            this.RetrieveBgrFrame.Name = "RetrieveBgrFrame";
            this.RetrieveBgrFrame.Size = new System.Drawing.Size(117, 17);
            this.RetrieveBgrFrame.TabIndex = 10;
            this.RetrieveBgrFrame.Text = "Retrieve Bgr Frame";
            this.RetrieveBgrFrame.UseVisualStyleBackColor = true;
            // 
            // captureBox
            // 
            this.captureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.captureBox.Location = new System.Drawing.Point(-6, 56);
            this.captureBox.Name = "captureBox";
            this.captureBox.Size = new System.Drawing.Size(708, 893);
            this.captureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.captureBox.TabIndex = 13;
            this.captureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 487);
            this.Controls.Add(this.captureBox);
            this.Controls.Add(this.RetrieveBgrFrame);
            this.Controls.Add(this.captureButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Camera_Selection);
            this.Controls.Add(this.Cam_lbl);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.captureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Cam_lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Camera_Selection;
        private System.Windows.Forms.Button captureButton;
        private System.Windows.Forms.CheckBox RetrieveBgrFrame;
        private System.Windows.Forms.PictureBox captureBox;
    }
}

