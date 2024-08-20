using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitZone01;

namespace fitZone01
{
    public class ExerciseClass
    {
        float metric1;
        float metric2;
        float metric3;

        public float MetricValue1 // to retreive and assign the value of metric1
        {
            get { return metric1; }
            set { metric1 = value; }
        }
        
        public float MetricValue2 // to retreive and assign the value of metric2
        {
            get { return metric2; }
            set { metric2 = value; }
        }

        public float MetricValue3 // to retreive and assign the value of metric3
        {
            get { return metric3; }
            set { metric3 = value; }
        }

        public decimal CurrentTotalCal(int uid) //method to return the current total calories
        {
            DbClass db = new DbClass(); // creating instances of DbClass
            return db.Current_Total_Calories(uid);
        }
    }
}
