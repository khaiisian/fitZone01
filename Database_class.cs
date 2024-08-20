using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Runtime.Remoting;
using fitZone01;
using System.Security.Cryptography;

namespace fitZone01
{
    public class DbClass
    {
        OleDbCommand mycmd;
        OleDbConnection conn;
        string constr;

        public DbClass() //Constructor of DbClass
        {

            constr = "Provider=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=" + Application.StartupPath + @"\fitZone01DB.mdb";
            conn = new OleDbConnection();
            conn.ConnectionString = constr;
        }

        //GetMaxUserID
        private int get_Max_UserId() //private method returning the maximal id for the new user as integer from the user table
        {
            mycmd = new OleDbCommand();
            mycmd.Connection = conn;

            int id = 0;
            string query = "Select Max(uid) from [User]";
            mycmd.CommandText = query;
            try
            {
                conn.Open();
                if (mycmd.ExecuteScalar()!=DBNull.Value) 
                    id = Convert.ToInt32(mycmd.ExecuteScalar().ToString());
                else id = 0;
                return id + 1;
            }
            catch (OleDbException oex) 
            { 
                throw oex; 
            }
            finally
            {
                conn.Close();
            }
        }

        //CreateAccount
        //public method To insert a record row of new customer information into User table
        public void Create_Account(fitZone01User c)  //carry input parameter from fitZone01User
        {

            int id = get_Max_UserId();   //Get last user ID from DB
            string query = "INSERT INTO [User] VALUES " + "(" + id + ",'" + c.Username + "','" + c.Password + "','" + c.Email + "','" + c.Targetcal + "')";

            conn.Open();
            mycmd = new OleDbCommand(query, conn);

            mycmd.ExecuteScalar();
            conn.Close();

        }

        //GetMaxActivityID
        private int Get_Max_ActivityId()  //private method returining the maximal id as integer for new the record of the calories burned activity of the user
        {
            mycmd = new OleDbCommand();
            mycmd.Connection = conn;

            int id = 0;
            string query = "Select MAX(mid) from [User_Act_Metric]";
            mycmd.CommandText = query;
            try
            {
                conn.Open();
                if (mycmd.ExecuteScalar() != DBNull.Value)
                    id = Convert.ToInt32(mycmd.ExecuteScalar().ToString());
                else id = 0;

                return (id + 1);
            }
            catch (OleDbException oex) { throw oex; }
            finally
            {
                conn.Close();
            }             
        }

        //CheckExistingUser
        // public method to check if there any data with the same username as user inputted in the User table
        public int Check_Existing_User(string inputUserName) // returning int datatype
        {
            int id = 0;
            string query = "Select uid from [User] where name='" + inputUserName + "'";

            mycmd = new OleDbCommand();
            mycmd.Connection = conn;
            mycmd.CommandText = query;
            try
            {

                conn.Open();

                OleDbDataReader reader = mycmd.ExecuteReader();
                while (reader.Read())
                {
                    id = Int32.Parse(reader.GetValue(0).ToString());     //array position "0" value = id of the user
                }

            }
            catch (OleDbException oe) { }
            conn.Close(); 
            return id; //returning id of the user with the same username as user inputted
        }


        //CheckRegCustomer
        //puublic method to check if there are any record with username and password as user inputted in the User table
        public fitZone01User Check_Reg_Customer(string username, string password)
        {
            fitZone01User c = new fitZone01User();
            int id = 0, tarCal = 0;
            //for MSAccess case sensitive StrComp(Table1.Field1, Table2.Field2, 0) = 0
            string query = "Select * from [User] where name='" + username + "' and StrComp(password,'" + password + "',0)=0";
            mycmd = new OleDbCommand();
            mycmd.Connection = conn;
            mycmd.CommandText = query;
            try
            {
                conn.Open();
                OleDbDataReader reader = mycmd.ExecuteReader();
                while (reader.Read())
                {
                    id = Int32.Parse(reader.GetValue(0).ToString()); //column(0) = id of the user
                    tarCal = Int32.Parse(reader.GetValue(4).ToString());

                }
                c.Id = id;
                c.Targetcal = tarCal;

            }
            catch(OleDbException oe) { }
            conn.Close();
            return c;  //returning fitZone01User object
        }

        //Dataset_getTable
        //public method of Getting the required colums from the tables in Access to create a data gridview table
        public DataSet Get_Table(int uid,int aid)
        {
            string sql = "SELECT [User_Act_Metric].mid, [Activity].activity_name, [User_Act_Metric].aid, [User_Act_Metric].metric1, [User_Act_Metric].metric2, [User_Act_Metric].metric3,[User_Act_Metric].cal_burned" +
                " FROM [Activity] INNER JOIN [User_Act_Metric] ON [Activity].aid = [User_Act_Metric].aid" +
                " Where [User_Act_Metric].uid = " + uid + " AND [User_Act_Metric].aid = " + aid;
            OleDbConnection connection = new OleDbConnection(constr);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataAdapter.Fill(ds, "User_Act_Metric");
            connection.Close();
            return ds; //returning table
        }

        //public method to get the required columns to create the history table of all the activities that user has done and calories burned of each activity 
        public DataSet Get_User_Act(int uid)
        {
            string sql = "SELECT [User_Act_Metric].uid, [User_Act_Metric].mid, [Activity].activity_name, [User_Act_Metric].cal_burned" +
                " FROM [Activity] INNER JOIN [User_Act_Metric] ON [Activity].aid = [User_Act_Metric].aid" +
                " Where [User_Act_Metric].uid = " + uid;
            
            OleDbConnection connection = new OleDbConnection(constr);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataAdapter.Fill(ds, "UserActTable");
            connection.Close();
            return ds;
        }


        //getActivities
        //public method To get the activity name as a list from the activity from the Activity table
        public List<string> Get_Activities()
        {
            var items = new List<string>();
            items.Add("none");

            string query = "Select activity_name from [Activity] order by aid";
            mycmd = new OleDbCommand();
            mycmd.Connection = conn;
            mycmd.CommandText = query;
            try
            {
                conn.Open();

                OleDbDataReader myreader = mycmd.ExecuteReader();
                items.Clear();
                while (myreader.HasRows)
                {
                    myreader.GetName(0);
                    while (myreader.Read())
                    {
                        items.Add(Convert.ToString(myreader.GetValue(0).ToString()));
                    }
                    myreader.NextResult();
                }
            }
            catch (OleDbException oex) { throw oex; }
            finally
            {
                conn.Close();
            }
            return items; //returning as list
        }

        //CurrentTotalCalories
        public decimal Current_Total_Calories(int uid)  //public method To get the present total calories of the user as the decimal by the sum of the values in the curcal column from the User_Act_Metric table
        {


            mycmd = new OleDbCommand();
            mycmd.Connection = conn;
            decimal totalcal = 0;

            string query = "Select SUM(cal_burned) from [User_Act_Metric] WHERE uid=" + uid + " GROUP BY uid";
            mycmd.CommandText = query;
            try
            {
                conn.Open();

                OleDbDataReader reader = mycmd.ExecuteReader();
                while (reader.Read())
                {
                  totalcal = Decimal.Parse(reader.GetValue(0).ToString());

                }
            }
            catch (System.NullReferenceException oex) { throw oex; }
           
            
            return totalcal;



        }

        // To reset the target calorie of the user
        public void Reset_TarCal(int uid, float cal)
        {
            mycmd = new OleDbCommand();
            mycmd.Connection = conn;
            conn.Open();

            string query = "UPDATE [User] SET targetCal=" + cal + " WHERE uid=" + uid;
            mycmd.CommandText = query;

            mycmd.ExecuteNonQuery();

            query = "DELETE FROM [User_Act_Metric] WHERE uid=" + uid;
            mycmd.CommandText = query;
            mycmd.ExecuteNonQuery();

            conn.Close();
        }

        //to save the activity record 
        public void Save(int uid, int aid, float m1, float m2, float m3, float curcal)
        {
            int mid = Get_Max_ActivityId(); //get the max id for new record in User_Act_Metric
            string query = "INSERT INTO [User_Act_Metric] VALUES " + "(" + mid + "," + uid + "," + aid + "," + m1 + "," + m2 + "," + m3 + "," + curcal + ")";
            //saving a new record in the User_Act_Metric 
            conn.Open();
            mycmd = new OleDbCommand(query, conn);

            mycmd.ExecuteScalar();
            conn.Close();
        }

        //to edit the activity record 
        public void Edit(int mid, int uid, int aid, float m1, float m2, float m3, float curcal)
        {
            string query = "UPDATE [User_Act_Metric] SET metric1=" + m1 + ", metric2=" + m2 + ", metric3=" + m3 + ", cal_burned=" + curcal + " WHERE mid=" + mid + " AND uid=" + uid + " AND aid=" + aid;
            //Editing the existing record in the User_Act_Metric
            conn.Open();
            mycmd = new OleDbCommand( query, conn);

            mycmd.ExecuteScalar();  
            conn.Close();
        }

        //to delete the activity record 
        public void Delete(int mid, int uid, int aid)
        {
            string query = "DELETE FROM [User_Act_Metric] WHERE mid=" + mid +" AND uid=" + uid + " AND aid=" + aid;
            //Deleting a recrod inthe User_Act_Metric table
            conn.Open();
            mycmd = new OleDbCommand(query, conn);

            mycmd.ExecuteScalar();
            conn.Close();
        }

        //to delete the activity record in history of profile
        public void Delete_History(int uid, int mid)
        {
            string query = "DELETE FROM [User_Act_Metric] WHERE mid=" + mid + " AND uid=" + uid;
            conn.Open();
            mycmd = new OleDbCommand(query,conn);
            mycmd.ExecuteScalar();
            conn.Close();
        }
    }
}
