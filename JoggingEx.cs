using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitZone01
{
    internal class JoggingEx: ExerciseClass
    {
        public JoggingEx(float m1, float m2, float m3) //constructor that assigns values for MetricValue1,MetricValue2 and MetricValue3
        {
            MetricValue1 = m1; //mile
            MetricValue2 = m2; //time
            MetricValue3 = m3; //wgt
        }

        public float JoggingExercies() // method to calcuate the calories burned of jogging exercise 
        {
            float met=1;
            float rate = MetricValue1 / MetricValue2; //speed = mile/time (mph)
            
            //Defining MET depending on the speed 
            if (rate <=3f)
            {
                met = 3f;
            }
            else if (rate > 3f && rate <=5f)
            {
                met = 5.5f;
            }
            else if (rate > 5f && rate <= 6.5f)
            {
                met = 8f;
            }
            else if (rate > 6.5f && rate <= 7.5f)
            {
                met = 10f;
            }
            else if (rate > 7.5f && rate < 8.5f)
            {
                met =12.5f;
            }
            else if (rate > 8.5f)
            {
                met = 14f;
            }

            float cal_rate = (met * MetricValue3 * 3.5f)/200; // calories burned rate = (MET x wgt x 3.5)/200
            float cal = cal_rate * MetricValue2;    // calories burned = calories burnedd rate x time
            return cal;
        }

        // to save the jogging activity record to the database
        public void SaveJogging(int uid, int aid, float m1, float m2, float m3, float curcal)
        {
            DbClass db = new DbClass();
            db.Save(uid, aid, m1, m2, m3, curcal);
        }


        // to edit the jogging activity record to the database
        public void EditJogging(int mid, int uid, int aid, float m1, float m2, float m3, float curcal)
        {
            DbClass db = new DbClass();
            db.Edit(mid, uid, aid, m1, m2, m3, curcal);
        }

        // to delete the jogging activity record to the database

        public void DeleteJogging(int mid, int uid, int aid)
        {
            DbClass db = new DbClass();
            db.Delete(mid, uid, aid);
        }
    }
}

