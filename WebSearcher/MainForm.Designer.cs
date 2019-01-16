namespace WebSearcher
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
            this.urlBox = new System.Windows.Forms.TextBox();
            this.searchedWordsBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.settingsBox = new System.Windows.Forms.GroupBox();
            this.searchedWordsLabel = new System.Windows.Forms.Label();
            this.threadsLabel = new System.Windows.Forms.Label();
            this.countThreadsSpinBox = new System.Windows.Forms.NumericUpDown();
            this.logBox = new System.Windows.Forms.TextBox();
            this.settingsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countThreadsSpinBox)).BeginInit();
            this.SuspendLayout();
            // 
            // urlBox
            // 
            this.urlBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlBox.Location = new System.Drawing.Point(12, 14);
            this.urlBox.Name = "urlBox";
            this.urlBox.Size = new System.Drawing.Size(350, 20);
            this.urlBox.TabIndex = 0;
            // 
            // searchedWordsBox
            // 
            this.searchedWordsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchedWordsBox.Location = new System.Drawing.Point(7, 84);
            this.searchedWordsBox.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.searchedWordsBox.Multiline = true;
            this.searchedWordsBox.Name = "searchedWordsBox";
            this.searchedWordsBox.Size = new System.Drawing.Size(231, 287);
            this.searchedWordsBox.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(493, 12);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(119, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // runButton
            // 
            this.runButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.runButton.Location = new System.Drawing.Point(368, 12);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(119, 23);
            this.runButton.TabIndex = 3;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // settingsBox
            // 
            this.settingsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsBox.Controls.Add(this.searchedWordsLabel);
            this.settingsBox.Controls.Add(this.threadsLabel);
            this.settingsBox.Controls.Add(this.countThreadsSpinBox);
            this.settingsBox.Controls.Add(this.searchedWordsBox);
            this.settingsBox.Location = new System.Drawing.Point(368, 54);
            this.settingsBox.Name = "settingsBox";
            this.settingsBox.Size = new System.Drawing.Size(244, 378);
            this.settingsBox.TabIndex = 4;
            this.settingsBox.TabStop = false;
            this.settingsBox.Text = "Settings";
            // 
            // searchedWordsLabel
            // 
            this.searchedWordsLabel.AutoSize = true;
            this.searchedWordsLabel.Location = new System.Drawing.Point(6, 61);
            this.searchedWordsLabel.Name = "searchedWordsLabel";
            this.searchedWordsLabel.Size = new System.Drawing.Size(196, 13);
            this.searchedWordsLabel.TabIndex = 6;
            this.searchedWordsLabel.Text = "Searched words (enum words by space)";
            // 
            // threadsLabel
            // 
            this.threadsLabel.AutoSize = true;
            this.threadsLabel.Location = new System.Drawing.Point(6, 30);
            this.threadsLabel.Name = "threadsLabel";
            this.threadsLabel.Size = new System.Drawing.Size(46, 13);
            this.threadsLabel.TabIndex = 4;
            this.threadsLabel.Text = "Threads";
            // 
            // countThreadsSpinBox
            // 
            this.countThreadsSpinBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.countThreadsSpinBox.Location = new System.Drawing.Point(118, 28);
            this.countThreadsSpinBox.Name = "countThreadsSpinBox";
            this.countThreadsSpinBox.Size = new System.Drawing.Size(120, 20);
            this.countThreadsSpinBox.TabIndex = 2;
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.Location = new System.Drawing.Point(12, 54);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(342, 371);
            this.logBox.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.settingsBox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.urlBox);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Web Searcher";
            this.settingsBox.ResumeLayout(false);
            this.settingsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countThreadsSpinBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox urlBox;
        private System.Windows.Forms.TextBox searchedWordsBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.GroupBox settingsBox;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Label threadsLabel;
        private System.Windows.Forms.NumericUpDown countThreadsSpinBox;
        private System.Windows.Forms.Label searchedWordsLabel;
    }
}