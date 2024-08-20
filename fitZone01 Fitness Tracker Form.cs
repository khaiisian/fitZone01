using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using fitZone01;
using System.Xml.Linq;
using System.Windows.Forms.VisualStyles;
using Microsoft.VisualBasic;

namespace fitZone01
{
    public partial class fitZone01FitnessTrackerForm : Form
    {
        int iRowIndex;
        OleDbCommand mycmd;
        OleDbConnection conn;

        DialogResult response;
        string constr;
        float m1, m2, m3, curCal;
        int mid, uid, aid;
        string activity;

        public fitZone01FitnessTrackerForm()
        {
            InitializeComponent();
            uid = GlobalData._UserId;
            constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\fitZone01DB.mdb"; //establish connection with fitZone01DB

            conn = new OleDbConnection();
            conn.ConnectionString = constr;
        }

        

        //  Data Binding in Data Grid View 
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                iRowIndex = dataGridView1.CurrentRow.Index;
                databind();
            }
            catch (System.NullReferenceException ex) { MessageBox.Show("No record to select"); }
        }

        

        void databind() 
        {
            try
            {
                object o1 = dataGridView1[0, iRowIndex].Value; 
                object o2 = dataGridView1[2, iRowIndex].Value;

                
                mid = int.Parse(o1.ToString()); // mid = column 0 of data grid view
                aid = int.Parse(o2.ToString()); // aid = column 2 of data grid view
            }
            catch (System.FormatException ex) { }

            combo_act.SelectedIndex = aid - 1;

            string query = "SELECT * FROM User_Act_Metric WHERE mid= " + mid + " AND aid=" + aid + " AND uid=" + uid;
            conn = new OleDbConnection(constr);
            conn.Open();
            mycmd = new OleDbCommand(query, conn);
            OleDbDataReader myreader;
            myreader = mycmd.ExecuteReader();

            while (myreader.Read())
            {
                mid = int.Parse(myreader.GetValue(0).ToString());

               // for combox to show the related item form the data grid view
                float m = float.Parse(myreader.GetValue(3).ToString());
                met_to_type mt = new met_to_type();
                yogatype_box.SelectedItem = mt.yoga_metTotype(m);
                swimming_combo.SelectedItem = mt.met_to_swimming(m);

                // for text boxes to show the related data from the data grid view
                Metric1txt.Text = myreader.GetValue(3).ToString(); Metric1txt.Text = myreader.GetValue(3).ToString();
                Metric2txt.Text = myreader.GetValue(4).ToString();
                Metric3txt.Text = myreader.GetValue(5).ToString();
                CalorieBurned_label.Text = "Calories Burned (cal) = "+myreader.GetValue(6).ToString() + "cal";

            }
            myreader.Close();
            conn.Close();
        }





        private void combo_act_SelectedIndexChanged(object sender, EventArgs e)
        {
            DbClass db = new DbClass();
            uid = GlobalData._UserId;
            aid = combo_act.SelectedIndex + 1;
            dataGridView1.DataSource = db.Get_Table(uid, aid);
            dataGridView1.DataMember = "User_Act_Metric";
            activity = combo_act.GetItemText(combo_act.SelectedItem.ToString());
            activity = combo_act.SelectedItem.ToString();

            // setting metric labels related to each activity selected in activity combo box

            if (activity == "Swimming")
            {
                metric1_lbl.Text = "Swimming Type";
                metric2_lbl.Text = "Duration(min)";
                metric3_lbl.Text = "Weight(kg)";
                CalorieBurned_label.Text = "Calories Burned (cal)";
                Metric1txt.Visible = false;
                yogatype_box.Visible = false;
                swimming_combo.Visible = true;

            }
            else if (activity == "Walking")
            {
                metric1_lbl.Text = "Height(cm)";
                metric2_lbl.Text = "Weight(kg)";
                metric3_lbl.Text = "Steps";
                CalorieBurned_label.Text = "Calories Burned (cal)";
                Metric1txt.Visible = true;
                yogatype_box.Visible = false;
                //yogatypegp.Visible = false;
                swimming_combo.Visible = false;
            }
            else if (activity == "Skipping Rope")
            {
                metric1_lbl.Text = "Skips";
                metric2_lbl.Text = "Weight(kg)";
                metric3_lbl.Text = "Duration(min)";
                CalorieBurned_label.Text = "Calories Burned (cal)";
                Metric1txt.Visible = true;
                yogatype_box.Visible = false;
                //yogatypegp.Visible = false;
                swimming_combo.Visible = false;
            }
            else if (activity == "Cycling")
            {
                metric1_lbl.Text = "Distance(mile)";
                metric2_lbl.Text = "Duration(hour)";
                metric3_lbl.Text = "Weight(kg)";
                CalorieBurned_label.Text = "Calories Burned (cal)";
                Metric1txt.Visible = true;
                yogatype_box.Visible = false;
                swimming_combo.Visible = false;
            }
            else if (activity == "Jogging")
            {
                metric1_lbl.Text = "Distance(mile)";
                metric2_lbl.Text = "Duration(hour)";
                metric3_lbl.Text = "Weight(kg)";
                CalorieBurned_label.Text = "Calories Burned (cal)";
                yogatype_box.Visible = false;
                swimming_combo.Visible = false;

            }
            else if (activity == "Yoga")
            {
                metric1_lbl.Text = "Yoga Type";
                metric2_lbl.Text = "Duration(min)";
                metric3_lbl.Text = "Weight(Kg)";
                CalorieBurned_label.Text = "Calories Burned (cal)";
                Metric1txt.Visible = false;
                yogatype_box.Visible = true;
                swimming_combo.Visible = false;

            }
        }






        // Validating that the txt box only accepts float or decimal data
        private void Metric1txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                e.Handled = true;
                MessageBox.Show("This field only accepts numeric data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Metric1txt.Text = "";
            }
        }
        private void Metric2txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                MessageBox.Show("This field only accepts numeric data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Metric2txt.Text = "";
            }
        }
        private void Metric3txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                MessageBox.Show("This field only accepts numeric data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Metric3txt.Text = "";
            }
        }

  


        

        // method to go profile form by click profile image
        private void profile_Click_1(object sender, EventArgs e)
        {
            fitZone01ProfileForm up = new fitZone01ProfileForm();
            this.Hide();
            //showing profile form
            up.ShowDialog();
            this.Close();
        }

        private void manual_Click(object sender, EventArgs e)
        {
            User_Guide_Form frm = new User_Guide_Form();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void fitZone01_fitness_tracker_Load(object sender, EventArgs e)
        {
            DbClass db = new DbClass();

            List<string> lst = new List<string>();
            lst = db.Get_Activities();

            combo_act.DataSource = lst; // assgining list of activities into activity combo box
            combo_act.Show(); //displaying activity list in combo box

            UserName_label.Text += GlobalData._Username;
            TarCal_label.Text = "Target Calories = " + GlobalData._TargetCalorie + "cal";
            lbl_uid.Text += GlobalData._UserId;

            ExerciseClass ec = new ExerciseClass();
            curCal = (float)ec.CurrentTotalCal(uid);
            PresentCalorie_label.Text = "Currnent Calories =" + curCal + "cal";
            float goal = GlobalData._TargetCalorie;

            //showing how much progress has done to reach goal on progress bar
            if (curCal >= goal)
            {
                PBar.Value = 100;
            }
            else
            {
                PBar.Value = (int)((curCal / goal) * 100f);
            }
        }

        private void reset_btn_Click(object sender, EventArgs e)
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
                    if (new_tarcal == 0)
                    {
                        MessageBox.Show("The New Target Calories can't be 0", "Process Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        DbClass db = new DbClass();
                        int uid = GlobalData._UserId;
                        db.Reset_TarCal(uid, new_tarcal); //reseting the target calories
                        GlobalData._TargetCalorie = (int)new_tarcal;
                        ExerciseClass ec = new ExerciseClass();
                        curCal = (float)ec.CurrentTotalCal(uid);

                        //showing how much progress has done to reach goal
                        if (curCal >= new_tarcal)
                        {
                            PBar.Value = 100;
                        }
                        else
                        {
                            PBar.Value = (int)((curCal / new_tarcal) * 100f);
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("There is an error"); return; }

                    MessageBox.Show("You have successfull reset your target calories and activity reocrd!\nWelcome from your new challenge!!\nPlease refresh the form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //validating if user inputted non-numeric values or stop the reseting process
                else
                {
                    MessageBox.Show("Resting Process was failed because user ceased the process or didn't put numeric value", "Process Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }

  


        // For the Cancel btn
        private void Cancel___Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //For Delete btn
        private void Delete__Click(object sender, EventArgs e)
        {
            response = MessageBox.Show("Do you want to delete the record?", "Information", MessageBoxButtons.YesNo);
            if (response == DialogResult.No) return;

            //Deleting an activity from the database
            
            if (activity == "Swimming")
            {
                SwimmingEx sc = new SwimmingEx(m1, m2, m3);
                sc.DeleteSwimmingEx(mid, uid, aid);
                MessageBox.Show("Record is Deleted successfully \nPlease Refresh the form");
            }


            else if (activity == "Walking")
            {
                WalkingEx wc = new WalkingEx(m1, m2, m3);
                wc.DeleteWalkingExercise(mid, uid, aid);
                MessageBox.Show("Record is Deleted successfully \nPlease Refresh the form");
            }

            else if (activity == "Skipping Rope")
            {
                SkippingRopeEX se = new SkippingRopeEX(m1, m2, m3);
                se.DeleteSkipropeActivity(mid, uid, aid);
                MessageBox.Show("Record is Deleted successfully \nPlease Refresh the form");
            }
            else if (activity == "Cycling")
            {
                CyclingEx ce = new CyclingEx(m1, m2, m3);
                ce.DeleteCyclingEx(mid, uid, aid);
                MessageBox.Show("Record is Deleted successfully \nPlease Refresh the form");
            }
            else if (activity == "Jogging")
            {
                JoggingEx je = new JoggingEx(m1, m2, m3);
                je.DeleteJogging(mid, uid, aid);
                MessageBox.Show("Record is Deleted successfully \nPlease Refresh the form");
            }
            else if (activity == "Yoga")
            {
                YogaEx ye = new YogaEx(m1, m2, m3);
                ye.DeleteYoga(mid, uid, aid);
                MessageBox.Show("Record is Deleted successfully \nPlease Refresh the form");
            }


            ExerciseClass ec = new ExerciseClass();
            curCal = (float)ec.CurrentTotalCal(uid);
            PresentCalorie_label.Text = "Current Calories = " + curCal + "cal";

            float goal = GlobalData._TargetCalorie;
            //showing how much progress has done to reach goal on progress bar
            if (curCal == goal)
            {
                PBar.Value = 100;
            }
            else
            {
                PBar.Value = (int)((curCal / goal) * 100f);
            }
        }

        

        //for Save Btn
        private void save_btn_Click(object sender, EventArgs e)
        {
            // validatng that there must be data texted or selected to save 
            if ((Metric1txt.Text == "" && yogatype_box.Text=="" && swimming_combo.Text == "") || Metric2txt.Text == "" || Metric3txt.Text == "")
            {
                MessageBox.Show("Please, Enter all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        

            response = MessageBox.Show("Do you want to save the record?", "Information", MessageBoxButtons.YesNo);
            if (response == DialogResult.No) return;

            //Adding an activity record into the database 
            if (activity == "Swimming")
            {
                string m0 = swimming_combo.SelectedItem.ToString();
                MetCombo sm = new MetCombo();
                m1 = sm.SwimmingToMet(m0);
                //m1 = float.Parse(Metric1txt.Text);
                m2 = float.Parse(Metric2txt.Text);
                m3 = float.Parse(Metric3txt.Text);

                if ((m2 < 10f) || (m2 > 120f))
                {
                    MessageBox.Show("The duration of swimming should be between 10 to 120 minutes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if ((m3 < 30) || (m3 > 200))
                {
                    MessageBox.Show("The weight of the user should be from 20 to 200 kg", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SwimmingEx se = new SwimmingEx(m1, m2, m3);
                curCal = se.SwimmingExercise();

                se.SaveSwimmingEx(uid, aid, m1, m2, m3, curCal);

                int tarCal = GlobalData._TargetCalorie;
                decimal totalCal = se.CurrentTotalCal(uid);
                if (totalCal >= tarCal)
                    MessageBox.Show("Congratulation!!!You have archived your goal!!!", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CalorieBurned_label.Text = "Calorie Burned = " + curCal.ToString() + "cal";
                MessageBox.Show("Record is saved successfully \nPlease Refresh the form", "Saving Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (activity == "Walking")
            {

                m1 = float.Parse(Metric1txt.Text); //height
                m2 = float.Parse(Metric2txt.Text); //weight
                m3 = float.Parse(Metric3txt.Text); //steps


                if ((m1 < 100f) || (m1 > 250f))
                {
                    MessageBox.Show("The height should be from 100 to 250 cm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if ((m2 < 30f) || (m2 > 200f))
                {
                    MessageBox.Show("The weight of the user should be from 30 to 200 kg", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if ((m3 < 20f) || (m3 > 50000f))
                {
                    MessageBox.Show("The steps should be from 20 to 50000 steps", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                WalkingEx we = new WalkingEx(m1, m2, m3);
                curCal = we.WalkingExercise();
                


                we.SaveWalkingExercise(uid, aid, m1, m2, m3, curCal);
                int tarCal = GlobalData._targetCalorie;
                decimal totalCal = we.CurrentTotalCal(uid);
                if (totalCal >= tarCal)
                    MessageBox.Show("Congratulation!!!You have archived your goal!!!", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CalorieBurned_label.Text = "Calorie Burned = " + curCal.ToString() + "cal";
                MessageBox.Show("Record is saved successfully \nPlease Refresh the form", "Saving Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            else if (activity == "Skipping Rope")
            {

                m1 = float.Parse(Metric1txt.Text);
                m2 = float.Parse(Metric2txt.Text);
                m3 = float.Parse(Metric3txt.Text);

                if ((m1 < 10f) || (m1 > 2500f))
                {
                    MessageBox.Show("The skips should be from 10 to 2500 ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }   
                if ((m2 < 30f) || (m2 > 200f))
                {
                    MessageBox.Show("The weight of the user should be from 30 to 200 kg", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if ((m3 < 1f) || (m3 > 120f))
                {
                    MessageBox.Show("The time duration should be from 1 to 120 mins", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SkippingRopeEX se = new SkippingRopeEX(m1, m2, m3);
                curCal = se.SkipRopeExercise();

                se.SaveSkipropeActivity(uid, aid, m1, m2, m3, curCal);

                int tarCal = GlobalData._targetCalorie;
                decimal totalCal = se.CurrentTotalCal(uid);
                if (totalCal >= tarCal)
                    MessageBox.Show("Congratulation!!!You have archived your goal!!!", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CalorieBurned_label.Text = "Calorie Burned = " + curCal.ToString() + "cal";
                MessageBox.Show("Record is saved successfully \nPlease Refresh the form", "Saving Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (activity == "Cycling")
            {

                m1 = float.Parse(Metric1txt.Text); //mile
                m2 = float.Parse(Metric2txt.Text); //hour
                m3 = float.Parse(Metric3txt.Text); //kg

                if ((m1 < 0.5f) || (m1 > 180f))
                {
                    MessageBox.Show("The distance of cycling should be from 0.5 to 180 miles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if ((m2 < 0.5f) || (m2 > 8f))
                {
                    MessageBox.Show("The duratoin of cycling should be from 0.5 to 8 hours", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if ((m3 < 30f) || (m3 >  200f))
                {
                    MessageBox.Show("The weight of the user should be from 30 to 200 kg", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CyclingEx ce = new CyclingEx(m1, m2, m3);
                curCal = ce.CyclingExercise();

                ce.SaveCyclingEx(uid, aid, m1, m2, m3, curCal);

                int tarCal = GlobalData._targetCalorie;
                decimal totalCal = ce.CurrentTotalCal(uid);
                if (totalCal >= tarCal)
                    MessageBox.Show("Congratulation!!!You have archived your goal!!!", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CalorieBurned_label.Text = "Calorie Burned = " + curCal.ToString() + "cal";
                MessageBox.Show("Record is saved successfully \nPlease Refresh the form", "Saving Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (activity == "Jogging")
            {

                m1 = float.Parse(Metric1txt.Text); //distance
                m2 = float.Parse(Metric2txt.Text); //hour
                m3 = float.Parse(Metric3txt.Text); // kg

                if ((m1 < 0.5f) || (m1 > 20f))
                {
                    MessageBox.Show("The distance of jogging should be from 0.5 to 20 miles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if ((m2 < 0.5f) || (m2 > 4f))
                {
                    MessageBox.Show("THe duratoin of jogging should be from 0.5 to 4 hours", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if ((m3 < 30f) || (m3 > 200f))
                {
                    MessageBox.Show("The weight of the user should be from 30 to 200 kg", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                JoggingEx je = new JoggingEx(m1, m2, m3);
                curCal = je.JoggingExercies();


                je.SaveJogging(uid, aid, m1, m2, m3, curCal);
                int tarCal = GlobalData._targetCalorie;
                decimal totalCal = je.CurrentTotalCal(uid);
                if (totalCal >= tarCal)
                    MessageBox.Show("Congratulation!!!You have archived your goal!!!", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CalorieBurned_label.Text = "Calorie Burned = " + curCal.ToString() + "cal";
                MessageBox.Show("Record is saved successfully \nPlease Refresh the form", "Saving Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (activity == "Yoga")
            {

                string m0 = yogatype_box.SelectedItem.ToString();
                MetCombo YM = new MetCombo();
                m1 = YM.Yogamet(m0);
                m2 = float.Parse(Metric2txt.Text);
                m3 = float.Parse(Metric3txt.Text);

                if ((m2 < 10f) || (m2 > 90))
                {
                    MessageBox.Show("The duratoin of yoga should be from 10 to 90 minutes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if ((m3 < 30f) || (m3 > 200f))
                {
                    MessageBox.Show("The weight of the user should be from 30 to 200 kg", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                YogaEx je = new YogaEx(m1, m2, m3);
                curCal = je.YogaExercise();


                je.SaveYoga(uid, aid, m1, m2, m3, curCal);
                int tarCal = GlobalData._targetCalorie;
                decimal totalCal = je.CurrentTotalCal(uid);
                if (totalCal >= tarCal)
                    MessageBox.Show("Congratulation!!!You have archived your goal!!!", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //CalorieBurned_label.Text = "Success";
                CalorieBurned_label.Text = "Calorie Burned = " + curCal.ToString() + "cal";
                MessageBox.Show("Record is saved successfully \nPlease Refresh the form", "Saving Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


            ExerciseClass ec = new ExerciseClass();
            curCal = (float)ec.CurrentTotalCal(uid);
            PresentCalorie_label.Text = "Current Calories = " +curCal + "cal";
            float goal = GlobalData._TargetCalorie;

            //showing how much progress has done to reach goal on progress bar
            if (curCal >= goal)
            {
                PBar.Value = 100;
            }
            else
            {
                PBar.Value = (int) ((curCal / goal) * 100f);
            }

        }




        //For Edit Click

        private void Edit__Click(object sender, EventArgs e)
        {
            //Validating to ensure there is data in the metirc before editing
            if (Metric1txt.Text == "" || Metric2txt.Text == "" || Metric3txt.Text == "")
            {
                MessageBox.Show("Enter all the fields");
                return;
            }

            response = MessageBox.Show("Do you want to edit the record?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (response == DialogResult.No) return;


            try
            {
                
                    if (activity == "Swimming")
                    {
                        string m0 = swimming_combo.SelectedItem.ToString();
                        MetCombo sm = new MetCombo();
                        m1 = sm.SwimmingToMet(m0);
                        //m1 = float.Parse(Metric1txt.Text);
                        m2 = float.Parse(Metric2txt.Text);
                        m3 = float.Parse(Metric3txt.Text);

                        if ((m2 < 10f) || (m2 > 120f))
                        {
                            MessageBox.Show("The duration of swimming should be from 10 to 120 minutes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if ((m3 < 30) || (m3 > 200))
                        {
                            MessageBox.Show("The weight of the user should be from 20 to 200 kg", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        SwimmingEx se = new SwimmingEx(m1, m2, m3);
                        curCal = se.SwimmingExercise();

                        int tarCal = GlobalData._targetCalorie;
                        decimal totalCal = se.CurrentTotalCal(uid);
                        if (totalCal >= tarCal)
                        {
                            MessageBox.Show("Congratulation!!!You have archived your goal!!!", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        se.EditingSwimmingEx(mid, uid, aid, m1, m2, m3, curCal);
                        MessageBox.Show("Record is edited successfully \nPlease Refresh the form", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else if (activity == "Walking")
                    {

                        m1 = float.Parse(Metric1txt.Text);
                        m2 = float.Parse(Metric2txt.Text);
                        m3 = float.Parse(Metric3txt.Text);

                        if ((m1 < 100f) || (m1 > 250f))
                        {
                            MessageBox.Show("The height should be from 100 to 250 cm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if ((m2 < 30f) || (m2 > 200f))
                        {
                            MessageBox.Show("The weight of the user should be from 30 to 200 kg", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if ((m3 < 20f) || (m3 > 50000f))
                        {
                            MessageBox.Show("The steps should be from 20 to 50000 steps", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        WalkingEx we = new WalkingEx(m1, m2, m3);
                        curCal = we.WalkingExercise();

                        int tarCal = GlobalData._targetCalorie;
                        decimal totalCal = we.CurrentTotalCal(uid);
                        if (totalCal >= tarCal)

                        {
                            MessageBox.Show("Congratulation!!!You have archived your goal!!!", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        we.EditWalkingExercise(mid, uid, aid, m1, m2, m3, curCal);
                        MessageBox.Show("Record is edited successfully \nPlease Refresh the form", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (activity == "Skipping Rope")
                    {

                        m1 = float.Parse(Metric1txt.Text);
                        m2 = float.Parse(Metric2txt.Text);
                        m3 = float.Parse(Metric3txt.Text);

                        if ((m1 < 10f) || (m1 > 2500f))
                        {
                            MessageBox.Show("The skips should be from 10 to 2500", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if ((m2 < 30f) || (m2 > 200f))
                        {
                            MessageBox.Show("The weight of the user should be from 30 to 200 kg", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if ((m3 < 1f) || (m3 > 120f))
                        {
                            MessageBox.Show("The time duration should be from 1 to 120 minutes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        SkippingRopeEX se = new SkippingRopeEX(m1, m2, m3);
                        curCal = se.SkipRopeExercise();

                        int tarCal = GlobalData._targetCalorie;
                        decimal totalCal = se.CurrentTotalCal(uid);
                        if (totalCal >= tarCal)

                        {
                            MessageBox.Show("Congratulation!!!You have archived your goal!!!", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        se.EditSkipropeActivity(mid, uid, aid, m1, m2, m3, curCal);
                        MessageBox.Show("Record is edited successfully \nPlease Refresh the form", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (activity == "Cycling")
                    {

                        m1 = float.Parse(Metric1txt.Text);
                        m2 = float.Parse(Metric2txt.Text);
                        m3 = float.Parse(Metric3txt.Text);

                        if ((m1 < 0.5f) || (m1 > 180f))
                        {
                            MessageBox.Show("The distance of cycling should be from 0.5 to 180 miles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if ((m2 < 0.5f) || (m2 > 8f))
                        {
                            MessageBox.Show("The duratoin of cycling should be from 0.5 to 8 hours", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if ((m3 < 30f) || (m3 > 200f))
                        {
                            MessageBox.Show("The weight of the user should be from 30 to 200 kg", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        CyclingEx ce = new CyclingEx(m1, m2, m3);
                        curCal = ce.CyclingExercise();

                        int tarCal = GlobalData._targetCalorie;
                        decimal totalCal = ce.CurrentTotalCal(uid);
                        if (totalCal >= tarCal)

                        {
                            MessageBox.Show("Congratulation!!!You have archived your goal!!!", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        ce.EditCyclngEx(mid, uid, aid, m1, m2, m3, curCal);
                        MessageBox.Show("Record is edited successfully \nPlease Refresh the form", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (activity == "Jogging")
                    {

                        m1 = float.Parse(Metric1txt.Text);
                        m2 = float.Parse(Metric2txt.Text);
                        m3 = float.Parse(Metric3txt.Text);

                        if ((m1 < 0.5f) || (m1 > 20f))
                        {
                            MessageBox.Show("THe distance of jogging should be from 0.5 to 20 miles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if ((m2 < 0.5f) || (m2 >4f))
                        {
                            MessageBox.Show("THe duratoin of jogging should be from 0.5 to 4 hours", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if ((m3 < 30f) || (m3 > 200f))
                        {
                            MessageBox.Show("THe weight of the user should be from 30 to 200 kg", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        JoggingEx je = new JoggingEx(m1, m2, m3);
                        curCal = je.JoggingExercies();

                        int tarCal = GlobalData._targetCalorie;
                        decimal totalCal = je.CurrentTotalCal(uid);
                        if (totalCal >= tarCal)

                        {
                            MessageBox.Show("Congratulation!!!You have archived your goal!!!", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        je.EditJogging(mid, uid, aid, m1, m2, m3, curCal);
                        MessageBox.Show("Record is edited successfully \nPlease Refresh the form", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (activity == "Yoga")
                    {

                        string m0 = yogatype_box.SelectedItem.ToString();
                        MetCombo YM = new MetCombo();
                        m1 = YM.Yogamet(m0);
                        m2 = float.Parse(Metric2txt.Text);
                        m3 = float.Parse(Metric3txt.Text);

                        if ((m2 < 10f) || (m2 > 90))
                        {
                            MessageBox.Show("The duratoin of yoga should be from 10 to 90 minutes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if ((m3 < 30f) || (m3 > 200f))
                        {
                            MessageBox.Show("The weight of the user should be from 30 to 200 kg", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        YogaEx ye = new YogaEx(m1, m2, m3);
                        curCal = ye.YogaExercise();

                        int tarCal = GlobalData._targetCalorie;
                        decimal totalCal = ye.CurrentTotalCal(uid);
                        if (totalCal >= tarCal)

                        {
                            MessageBox.Show("Congratulation!!!You have archived your goal!!!", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        ye.EditYoga(mid, uid, aid, m1, m2, m3, curCal);
                        MessageBox.Show("Record is edited successfully \nPlease Refresh the form", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    






                
            }
            catch (Exception ee) { conn.Close(); };

            conn.Close();

            ExerciseClass ft = new ExerciseClass();
            curCal = (float)ft.CurrentTotalCal(uid);
            PresentCalorie_label.Text = "Current Calories = " + curCal + "cal";


            // to show how much progress has done to reach the target caloires on progress bar
            float goal = GlobalData._TargetCalorie;
            if (curCal == goal)
            {
                PBar.Value = 100;
            }
            else
            {
                PBar.Value = (int)((curCal / goal) * 100f);
            }
        }


        


        // For Refresh btn
        private void Refresh__Click(object sender, EventArgs e)
        {
            //to refresh the form to show updated data
            DbClass db = new DbClass();
            uid = GlobalData._UserId;
            int index = combo_act.SelectedIndex + 1;
            dataGridView1.DataSource = db.Get_Table(uid, index);
            dataGridView1.DataMember = "User_Act_Metric";

            float goal = GlobalData._TargetCalorie;

            ExerciseClass ec = new ExerciseClass();
            curCal = (float) ec.CurrentTotalCal(uid);
            if(curCal>= goal)
            {
                //letting user to choose wether to reset the activty record and target calories or not
                response = MessageBox.Show("Now that You have successfully hit your calories-burning goal, you can reset your target calories and activity record if you are ready for the new challenger." +
                    "\nWould you like to procceed the reset?", "Information", MessageBoxButtons.YesNo,MessageBoxIcon.Information);

                if (response == DialogResult.No)
                {
                    return;
                }

                //Reseting the target calories 
                else
                {
                    string input = Interaction.InputBox("Enter new target calories", "Reset target calories");
                    if (int.TryParse(input, out int numericValue))
                    {
                        float new_tarcal = float.Parse(input);
                        
                        try
                        {
                            db.Reset_TarCal(uid, new_tarcal);
                            GlobalData._TargetCalorie=(int)new_tarcal;
                        }
                        catch (Exception ex) { MessageBox.Show("There is an error"); return; }

                        MessageBox.Show("You have successfull reset your target calories and activity reocrd!\nWelcome from your new challenge!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Resting Process was failed because user ceased the process or didn't put numeric value", "Process Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
            }
            PresentCalorie_label.Text = "Current Calories = " + curCal + "cal";
            TarCal_label.Text = "Target Calories = " + goal + "cal";

        }



    }
}
