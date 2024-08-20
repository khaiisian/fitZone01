using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace fitZone01
{
    partial class fitZone01RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fitZone01RegistrationForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPw = new System.Windows.Forms.TextBox();
            this.btnlogin = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCal = new System.Windows.Forms.TextBox();
            this.btnReg = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.visible_btn1 = new System.Windows.Forms.Button();
            this.visible_btn = new System.Windows.Forms.Button();
            this.invisible_btn1 = new System.Windows.Forms.Button();
            this.invisible_btn = new System.Windows.Forms.Button();
            this.comPW_txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.GhostWhite;
            this.label1.Location = new System.Drawing.Point(15, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.GhostWhite;
            this.label2.Location = new System.Drawing.Point(15, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.GhostWhite;
            this.label3.Location = new System.Drawing.Point(15, 369);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.GhostWhite;
            this.label4.Location = new System.Drawing.Point(15, 426);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Target Calorie";
            // 
            // txtPw
            // 
            this.txtPw.BackColor = System.Drawing.Color.White;
            this.txtPw.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPw.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPw.Location = new System.Drawing.Point(237, 254);
            this.txtPw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPw.Name = "txtPw";
            this.txtPw.PasswordChar = '*';
            this.txtPw.Size = new System.Drawing.Size(188, 25);
            this.txtPw.TabIndex = 5;
            // 
            // btnlogin
            // 
            this.btnlogin.BackColor = System.Drawing.Color.Cyan;
            this.btnlogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogin.Font = new System.Drawing.Font("Orator Std", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.ForeColor = System.Drawing.Color.White;
            this.btnlogin.Location = new System.Drawing.Point(169, 609);
            this.btnlogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(121, 49);
            this.btnlogin.TabIndex = 3;
            this.btnlogin.Text = "Log In";
            this.btnlogin.UseVisualStyleBackColor = false;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtEmail.Location = new System.Drawing.Point(237, 368);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(188, 25);
            this.txtEmail.TabIndex = 6;
            // 
            // txtCal
            // 
            this.txtCal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCal.Location = new System.Drawing.Point(237, 425);
            this.txtCal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCal.Name = "txtCal";
            this.txtCal.Size = new System.Drawing.Size(188, 25);
            this.txtCal.TabIndex = 7;
            this.txtCal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCal_KeyPress);
            // 
            // btnReg
            // 
            this.btnReg.BackColor = System.Drawing.Color.Fuchsia;
            this.btnReg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReg.Font = new System.Drawing.Font("Orator Std", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReg.ForeColor = System.Drawing.Color.White;
            this.btnReg.Location = new System.Drawing.Point(112, 493);
            this.btnReg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(246, 49);
            this.btnReg.TabIndex = 2;
            this.btnReg.Text = "Register";
            this.btnReg.UseVisualStyleBackColor = false;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtName.Location = new System.Drawing.Point(237, 203);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(188, 25);
            this.txtName.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(39, 577);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(373, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "If you already have an account, Please log in!";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.visible_btn1);
            this.groupBox1.Controls.Add(this.visible_btn);
            this.groupBox1.Controls.Add(this.invisible_btn1);
            this.groupBox1.Controls.Add(this.invisible_btn);
            this.groupBox1.Controls.Add(this.comPW_txt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.btnReg);
            this.groupBox1.Controls.Add(this.txtCal);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.btnlogin);
            this.groupBox1.Controls.Add(this.txtPw);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Orator Std", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(25, 49);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(453, 671);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // visible_btn1
            // 
            this.visible_btn1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("visible_btn1.BackgroundImage")));
            this.visible_btn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.visible_btn1.Location = new System.Drawing.Point(401, 309);
            this.visible_btn1.Name = "visible_btn1";
            this.visible_btn1.Size = new System.Drawing.Size(24, 25);
            this.visible_btn1.TabIndex = 15;
            this.visible_btn1.UseVisualStyleBackColor = true;
            this.visible_btn1.Click += new System.EventHandler(this.visible_btn1_Click);
            // 
            // visible_btn
            // 
            this.visible_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("visible_btn.BackgroundImage")));
            this.visible_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.visible_btn.Location = new System.Drawing.Point(401, 253);
            this.visible_btn.Name = "visible_btn";
            this.visible_btn.Size = new System.Drawing.Size(24, 25);
            this.visible_btn.TabIndex = 14;
            this.visible_btn.UseVisualStyleBackColor = true;
            this.visible_btn.Click += new System.EventHandler(this.visible_btn_Click);
            // 
            // invisible_btn1
            // 
            this.invisible_btn1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("invisible_btn1.BackgroundImage")));
            this.invisible_btn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.invisible_btn1.Location = new System.Drawing.Point(401, 309);
            this.invisible_btn1.Name = "invisible_btn1";
            this.invisible_btn1.Size = new System.Drawing.Size(24, 25);
            this.invisible_btn1.TabIndex = 13;
            this.invisible_btn1.UseVisualStyleBackColor = true;
            this.invisible_btn1.Click += new System.EventHandler(this.invisible_btn1_Click);
            // 
            // invisible_btn
            // 
            this.invisible_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("invisible_btn.BackgroundImage")));
            this.invisible_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.invisible_btn.Location = new System.Drawing.Point(401, 253);
            this.invisible_btn.Name = "invisible_btn";
            this.invisible_btn.Size = new System.Drawing.Size(24, 25);
            this.invisible_btn.TabIndex = 12;
            this.invisible_btn.UseVisualStyleBackColor = true;
            this.invisible_btn.Click += new System.EventHandler(this.invisible_btn_Click);
            // 
            // comPW_txt
            // 
            this.comPW_txt.BackColor = System.Drawing.Color.White;
            this.comPW_txt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comPW_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comPW_txt.Location = new System.Drawing.Point(237, 310);
            this.comPW_txt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comPW_txt.Name = "comPW_txt";
            this.comPW_txt.PasswordChar = '*';
            this.comPW_txt.Size = new System.Drawing.Size(188, 25);
            this.comPW_txt.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.GhostWhite;
            this.label6.Location = new System.Drawing.Point(15, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "Confirmed Password";
            // 
            // fitZone01RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(507, 749);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fitZone01RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fitZone01 Registration Form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtPw;
        private Button btnlogin;
        private TextBox txtEmail;
        private TextBox txtCal;
        private Button btnReg;
        private TextBox txtName;
        private Label label5;
        private GroupBox groupBox1;
        private TextBox comPW_txt;
        private Label label6;
        private Button invisible_btn;
        private Button visible_btn;
        private Button invisible_btn1;
        private Button visible_btn1;
    }
}