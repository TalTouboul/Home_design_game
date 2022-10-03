namespace ProjectNew
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.GetIntoHouseButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.EnterNameTEXT = new System.Windows.Forms.TextBox();
            this.WelcomeTEXT = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // GetIntoHouseButton
            // 
            this.GetIntoHouseButton.BackColor = System.Drawing.Color.Transparent;
            this.GetIntoHouseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GetIntoHouseButton.FlatAppearance.BorderSize = 0;
            this.GetIntoHouseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.GetIntoHouseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.GetIntoHouseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GetIntoHouseButton.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetIntoHouseButton.Location = new System.Drawing.Point(284, 12);
            this.GetIntoHouseButton.Name = "GetIntoHouseButton";
            this.GetIntoHouseButton.Size = new System.Drawing.Size(352, 340);
            this.GetIntoHouseButton.TabIndex = 9;
            this.GetIntoHouseButton.Text = "house";
            this.GetIntoHouseButton.UseVisualStyleBackColor = false;
            this.GetIntoHouseButton.Click += new System.EventHandler(this.GetIntoHouseButton_Click);
            // 
            // NewButton
            // 
            this.NewButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NewButton.BackColor = System.Drawing.Color.DarkKhaki;
            this.NewButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.NewButton.ForeColor = System.Drawing.Color.Transparent;
            this.NewButton.Location = new System.Drawing.Point(342, 407);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(174, 61);
            this.NewButton.TabIndex = 13;
            this.NewButton.Text = "New Game";
            this.NewButton.UseVisualStyleBackColor = false;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.BackColor = System.Drawing.Color.DarkKhaki;
            this.LoadButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LoadButton.ForeColor = System.Drawing.Color.Transparent;
            this.LoadButton.Location = new System.Drawing.Point(342, 474);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(174, 61);
            this.LoadButton.TabIndex = 14;
            this.LoadButton.Text = "Load Game";
            this.LoadButton.UseVisualStyleBackColor = false;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.BackColor = System.Drawing.Color.DarkKhaki;
            this.PlayButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PlayButton.BackgroundImage")));
            this.PlayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlayButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PlayButton.ForeColor = System.Drawing.Color.Transparent;
            this.PlayButton.Location = new System.Drawing.Point(383, 350);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(105, 51);
            this.PlayButton.TabIndex = 15;
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // EnterNameTEXT
            // 
            this.EnterNameTEXT.BackColor = System.Drawing.Color.DarkKhaki;
            this.EnterNameTEXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.EnterNameTEXT.Location = new System.Drawing.Point(304, 314);
            this.EnterNameTEXT.MaximumSize = new System.Drawing.Size(240, 30);
            this.EnterNameTEXT.Multiline = true;
            this.EnterNameTEXT.Name = "EnterNameTEXT";
            this.EnterNameTEXT.Size = new System.Drawing.Size(240, 30);
            this.EnterNameTEXT.TabIndex = 16;
            this.EnterNameTEXT.Text = "Enter your name:";
            this.EnterNameTEXT.TextChanged += new System.EventHandler(this.EnterNameTEXT_TextChanged);
            this.EnterNameTEXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EnterNameTEXT_TextChanged);
            // 
            // WelcomeTEXT
            // 
            this.WelcomeTEXT.BackColor = System.Drawing.Color.DarkKhaki;
            this.WelcomeTEXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.WelcomeTEXT.Location = new System.Drawing.Point(70, 177);
            this.WelcomeTEXT.Multiline = true;
            this.WelcomeTEXT.Name = "WelcomeTEXT";
            this.WelcomeTEXT.Size = new System.Drawing.Size(279, 41);
            this.WelcomeTEXT.TabIndex = 17;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProjectNew.Properties.Resources.home4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(896, 659);
            this.Controls.Add(this.WelcomeTEXT);
            this.Controls.Add(this.EnterNameTEXT);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.NewButton);
            this.Controls.Add(this.GetIntoHouseButton);
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GetIntoHouseButton;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.TextBox EnterNameTEXT;
        private System.Windows.Forms.TextBox WelcomeTEXT;
    }
}

