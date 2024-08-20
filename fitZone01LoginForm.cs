using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fitZone01;

namespace fitZone01
{
    public partial class fitZone01LoginForm : Form
    {
        
        public static int attempt =0 ; // variable for attempt
        public fitZone01LoginForm()
        {
            InitializeComponent();
        }

      
        // for Login click
        private async void btnlogin_Click(object sender, EventArgs e)
        {
            //validating if there are data in the text boxes 
            if (txtName.Text == "" || txtPw.Text == "")
            {
                MessageBox.Show("Enter both user name and password!!", "Log in Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            fitZone01User c = new fitZone01User();

            //Checking if login is successful
            if (c.Login(txtName.Text, txtPw.Text) == true)
            {
                MessageBox.Show("Login is successful", "Log in Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GlobalData._Username = txtName.Text;
                
                fitZone01FitnessTrackerForm uc = new fitZone01FitnessTrackerForm();
                this.Hide();
                uc.ShowDialog(); //showing exercise form
                this.Close();
            }

            else
            {
                MessageBox.Show("Your user name or password is wrong!!", "Log in Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                attempt+=1;
                txtName.Text = "";
                txtPw.Text = "";

                //failing attempts 
                if (attempt < 5)
                {
                    MessageBox.Show("You have "+(5-attempt)+" left", "Log in Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                }
                else if (attempt == 5)
                {
                    MessageBox.Show("You have no attempts left", "Log in Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Enabled = false;
                    txtPw.Enabled = false;
                    btnlogin.Enabled = false;
                    button_Cancel.Enabled = false;
                    Reg_btn.Enabled = false;

                    //timer = new Timer();
                    //timer.Interval = 10000;
                    //MessageBox.Show("You will be able to try again after 10 seconds", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //timer.Start();
                    //timer.Tick += new EventHandler(timer_tick);


                    //Timer for the next 5 attempts
                    MessageBox.Show("You will be able to try again after 20 seconds", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await Task.Delay(20000);
                    txtName.Enabled = true;
                    txtPw.Enabled = true;
                    btnlogin.Enabled = true;
                    button_Cancel.Enabled = true;
                    Reg_btn.Enabled = true;
                    attempt = 0;
                }





            }
        }

        
        //private void timer_tick(object sender, EventArgs e)
        //{
        //    timer.Stop();
        //    txtName.Enabled = true;
        //    txtPw.Enabled = true;
        //}



        //For cancel btn
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close(); //closing the form
        }

    

        //For the password visible and invisible
        private void visible_btn_Click(object sender, EventArgs e)
        {
            if (txtPw.PasswordChar == '*')
            {
                invisible_btn.BringToFront();
                txtPw.PasswordChar = '\0';
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


        //For registration button
        private void Reg_btn_Click(object sender, EventArgs e)
        {
            fitZone01RegistrationForm su = new fitZone01RegistrationForm();

            this.Hide();
            su.ShowDialog(); //showing registration form
            this.Close();
        }

  
    }
}
