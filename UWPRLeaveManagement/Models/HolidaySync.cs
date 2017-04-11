using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UWPRLeaveManagement.Models
{

    public class HolidaySync
    {
        private async static Task<string> CallHolidayAsync()
        {
            string HolidayDateSortName = "{HDate:1}";
            var http = new HttpClient();
            string url = String.Format("https://api.mlab.com/api/1/databases/{0}/collections/{1}?s={2}&apiKey={3}", Common.HolidayDBName, Common.HolidayCollectionName, HolidayDateSortName, Common.ApiKey);
            HttpResponseMessage response = await http.GetAsync(new Uri(url));
            //var jsonString = await response.Content.ReadAsStringAsync();
            return await response.Content.ReadAsStringAsync();

        }

        public async static Task GetHolidayListAsnc(ObservableCollection<HolidayMaster> HolidayDates)
        {

            var jsonString = await CallHolidayAsync();
            var allHolidayDate = JsonConvert.DeserializeObject<List<HolidayMaster>>(jsonString);
            HolidayDates.Clear();
            allHolidayDate.ForEach(p => HolidayDates.Add(p));

        }
    }
}
