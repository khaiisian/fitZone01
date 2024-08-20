using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitZone01
{
    public  class MetCombo
    {
        // to convert yoga type to respective MET
        public  float Yogamet(string a)
        {
            if (a == "Hatha")
            {
                return 2.5f;
            }
            else if (a == "Nadisodhana")
            {
                return 2f;
            }
            else if (a == "Power")
            {
                return 4f;
            }
            else if (a == "Surya Namaskar")
            {
                return 3.3f;
            }
            else { return 0f; }
        }

        // to convert swimming type to respective met
        public float SwimmingToMet(string a)
        {
            if (a == "backstroke (intense)")
            {
                return 9.5f;
            }
            else if (a == "backstroke (moderate)")
            {
                return 4.8f;
            }
            else if (a == "crawl (intense)")
            {
                return 10f;
            }
            else if (a == "crawl (moderate)")
            {
                return 8.3f;
            }
            else if (a == "butterfly (general)")
            {
                return 13.8f;
            }
            else if (a == "breaststroke (intense)")
            {
                return 10.3f;
            }
            else if (a == "breaststroke (moderate)")
            {
                return 5.3f;
            }
            else { return 0f; }
        }
    }
}
