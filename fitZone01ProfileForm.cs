using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace fitZone01
{
    public partial class fitZone01ProfileForm : Form
    {
        
        int iRowIndex;

        DialogResult response;
        string constr;
        int mid, uid;
        string aname;
        public fitZone01ProfileForm()
        {
            InitializeComponent();
            uid = GlobalData._UserId;
            constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\fitZone01DB.mdb"; //connecting fitZone01DB

        }

        
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                iRowIndex = dataGridView1.CurrentRow.Index;
                data_bind();
            }
            catch (System.NullReferenceException ex) { MessageBox.Show("There is no record to select"); }
        }
        void data_bind()
        {
            try
            {
                object o1 = dataGridView1[1, iRowIndex].Value;
                object o2 = dataGridView1[2, iRowIndex].Value;

                mid = int.Parse(o1.ToString()); 
                aname = (o2.ToString());
            }
            catch (System.FormatException ex) { }
        }

        
        private void UserProfile_Load(object sender, EventArgs e)
        {

            DbClass db = new DbClass();
            uid = GlobalData._UserId;
            dataGridView1.DataSource = db.Get_User_Act(uid);
            dataGridView1.DataMember = "UserActTable";

            lbl_name.Text += GlobalData._Username;
            lbl_userid.Text += GlobalData._UserId;

            lbl_tarCal.Text += GlobalData._TargetCalorie;

            DbClass ec = new DbClass();
            float curCal = (float)ec.Current_Total_Calories(uid);
            lbl_total_cal.Text += curCal;

            float goal = GlobalData._TargetCalorie;

            PBar.Value =(int) pbar(goal, curCal);
        }


        //For reset btn
        private void reset_btn_Click_1(object sender, EventArgs e)
        {
            //Confirming user to reset the Target Calories and History Activity Record 
            response = MessageBox.Show("Do you wish to reset the Target Calories and History Activity Record", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (response == DialogResult.No)
            {
                return;
            }

            
            else
            {
                string input = Interaction.InputBox("Enter new target calories", "Reset target calories");
                if (int.TryParse(input, out int numericValue))
                {
                    float new_tarcal = float.Parse(input); //new target cal
                    

                    try
                    {
                        DbClass db = new DbClass();
                        int uid = GlobalData._UserId;
                        db.Reset_TarCal(uid, new_tarcal); //reseting the target calories
                        GlobalData._TargetCalorie = (int)new_tarcal;
                    }
                    catch (Exception ex) { MessageBox.Show("There is an error"); return; }

                    MessageBox.Show("You have successfull reset your target calories and activity reocrd!\nWelcome from your new challenge!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //validating if user inputted non-numeric values or stop the reseting process
                else
                {
                    MessageBox.Show("Resting Process was failed because user ceased the process or didn't put numeric value", "Process Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }

        
        // for refresh btn
        private void Refresh__Click(object sender, EventArgs e)
        {
            DbClass db = new DbClass();
            uid = GlobalData._UserId;
            dataGridView1.DataSource = db.Get_User_Act(uid);
            dataGridView1.DataMember = "UserActTable";

            lbl_name.Text ="Name : " + GlobalData._Username;
            lbl_userid.Text = "User ID : "+ uid;

            lbl_tarCal.Text = "Target Calories : " + GlobalData._TargetCalorie;

            DbClass ec = new DbClass();
            float curCal = (float)ec.Current_Total_Calories(uid);
            lbl_total_cal.Text = "Total Calories Loss : "+curCal;

            float goal = GlobalData._TargetCalorie;
            PBar.Value = (int)pbar(goal, curCal);             //showing how much progress has done to reach goal on progress bar
        }



        // for return btn
        private void return__Click(object sender, EventArgs e)
        {
            fitZone01FitnessTrackerForm fitZone = new fitZone01FitnessTrackerForm();
            this.Hide();
            fitZone.ShowDialog(); //returning to the fitness form
            this.Close();
        }

        //for delete btn
        private void delete_Click(object sender, EventArgs e)
        {
            response = MessageBox.Show("Do you want to delete the record?", "Information", MessageBoxButtons.YesNo);
            if (response == DialogResult.No) return;

            else
            {
                DbClass db = new DbClass();
                db.Delete_History(uid, mid); // deleting a record from user history 
                MessageBox.Show("The record is deleted successfully!");
            }
        }


        //defining progress bar value
        private float pbar(float g, float c)
        {
            if (c >= g)
            {
                float v = 100;
                return v;
            }
            else
            {
                float v = (int)((c / g) * 100f);
                return v;
            }
        }

        


    }
}
