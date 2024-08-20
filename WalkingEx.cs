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
    internal class WalkingEx: ExerciseClass
    {
        public WalkingEx(float m1, float m2, float m3) // constructor to assign values of MetricValue1, MetricValue2 and MetricValue3
        {
            MetricValue1 = m1;
            MetricValue2 = m2;
            MetricValue3 = m3;
        }
        
        public float WalkingExercise() // method to calculate the calories burned by walking exercise
        {
            float stride = (MetricValue1/100) * 0.414f; //height * 0.414
            float distance = stride * MetricValue3; //stride * steps
            float time = distance / 1.34f;
            float calories = time * 3.5f * 3.5f * MetricValue2 / (200 * 60); //Matric2Value=>weigh
            return calories;
        }


        //to save a swimming activity record 
        public void SaveWalkingExercise(int uid, int aid, float m1, float m2, float m3, float curcal)
        {
            DbClass db = new DbClass();
            db.Save(uid, aid, m1, m2, m3, curcal);
        }

        //to delete a swimming activity record 
        public void DeleteWalkingExercise (int mid, int uid, int aid)
        {
            DbClass db = new DbClass();
            db.Delete(mid, uid, aid);
        }

        //to edit a swimming activity record 
        public void EditWalkingExercise(int mid, int uid, int aid, float m1, float m2, float m3, float curcal)
        {
            DbClass db = new DbClass();
            db.Edit(mid, uid, aid, m1, m2, m3, curcal);
        }
    }
}
