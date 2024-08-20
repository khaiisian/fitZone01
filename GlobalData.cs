using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitZone01
{
    static class GlobalData
    {
        private static string _username = "";
        private static int _userid = 0;
        public static int _targetCalorie = 0;

        // retrieving and setting constant values
        public static string _Username
        {
            get { return _username; }
            set { _username = value; }
        }
        
        public static int _UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }

        public static int _TargetCalorie
        { 
            get { return _targetCalorie; }
            set { _targetCalorie = value;}
        }  
    }
}
