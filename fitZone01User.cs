using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitZone01;

namespace fitZone01
{
    public class fitZone01User: fitZone01Person
    {
        int id;
        int TargetCal;

        //retrieving and assigning value into id and TargetCal
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public int Targetcal
        {
            get
            {
                return TargetCal;
            }
            set
            {
                TargetCal = value;
            }
        }


        // Method to check if registration sucessful or not
        public Boolean Register(fitZone01User user)
        {
            DbClass dbc = new DbClass();    //creating an object of DbClass
            if (dbc.Check_Existing_User(user.Username) == 0) // checking if there is already a user with thhe same username
            {
                dbc.Create_Account(user); //creating an account
                return true; 
            }
            else
                return false;
        }


        // Method to check if login successful or not
        public override bool Login(string username, string userpass)
        {
            DbClass db = new DbClass();        
            fitZone01User c = new fitZone01User();          
            c = db.Check_Reg_Customer(username, userpass);     
            GlobalData._UserId = c.Id;           
            GlobalData._TargetCalorie = c.TargetCal;
            
            if (GlobalData._UserId !=0)
                return true;
            else
                return false;
        }
    }
}
