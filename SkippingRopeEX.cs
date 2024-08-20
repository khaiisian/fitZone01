using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitZone01;
using System.Windows.Forms.Design;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace fitZone01
{
    internal class SkippingRopeEX : ExerciseClass
    {
       public SkippingRopeEX(float m1, float m2, float m3) //constructor to assignin values of MetricValue1, MetricValue2 and MetricValue3
        {
            MetricValue1 = m1; //skip
            MetricValue2 = m2; //weight
            MetricValue3 = m3; //time

        }

        public float SkipRopeExercise() // method to calcuate the calories burned of skipping rope exercise 
        {

            float met = 1;
            float skip_rate = MetricValue1 / MetricValue3; 

            //Defining MET depending on the skip_rate
            if (skip_rate <= 100f)
            {
                met = 8.8f;
            }
            else if (skip_rate > 100f && skip_rate <= 120f)
            {
                met = 11.8f;
            }
            else if (skip_rate > 120f && skip_rate <= 160f)
            {
                met = 12.3f;
            }
            else if (skip_rate > 160f && skip_rate <= 200f)
            {
                met = 13.6f;
            }
            else if (skip_rate > 200)
            {
                met = 15f;
            }
            

            float cal_rate = met * MetricValue2 * 7 / 400; // calories burned rate = MET x weight x 7 /400
            float calories = cal_rate * MetricValue3; // calories burned =  calories burned rate x time
            //calories = calories * 1000;

            return calories;
        }

        //to save a skipping rope activity record 
        public void SaveSkipropeActivity(int uid, int aid, float m1, float m2, float m3, float curcal)
        {
            DbClass db = new DbClass();
            db.Save(uid, aid, m1, m2, m3, curcal);
        }

        //to edit a skipping rope activity record 
        public void EditSkipropeActivity(int mid, int uid, int aid, float m1, float m2, float m3, float curcal)
        {
            DbClass db = new DbClass();
            db.Edit(mid, uid, aid, m1, m2, m3, curcal);
        }
        //to delete a skipping rope activity record 
        public void DeleteSkipropeActivity(int mid, int uid, int aid)
        {
            DbClass db = new DbClass();
            db.Delete(mid, uid, aid);
        }
    }
}
