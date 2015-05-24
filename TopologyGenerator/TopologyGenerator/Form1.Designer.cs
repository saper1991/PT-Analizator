namespace TopologyGenerator
{
    partial class MainWnd
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
            this.DeleteFileButton = new System.Windows.Forms.Button();
            this.LoadFileButton = new System.Windows.Forms.Button();
            this.listOfFilesListBox = new System.Windows.Forms.ListBox();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DeleteFileButton
            // 
            this.DeleteFileButton.Location = new System.Drawing.Point(238, 73);
            this.DeleteFileButton.Name = "DeleteFileButton";
            this.DeleteFileButton.Size = new System.Drawing.Size(144, 36);
            this.DeleteFileButton.TabIndex = 2;
            this.DeleteFileButton.Text = "Usuń plik";
            this.DeleteFileButton.UseVisualStyleBackColor = true;
            this.DeleteFileButton.Click += new System.EventHandler(this.DeleteFileButton_Click);
            // 
            // LoadFileButton
            // 
            this.LoadFileButton.Location = new System.Drawing.Point(238, 31);
            this.LoadFileButton.Name = "LoadFileButton";
            this.LoadFileButton.Size = new System.Drawing.Size(144, 36);
            this.LoadFileButton.TabIndex = 1;
            this.LoadFileButton.Text = "Wczytaj Plik";
            this.LoadFileButton.UseVisualStyleBackColor = true;
            this.LoadFileButton.Click += new System.EventHandler(this.LoadFileButton_Click);
            // 
            // listOfFilesListBox
            // 
            this.listOfFilesListBox.FormattingEnabled = true;
            this.listOfFilesListBox.Location = new System.Drawing.Point(12, 12);
            this.listOfFilesListBox.Name = "listOfFilesListBox";
            this.listOfFilesListBox.Size = new System.Drawing.Size(208, 329);
            this.listOfFilesListBox.TabIndex = 1;
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(238, 115);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(144, 36);
            this.GenerateButton.TabIndex = 3;
            this.GenerateButton.Text = "Wygeneruj Topologię";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(238, 296);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(144, 36);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Zamknij Program";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 344);
            this.ControlBox = false;
            this.Controls.Add(this.listOfFilesListBox);
            this.Controls.Add(this.DeleteFileButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.LoadFileButton);
            this.Controls.Add(this.GenerateButton);
            this.Name = "MainWnd";
            this.ShowIcon = false;
            this.Text = "Topology Generator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DeleteFileButton;
        private System.Windows.Forms.Button LoadFileButton;
        private System.Windows.Forms.ListBox listOfFilesListBox;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.Button ExitButton;
    }
}

