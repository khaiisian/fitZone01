using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitZone01
{
    internal class SwimmingEx: ExerciseClass
    {
        public SwimmingEx(float m1, float m2,float m3) //constructor to assign values of MetricValue1, MetricValue2 and MetricValue3
        {
            MetricValue1 = m1;
            MetricValue2 = m2;  
            MetricValue3 = m3;
        }

        public float SwimmingExercise() // method to calcuate the calories burned of swimming exercise 
        {

            float cal_rate = (float)(MetricValue1 * MetricValue3 * 3.5) / 200; // calories burned rate = MET x weight x 3.5 / 200
            float cal = cal_rate * MetricValue2; // calories burned = caloires burned rate x time

            return cal;
        }

        //to save a swimming activity record 
        public void SaveSwimmingEx(int uid, int aid, float m1, float m2,float m3,float curcal)
        {
            DbClass db = new DbClass();
            db.Save(uid, aid, m1, m2, m3, curcal);
        }

        //to edit a swimming activity record 
        public void EditingSwimmingEx(int mid, int uid, int aid, float m1, float m2,float m3,float curcal)
        {
            DbClass db = new DbClass();
            db.Edit(mid, uid, aid, m1, m2, m3, curcal);
        }

        //to delete a swimming activity record 
        public void DeleteSwimmingEx(int mid, int uid, int aid)
        {
            DbClass db = new DbClass();
            db.Delete(mid, uid, aid);
        }
    }
}
