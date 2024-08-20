using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitZone01
{
    public class met_to_type
    {
        // to convert MET of yoga to respective yoga type
        public string yoga_metTotype(float a)
        {
            if (a == 2.5f)
            {
                return "Hatha";
            }
            else if (a == 2f)
            {
                return "Nadisodhana";
            }
            else if (a == 3.3f)
            {
                return "Surya Namaskar";
            }
            else if (a == 4f)
            {
                return "Power";
            }
            else return "";
        }


        // to convert MET of swimming to respective swimming type
        public string met_to_swimming(float a)
        {
            if (a == 9.5f)
            {
                return "backstroke (intense)";
            }
            else if (a == 4.8f)
            {
                return "backstroke (moderate)";
            }
            else if (a == 10f)
            {
                return "crawl (intense)";
            }
            else if (a == 8.3f)
            {
                return "crawl (moderate)";
            }
            else if (a == 13.8f)
            {
                return "butterfly (general)";
            }
            else if (a == 10.3f)
            {
                return "breaststroke (intense)";
            }
            else if (a == 5.3f)
            {
                return "breaststroke (moderate)";
            }

            else return "";
        }
    }
}
