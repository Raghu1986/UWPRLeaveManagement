using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPRLeaveManagement.Models
{
    public class DateTimeToDateIndian
    {
        public static string GetDateFromDateTime(string dateString)
        {
            string result = "";

            DateTime dt = DateTime.ParseExact(dateString, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            result = dt.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);

            return result;
        }
    }
}
