namespace FilterAdmin {
    partial class Admin {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.labelHashTag = new System.Windows.Forms.Label();
            this.textBoxHashtag = new System.Windows.Forms.TextBox();
            this.textBoxHuidig = new System.Windows.Forms.TextBox();
            this.labelNaar = new System.Windows.Forms.Label();
            this.labelUitleg = new System.Windows.Forms.Label();
            this.buttonOpslaan = new System.Windows.Forms.Button();
            this.buttonDirectory = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dataGridViewWoorden = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelFolder = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWoorden)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHashTag
            // 
            this.labelHashTag.AutoSize = true;
            this.labelHashTag.Location = new System.Drawing.Point(15, 55);
            this.labelHashTag.Name = "labelHashTag";
            this.labelHashTag.Size = new System.Drawing.Size(140, 13);
            this.labelHashTag.TabIndex = 0;
            this.labelHashTag.Text = "Verander hashtag (bv useit):";
            // 
            // textBoxHashtag
            // 
            this.textBoxHashtag.Enabled = false;
            this.textBoxHashtag.Location = new System.Drawing.Point(386, 48);
            this.textBoxHashtag.Name = "textBoxHashtag";
            this.textBoxHashtag.Size = new System.Drawing.Size(118, 20);
            this.textBoxHashtag.TabIndex = 1;
            // 
            // textBoxHuidig
            // 
            this.textBoxHuidig.Enabled = false;
            this.textBoxHuidig.Location = new System.Drawing.Point(177, 52);
            this.textBoxHuidig.Name = "textBoxHuidig";
            this.textBoxHuidig.Size = new System.Drawing.Size(118, 20);
            this.textBoxHuidig.TabIndex = 6;
            // 
            // labelNaar
            // 
            this.labelNaar.AutoSize = true;
            this.labelNaar.Location = new System.Drawing.Point(323, 55);
            this.labelNaar.Name = "labelNaar";
            this.labelNaar.Size = new System.Drawing.Size(28, 13);
            this.labelNaar.TabIndex = 7;
            this.labelNaar.Text = "naar";
            // 
            // labelUitleg
            // 
            this.labelUitleg.AutoSize = true;
            this.labelUitleg.Location = new System.Drawing.Point(15, 91);
            this.labelUitleg.Name = "labelUitleg";
            this.labelUitleg.Size = new System.Drawing.Size(99, 13);
            this.labelUitleg.TabIndex = 9;
            this.labelUitleg.Text = "Gefilterde woorden:";
            // 
            // buttonOpslaan
            // 
            this.buttonOpslaan.Enabled = false;
            this.buttonOpslaan.Location = new System.Drawing.Point(272, 382);
            this.buttonOpslaan.Name = "buttonOpslaan";
            this.buttonOpslaan.Size = new System.Drawing.Size(124, 23);
            this.buttonOpslaan.TabIndex = 10;
            this.buttonOpslaan.Text = "Wijzigingen opslaan";
            this.buttonOpslaan.UseVisualStyleBackColor = true;
            this.buttonOpslaan.Click += new System.EventHandler(this.buttonOpslaan_Click);
            // 
            // buttonDirectory
            // 
            this.buttonDirectory.Location = new System.Drawing.Point(18, 12);
            this.buttonDirectory.Name = "buttonDirectory";
            this.buttonDirectory.Size = new System.Drawing.Size(75, 23);
            this.buttonDirectory.TabIndex = 13;
            this.buttonDirectory.Text = "Open directory";
            this.buttonDirectory.UseVisualStyleBackColor = true;
            this.buttonDirectory.Click += new System.EventHandler(this.buttonDirectory_Click);
            // 
            // dataGridViewWoorden
            // 
            this.dataGridViewWoorden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWoorden.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridViewWoorden.Enabled = false;
            this.dataGridViewWoorden.Location = new System.Drawing.Point(12, 122);
            this.dataGridViewWoorden.Name = "dataGridViewWoorden";
            this.dataGridViewWoorden.Size = new System.Drawing.Size(238, 283);
            this.dataGridViewWoorden.TabIndex = 14;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Woorden";
            this.Column1.Name = "Column1";
            // 
            // labelFolder
            // 
            this.labelFolder.AutoSize = true;
            this.labelFolder.Location = new System.Drawing.Point(99, 18);
            this.labelFolder.Name = "labelFolder";
            this.labelFolder.Size = new System.Drawing.Size(167, 13);
            this.labelFolder.TabIndex = 15;
            this.labelFolder.Text = "Gelieve de SD kaart te selecteren";
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 475);
            this.Controls.Add(this.labelFolder);
            this.Controls.Add(this.dataGridViewWoorden);
            this.Controls.Add(this.buttonDirectory);
            this.Controls.Add(this.buttonOpslaan);
            this.Controls.Add(this.labelUitleg);
            this.Controls.Add(this.labelNaar);
            this.Controls.Add(this.textBoxHuidig);
            this.Controls.Add(this.textBoxHashtag);
            this.Controls.Add(this.labelHashTag);
            this.Name = "Admin";
            this.Text = "Admin";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWoorden)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHashTag;
        private System.Windows.Forms.TextBox textBoxHashtag;
        private System.Windows.Forms.TextBox textBoxHuidig;
        private System.Windows.Forms.Label labelNaar;
        private System.Windows.Forms.Label labelUitleg;
        private System.Windows.Forms.Button buttonOpslaan;
        private System.Windows.Forms.Button buttonDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridView dataGridViewWoorden;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label labelFolder;
    }
}