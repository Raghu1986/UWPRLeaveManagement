using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPRLeaveManagement.Models
{
    public class Days
    {
        public static string GetNumbertoDays(string value)
        {
            string result = "";


            //var values = value(CultureInfo.InvariantCulture).Split('.');


            string[] values = value.Split('.');
            int firstValue = int.Parse(values[0]);

            int secondValue = 0;
            if (values.Length == 1)
            {
                secondValue = 0;
            }
            else
            {
                secondValue = int.Parse(values[1]);
            }

            if (firstValue == 0 && secondValue == 5 && secondValue == 05)
            {
                result = "½";
            }

            else if (firstValue == 1 && secondValue == 0 && secondValue == 0)

            {
                result = firstValue.ToString();
            }

            else if (firstValue == 1 && secondValue == 5 && secondValue == 05)

            {
                result = firstValue + " " + " ½";
            }


            else if (firstValue > 1 && secondValue == 5 && secondValue == 05)

            {
                result = firstValue + " " + "½";
            }
            else
            {
                result = firstValue.ToString();
            }

            return result;
        }
    }

        
    }
