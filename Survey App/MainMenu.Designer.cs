namespace Survey_App
{
    partial class MainMenu
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
            this.btnVSR = new System.Windows.Forms.Button();
            this.btnFOS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVSR
            // 
            this.btnVSR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVSR.BackColor = System.Drawing.Color.Firebrick;
            this.btnVSR.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnVSR.FlatAppearance.BorderSize = 8;
            this.btnVSR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnVSR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnVSR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVSR.Font = new System.Drawing.Font("MingLiU-ExtB", 26.25F);
            this.btnVSR.ForeColor = System.Drawing.Color.LightCoral;
            this.btnVSR.Location = new System.Drawing.Point(0, 115);
            this.btnVSR.Name = "btnVSR";
            this.btnVSR.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnVSR.Size = new System.Drawing.Size(545, 119);
            this.btnVSR.TabIndex = 5;
            this.btnVSR.Tag = "";
            this.btnVSR.Text = "View survey results";
            this.btnVSR.UseVisualStyleBackColor = false;
            this.btnVSR.Click += new System.EventHandler(this.btnVSR_Click);
            // 
            // btnFOS
            // 
            this.btnFOS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFOS.BackColor = System.Drawing.Color.Firebrick;
            this.btnFOS.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnFOS.FlatAppearance.BorderSize = 8;
            this.btnFOS.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnFOS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnFOS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFOS.Font = new System.Drawing.Font("MingLiU-ExtB", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFOS.ForeColor = System.Drawing.Color.LightCoral;
            this.btnFOS.Location = new System.Drawing.Point(0, -5);
            this.btnFOS.Name = "btnFOS";
            this.btnFOS.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnFOS.Size = new System.Drawing.Size(545, 119);
            this.btnFOS.TabIndex = 4;
            this.btnFOS.Tag = "";
            this.btnFOS.Text = "Fill out survey";
            this.btnFOS.UseVisualStyleBackColor = false;
            this.btnFOS.Click += new System.EventHandler(this.btnFOS_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(546, 231);
            this.Controls.Add(this.btnVSR);
            this.Controls.Add(this.btnFOS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVSR;
        private System.Windows.Forms.Button btnFOS;
    }
}

