namespace SplitflapsFrontend.presentationlayer
{
    partial class Form1
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
            this.labelStaticTweet = new System.Windows.Forms.Label();
            this.labelTweet = new System.Windows.Forms.Label();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonDecline = new System.Windows.Forms.Button();
            this.textBoxSearchQuery = new System.Windows.Forms.TextBox();
            this.labelSearchQuery = new System.Windows.Forms.Label();
            this.labelStaticUsername = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.buttonChangeSearchQuery = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelStaticTweet
            // 
            this.labelStaticTweet.AutoSize = true;
            this.labelStaticTweet.Location = new System.Drawing.Point(12, 56);
            this.labelStaticTweet.Name = "labelStaticTweet";
            this.labelStaticTweet.Size = new System.Drawing.Size(40, 13);
            this.labelStaticTweet.TabIndex = 0;
            this.labelStaticTweet.Text = "Tweet:";
            // 
            // labelTweet
            // 
            this.labelTweet.AutoSize = true;
            this.labelTweet.Location = new System.Drawing.Point(118, 56);
            this.labelTweet.MaximumSize = new System.Drawing.Size(300, 0);
            this.labelTweet.Name = "labelTweet";
            this.labelTweet.Size = new System.Drawing.Size(42, 13);
            this.labelTweet.TabIndex = 1;
            this.labelTweet.Text = "USE-IT";
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(355, 146);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 2;
            this.buttonAccept.Text = "Goedkeuren";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonDecline
            // 
            this.buttonDecline.Location = new System.Drawing.Point(355, 175);
            this.buttonDecline.Name = "buttonDecline";
            this.buttonDecline.Size = new System.Drawing.Size(75, 23);
            this.buttonDecline.TabIndex = 3;
            this.buttonDecline.Text = "Afwijzen";
            this.buttonDecline.UseVisualStyleBackColor = true;
            this.buttonDecline.Click += new System.EventHandler(this.buttonDecline_Click);
            // 
            // textBoxSearchQuery
            // 
            this.textBoxSearchQuery.Location = new System.Drawing.Point(121, 8);
            this.textBoxSearchQuery.Name = "textBoxSearchQuery";
            this.textBoxSearchQuery.Size = new System.Drawing.Size(100, 20);
            this.textBoxSearchQuery.TabIndex = 4;
            // 
            // labelSearchQuery
            // 
            this.labelSearchQuery.AutoSize = true;
            this.labelSearchQuery.Location = new System.Drawing.Point(12, 11);
            this.labelSearchQuery.Name = "labelSearchQuery";
            this.labelSearchQuery.Size = new System.Drawing.Size(101, 13);
            this.labelSearchQuery.TabIndex = 5;
            this.labelSearchQuery.Text = "Zoek query:          #";
            // 
            // labelStaticUsername
            // 
            this.labelStaticUsername.AutoSize = true;
            this.labelStaticUsername.Location = new System.Drawing.Point(12, 128);
            this.labelStaticUsername.Name = "labelStaticUsername";
            this.labelStaticUsername.Size = new System.Drawing.Size(87, 13);
            this.labelStaticUsername.TabIndex = 6;
            this.labelStaticUsername.Text = "Gebruikersnaam:";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(118, 128);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(42, 13);
            this.labelUsername.TabIndex = 7;
            this.labelUsername.Text = "USE-IT";
            // 
            // buttonChangeSearchQuery
            // 
            this.buttonChangeSearchQuery.Location = new System.Drawing.Point(355, 6);
            this.buttonChangeSearchQuery.Name = "buttonChangeSearchQuery";
            this.buttonChangeSearchQuery.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeSearchQuery.TabIndex = 8;
            this.buttonChangeSearchQuery.Text = "Wijzig Query";
            this.buttonChangeSearchQuery.UseVisualStyleBackColor = true;
            this.buttonChangeSearchQuery.Click += new System.EventHandler(this.buttonChangeSearchQuery_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 218);
            this.Controls.Add(this.buttonChangeSearchQuery);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelStaticUsername);
            this.Controls.Add(this.labelSearchQuery);
            this.Controls.Add(this.textBoxSearchQuery);
            this.Controls.Add(this.buttonDecline);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.labelTweet);
            this.Controls.Add(this.labelStaticTweet);
            this.Name = "Form1";
            this.Text = "USE-IT Frontend";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStaticTweet;
        private System.Windows.Forms.Label labelTweet;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonDecline;
        private System.Windows.Forms.TextBox textBoxSearchQuery;
        private System.Windows.Forms.Label labelSearchQuery;
        private System.Windows.Forms.Label labelStaticUsername;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Button buttonChangeSearchQuery;
    }
}

