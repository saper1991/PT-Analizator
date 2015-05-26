namespace TopologyGenerator
{
    partial class TopologyWnd
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TopologyPBox = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.screenCaptureButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopologyPBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox1.Controls.Add(this.TopologyPBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(651, 346);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "wygenerowana topologia";
            // 
            // TopologyPBox
            // 
            this.TopologyPBox.BackColor = System.Drawing.Color.White;
            this.TopologyPBox.Location = new System.Drawing.Point(17, 25);
            this.TopologyPBox.Name = "TopologyPBox";
            this.TopologyPBox.Size = new System.Drawing.Size(618, 310);
            this.TopologyPBox.TabIndex = 0;
            this.TopologyPBox.TabStop = false;
            this.TopologyPBox.Paint += new System.Windows.Forms.PaintEventHandler(this.TopologyPBox_Paint);
            this.TopologyPBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopologyPBox_MouseDown);
            this.TopologyPBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopologyPBox_MouseMove);
            this.TopologyPBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TopologyPBox_MouseUp);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.White;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CloseButton.Location = new System.Drawing.Point(486, 375);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(162, 29);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "zamknij okno";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // screenCaptureButton
            // 
            this.screenCaptureButton.BackColor = System.Drawing.Color.White;
            this.screenCaptureButton.FlatAppearance.BorderSize = 0;
            this.screenCaptureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.screenCaptureButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.screenCaptureButton.Location = new System.Drawing.Point(30, 375);
            this.screenCaptureButton.Name = "screenCaptureButton";
            this.screenCaptureButton.Size = new System.Drawing.Size(162, 29);
            this.screenCaptureButton.TabIndex = 2;
            this.screenCaptureButton.Text = "zapisz jako obraz";
            this.screenCaptureButton.UseVisualStyleBackColor = false;
            this.screenCaptureButton.Click += new System.EventHandler(this.screenCaptureButton_Click);
            // 
            // TopologyWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(675, 416);
            this.ControlBox = false;
            this.Controls.Add(this.screenCaptureButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "TopologyWnd";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TopologyPBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox TopologyPBox;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button screenCaptureButton;
    }
}