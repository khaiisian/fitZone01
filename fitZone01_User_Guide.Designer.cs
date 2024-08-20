namespace fitZone01
{
    partial class User_Guide_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_Guide_Form));
            this.label1 = new System.Windows.Forms.Label();
            this.return_ = new System.Windows.Forms.PictureBox();
            this.Cancel__ = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.return_)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cancel__)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(214, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 51);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Guide";
            // 
            // return_
            // 
            this.return_.BackColor = System.Drawing.Color.Transparent;
            this.return_.Image = ((System.Drawing.Image)(resources.GetObject("return_.Image")));
            this.return_.Location = new System.Drawing.Point(12, 22);
            this.return_.Name = "return_";
            this.return_.Size = new System.Drawing.Size(50, 40);
            this.return_.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.return_.TabIndex = 47;
            this.return_.TabStop = false;
            this.return_.Click += new System.EventHandler(this.return__Click);
            // 
            // Cancel__
            // 
            this.Cancel__.BackColor = System.Drawing.Color.Transparent;
            this.Cancel__.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cancel__.Image = ((System.Drawing.Image)(resources.GetObject("Cancel__.Image")));
            this.Cancel__.Location = new System.Drawing.Point(638, 12);
            this.Cancel__.Name = "Cancel__";
            this.Cancel__.Size = new System.Drawing.Size(45, 45);
            this.Cancel__.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Cancel__.TabIndex = 48;
            this.Cancel__.TabStop = false;
            this.Cancel__.Click += new System.EventHandler(this.Cancel___Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.GhostWhite;
            this.richTextBox1.Location = new System.Drawing.Point(34, 178);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(628, 591);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // User_Guide_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(700, 804);
            this.Controls.Add(this.Cancel__);
            this.Controls.Add(this.return_);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "User_Guide_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Guide Form";
            this.Load += new System.EventHandler(this.User_Guide_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.return_)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cancel__)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox return_;
        private System.Windows.Forms.PictureBox Cancel__;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}