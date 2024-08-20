using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fitZone01
{
    internal class YogaEx: ExerciseClass
    {
        public YogaEx(float m1, float m2, float m3) // constructor that assigns values of MetricValue1, MetricValue2, MetricValue3
        {
            MetricValue1 = m1; //MET
            MetricValue2 = m2; //time
            MetricValue3 = m3; //weight
        }

        public float YogaExercise() // method to calculate the calories burned of a yoga exercise
        {                            
            float cal_rate = (MetricValue1 * MetricValue3 * 3.5f) / 200;
            float cal = cal_rate * MetricValue2;
            return cal;
        }

        //to save a swimming activity record 
        public void SaveYoga(int uid, int aid, float m1, float m2, float m3, float curcal)
        {
            DbClass db = new DbClass();
            db.Save(uid, aid, m1, m2, m3, curcal);
        }

        //to edit a swimming activity record 
        public void EditYoga(int mid, int uid, int aid, float m1, float m2, float m3, float curcal)
        {
            DbClass db = new DbClass();
            db.Edit(mid, uid, aid, m1, m2, m3, curcal);
        }

        //to delete a swimming activity record 
        public void DeleteYoga(int mid, int uid, int aid)
        {
            DbClass db = new DbClass();
            db.Delete(mid, uid, aid);
        }
    }
}

