using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitZone01
{
    public class fitZone01Person
    {
        String username;
        String password;
        String email;

        public fitZone01Person()
        { }

        public String Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public String Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public String Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public virtual Boolean Login(string username, string userpass)
        {
            if (username == this.username && userpass == this.password)return true;
            else return false;
        }
    }

    
}
