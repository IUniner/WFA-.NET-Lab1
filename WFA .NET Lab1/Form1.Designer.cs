using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace WFA.NET_Lab1
{
    public partial class Form1:Form
    {
        public Form1()
        {
            InitializeComponent();

           // ResultBlock.TextChanged += textBox1_TextChanged;
        }
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
            this.ResultBlock = new System.Windows.Forms.TextBox();
            this.Button_Open = new System.Windows.Forms.Button();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.openBinFile = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // ResultBlock
            // 
            this.ResultBlock.AcceptsReturn = true;
            this.ResultBlock.AcceptsTab = true;
            this.ResultBlock.Location = new System.Drawing.Point(12, 12);
            this.ResultBlock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ResultBlock.Multiline = true;
            this.ResultBlock.Name = "ResultBlock";
            this.ResultBlock.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultBlock.Size = new System.Drawing.Size(611, 232);
            this.ResultBlock.TabIndex = 0;
            // 
            // Button_Open
            // 
            this.Button_Open.Location = new System.Drawing.Point(40, 271);
            this.Button_Open.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Button_Open.Name = "Button_Open";
            this.Button_Open.Size = new System.Drawing.Size(98, 43);
            this.Button_Open.TabIndex = 3;
            this.Button_Open.Text = "Open File";
            this.Button_Open.UseVisualStyleBackColor = true;
            this.Button_Open.Click += new System.EventHandler(this.Button_Open_Click);
            // 
            // saveAsButton
            // 
            this.saveAsButton.Location = new System.Drawing.Point(221, 271);
            this.saveAsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(93, 43);
            this.saveAsButton.TabIndex = 4;
            this.saveAsButton.Text = "Save as";
            this.saveAsButton.UseVisualStyleBackColor = true;
            this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Enabled = false;
            this.closeButton.Location = new System.Drawing.Point(40, 434);
            this.closeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(275, 28);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.UseWaitCursor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // openBinFile
            // 
            this.openBinFile.Location = new System.Drawing.Point(134, 271);
            this.openBinFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.openBinFile.Name = "openBinFile";
            this.openBinFile.Size = new System.Drawing.Size(90, 43);
            this.openBinFile.TabIndex = 6;
            this.openBinFile.Text = "Open Bin File";
            this.openBinFile.UseVisualStyleBackColor = true;
            this.openBinFile.Click += new System.EventHandler(this.openBinFile_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 469);
            this.Controls.Add(this.openBinFile);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveAsButton);
            this.Controls.Add(this.Button_Open);
            this.Controls.Add(this.ResultBlock);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "FolderManager";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ResultBlock;
        private Button Button_Open;
        private Button saveAsButton;
        private Button closeButton;
        private Button openBinFile;
        private FileSystemWatcher fileSystemWatcher1;
    }
}

