using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace UWPRLeaveManagement.Models
{
    public  class EmployeeSync
    {
        private async static Task<string> CallEmployeeAsync(string EmpId)
        {
            string EmpSortName = "{EmpFirstName:1}";
            string EmpIdvar =  String.Format("{{\"EmpId\":\"{0}\"}}", EmpId, "4");
            var http = new HttpClient();
            string url;
            if (EmpId=="All")
            {
                url = String.Format("https://api.mlab.com/api/1/databases/{0}/collections/{1}?s={2}&apiKey={3}", Common.DBName, Common.CollectionName, EmpSortName, Common.ApiKey);
            }
            else
            {
                url = String.Format("https://api.mlab.com/api/1/databases/{0}/collections/{1}?q={2}&apiKey={3}", Common.DBName, Common.CollectionName, EmpIdvar, Common.ApiKey);
            }
             

            HttpResponseMessage response = await http.GetAsync(new Uri(url));
            //var jsonString = await response.Content.ReadAsStringAsync();
            return await response.Content.ReadAsStringAsync();

        }

        public async static Task GetAllEmployeesAsnc(ObservableCollection<EmployeeMaster> EmployeeCharacters, string EmpId)
        {

            var jsonString = await CallEmployeeAsync(EmpId);
            var allEmployess = JsonConvert.DeserializeObject<List<EmployeeMaster>>(jsonString);
            EmployeeCharacters.Clear();
           // allEmployess.ForEach(p => EmployeeCharacters.Add(p));

            foreach (var Employees in allEmployess)
            {
                // Filter characters that are missing thumbnail images

                if (Employees.EmpPath != null
                    && Employees.EmpPath != "")
                //    && character.thumbnail.path != ImageNotAvailablePath)
                {

                    Employees.EmpPath = String.Format("{0}/{1}.png",
                        Common.EmpPhotoPath,
                        Employees.EmpId);



                    EmployeeCharacters.Add(Employees);
                }
            }

        }
        

    }
}
