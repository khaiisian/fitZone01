using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using fitZone01;

namespace fitZone01
{
    public partial class fitZone01RegistrationForm : Form
    {
        public fitZone01RegistrationForm()
        {
            InitializeComponent();
        }


        // for log in click
        private void btnlogin_Click(object sender, EventArgs e)
        {
            fitZone01LoginForm formlogin = new fitZone01LoginForm();
            this.Hide();
            //showing log in form
            formlogin.ShowDialog();
            this.Close();
        }
    
        
        
        //Validating ensure only numerica data is accepted in metric text boxes
        private void txtCal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                e.Handled = true;
                MessageBox.Show("The target calories must be a whole number (no decimal)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCal.Text = "";
            }
        }

        // Password visible and invisible buttons 
        private void visible_btn_Click(object sender, EventArgs e)
        {
            if (txtPw.PasswordChar == '*')
            {
                invisible_btn.BringToFront();
                txtPw.PasswordChar = '\0';
            }
        }
        private void visible_btn1_Click(object sender, EventArgs e)
        {
            if (comPW_txt.PasswordChar == '*')
            {
                invisible_btn1.BringToFront();
                comPW_txt.PasswordChar = '\0';
            }
        }
        private void invisible_btn1_Click(object sender, EventArgs e)
        {
            if (comPW_txt.PasswordChar == '\0')
            {
                visible_btn1.BringToFront();
                comPW_txt.PasswordChar = '*';
            }
        }
        private void invisible_btn_Click(object sender, EventArgs e)
        {
            if (txtPw.PasswordChar == '\0')
            {
                visible_btn.BringToFront();
                txtPw.PasswordChar = '*';
            }
        }


        //For Registration click
        private void btnReg_Click(object sender, EventArgs e)
        {
            //Validatig to ensure there is data in the fields
            if (txtName.Text == "" || txtPw.Text == "" || txtEmail.Text == "" || txtCal.Text == "")
            {
                MessageBox.Show("Please, Enter all the fields", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fitZone01User c = new fitZone01User();
            c.Username = txtName.Text; //asigning data from txtNmae into Username 
            int plength = txtPw.Text.Length;

            //to validate if there is atleast 12 characters in password
            if (plength < 12)
            {
                MessageBox.Show("Please try again \nThe password must be at least 12 words", "Registration Failed", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            //to validate if the gmail is in correct format
            if (!Regex.IsMatch(txtName.Text, "[A-Z]") || !Regex.IsMatch(txtPw.Text, "[a-z]"))
            {
                MessageBox.Show("The username must have at least one Capital and Small letter", "Registration Failed", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            //to validate if there are at least one capital letter and small letter
                if (!Regex.IsMatch(txtPw.Text, "[A-Z]") || !Regex.IsMatch(txtPw.Text, "[a-z]"))
            {
                MessageBox.Show("Please try again \nThe password must include both small and capital letter", "Registration Failed", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            //to validate if the gmail is in correct format
            if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9._%+-]+@gmail\.com$"))
            {
                MessageBox.Show("Your Email must be in correct format!!\nFor example : example@gmail.com", "Registration Failed", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            //to validate if the password and confirmed password are the same
            if (txtPw.Text != comPW_txt.Text)
            {
                MessageBox.Show("Your password and confirmed password must be the same", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.Parse(txtCal.Text) == 0)
            {
                MessageBox.Show("Your Target Calories can't be 0", "ErRegistration Failedror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            c.Password = txtPw.Text; 
            c.Email = txtEmail.Text;
            c.Targetcal = int.Parse(txtCal.Text);

            //to check if registration successful
            bool result = c.Register(c);
            if (result == true) //Registration successful
            {
                MessageBox.Show("Registration is Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GlobalData._Username = txtName.Text;
                GlobalData._TargetCalorie = int.Parse(txtCal.Text);


                fitZone01FitnessTrackerForm tracking = new fitZone01FitnessTrackerForm();
                this.Hide();
                tracking.ShowDialog();

                this.Close();
            }
            else //Registration failed
            {
                MessageBox.Show("Regesteration Failed \nThe uesr name is already used by someone.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }


    }
}
