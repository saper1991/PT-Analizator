﻿namespace TopologyGenerator
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
            this.clearAllButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DeleteFileButton
            // 
            this.DeleteFileButton.BackColor = System.Drawing.Color.White;
            this.DeleteFileButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.DeleteFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteFileButton.Location = new System.Drawing.Point(24, 175);
            this.DeleteFileButton.Name = "DeleteFileButton";
            this.DeleteFileButton.Size = new System.Drawing.Size(144, 36);
            this.DeleteFileButton.TabIndex = 2;
            this.DeleteFileButton.Text = "Usuń plik";
            this.DeleteFileButton.UseVisualStyleBackColor = false;
            this.DeleteFileButton.Click += new System.EventHandler(this.DeleteFileButton_Click);
            // 
            // LoadFileButton
            // 
            this.LoadFileButton.BackColor = System.Drawing.Color.White;
            this.LoadFileButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.LoadFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadFileButton.Location = new System.Drawing.Point(24, 12);
            this.LoadFileButton.Name = "LoadFileButton";
            this.LoadFileButton.Size = new System.Drawing.Size(144, 36);
            this.LoadFileButton.TabIndex = 1;
            this.LoadFileButton.Text = "Wczytaj dane";
            this.LoadFileButton.UseVisualStyleBackColor = false;
            this.LoadFileButton.Click += new System.EventHandler(this.LoadFileButton_Click);
            // 
            // listOfFilesListBox
            // 
            this.listOfFilesListBox.FormattingEnabled = true;
            this.listOfFilesListBox.Location = new System.Drawing.Point(208, 14);
            this.listOfFilesListBox.Name = "listOfFilesListBox";
            this.listOfFilesListBox.Size = new System.Drawing.Size(208, 329);
            this.listOfFilesListBox.TabIndex = 1;
            // 
            // GenerateButton
            // 
            this.GenerateButton.BackColor = System.Drawing.Color.White;
            this.GenerateButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.GenerateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenerateButton.Location = new System.Drawing.Point(24, 73);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(144, 36);
            this.GenerateButton.TabIndex = 3;
            this.GenerateButton.Text = "Generuj";
            this.GenerateButton.UseVisualStyleBackColor = false;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.White;
            this.ExitButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Location = new System.Drawing.Point(24, 295);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(144, 36);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Zamknij program";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // clearAllButton
            // 
            this.clearAllButton.BackColor = System.Drawing.Color.White;
            this.clearAllButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.clearAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearAllButton.Location = new System.Drawing.Point(24, 236);
            this.clearAllButton.Name = "clearAllButton";
            this.clearAllButton.Size = new System.Drawing.Size(144, 36);
            this.clearAllButton.TabIndex = 5;
            this.clearAllButton.Text = "Wyczyść wszystko";
            this.clearAllButton.UseVisualStyleBackColor = false;
            this.clearAllButton.Click += new System.EventHandler(this.clearAllButton_Click);
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(487, 363);
            this.ControlBox = false;
            this.Controls.Add(this.clearAllButton);
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
        private System.Windows.Forms.Button clearAllButton;
    }
}

