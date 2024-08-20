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
    public partial class User_Guide_Form : Form
    {
        public User_Guide_Form()
        {
            InitializeComponent();
        }

        private void User_Guide_Form_Load(object sender, EventArgs e)
        {
            try
            {
                //loading text file to rich textbox
                this.richTextBox1.LoadFile(Application.StartupPath + @"\User Guide.rtf");
                richTextBox1.ReadOnly = true;

            }
            catch (Exception ex) { }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void return__Click(object sender, EventArgs e)
        {
            fitZone01FitnessTrackerForm f = new fitZone01FitnessTrackerForm();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void Cancel___Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
