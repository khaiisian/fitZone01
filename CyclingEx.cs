using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitZone01
{
    internal class CyclingEx : ExerciseClass
    {
        public CyclingEx(float m1, float m2, float m3) //constructor that assigns values of MetricValue1, MetricValue2 and MetricValue3
        {
            MetricValue1 = m1; //mile
            MetricValue2 = m2; //time
            MetricValue3 = m3; //wgt
        }

        public float CyclingExercise() // method to calcuate the calories burned of cycling exercise 
        {
            float met = 1; 

            float rate = MetricValue1 /  MetricValue2;

            //Defining Met Depending on the speed
            if (rate <= 3f)
            {
                met = 2f;
            }
            else if (rate > 3f && rate <= 5.5f)
            {
                met = 3.5f;
            }
            else if (rate > 5.5f && rate <= 10f)
            {
                 met = 4f;
            }
            else if(rate>10f && rate <= 11.9f)
            {
                 met = 6.8f;
            }
            else if (rate > 11.9f && rate <= 13.9f)
            {
                 met = 8f;
            }
            else if (rate > 13.9f && rate <= 15.9f)
            {
                 met = 9.5f;
            }
            else if (rate > 15.9f && rate <= 19.9f)
            {
                 met = 12f;
            }
            else if (rate > 19.9f)
            {
                 met = 16f;
            }
            

            float cal = (MetricValue2 * 60f * met * 3.5f * MetricValue3)/ 200f; //calories = time x 60 x MET x 3.5 x weight
            //cal = cal * 1000f;
            return cal;
        }

        //to add a cycling record into the database 
        public void SaveCyclingEx(int uid, int aid, float m1, float m2, float m3, float curcal)
        { 
            DbClass db = new DbClass(); // creating instance of DbClass
            db.Save(uid, aid, m1, m2, m3, curcal); // Using Save method form DbClass
        }

        // to edit a cycling record from  database
        public void EditCyclngEx(int mid, int uid, int aid, float m1, float m2, float m3, float curcal)
        {
            DbClass db = new DbClass(); // creating instance of DbClass
            db.Edit(mid, uid, aid, m1, m2, m3, curcal); // Using Update method form DbClass
        }


        //to delete a cycling record from database
        public void DeleteCyclingEx(int mid, int uid, int aid)
        {
            DbClass db = new DbClass(); // creating instance of DbClass
            db.Delete(mid, uid, aid); // Using Update method form DbClass
        } 
    }
}
