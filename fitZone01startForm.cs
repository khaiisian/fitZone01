
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
    public partial class fitZone01startForm : Form
    {
        public fitZone01startForm()
        {
            InitializeComponent();
        }

        //for start btn
        private void startbtn_Click(object sender, EventArgs e)
        {
            
            fitZone01RegistrationForm su = new fitZone01RegistrationForm();
            this.Hide();
            su.ShowDialog(); //showing registration form
            this.Close();


        }

        private void fitZone01startForm_Load(object sender, EventArgs e)
        {

        }
    }
}