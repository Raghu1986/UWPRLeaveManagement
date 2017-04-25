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
    public class LeaveTransactionGetPostPut
    {
        private async static Task<string> CallLeaveTransactionsAsync(string EmpId)
        {
            string LeaveTransactionSortName = "{EmpFirstName:1}";
            string EmpIdvar = String.Format("{{\"EmpId\":\"{0}\",\"LeaveStatus\":\"{1}\"}}", EmpId, "4");
            var http = new HttpClient();
            string url;
            if (EmpId == "All")
            {
                url = String.Format("https://api.mlab.com/api/1/databases/{0}/collections/{1}?s={2}&apiKey={3}", Common.LeaveTransactionDBName, Common.LeaveTransactionCollectionName, LeaveTransactionSortName, Common.ApiKey);
            }
            else
            {
                url = String.Format("https://api.mlab.com/api/1/databases/{0}/collections/{1}?q={2}&apiKey={3}", Common.LeaveTransactionDBName, Common.LeaveTransactionCollectionName, EmpIdvar, Common.ApiKey);
            }
            HttpResponseMessage response = await http.GetAsync(new Uri(url));
            return await response.Content.ReadAsStringAsync();

        }

        public async static Task GetLeaveTransactionAsnc(ObservableCollection<Leavetransaction> Leavetransactions, string EmpId)
        {

            var jsonString = await CallLeaveTransactionsAsync(EmpId);
            var allLeavetransactions = JsonConvert.DeserializeObject<List<Leavetransaction>>(jsonString);
            Leavetransactions.Clear();
            //allLeavetransactions.ForEach(p => Leavetransactions.Add(p));

            foreach (var transactions in allLeavetransactions)
            {
                // Filter characters that are missing thumbnail images

                if (transactions.EmpPath != null
                    && transactions.EmpPath != "")
                //    && character.thumbnail.path != ImageNotAvailablePath)
                {

                    transactions.EmpPath = String.Format("{0}/{1}.png",
                        Common.EmpPhotoPath,
                        transactions.EmpId);

                    transactions.LeavePeriod =Days.GetNumbertoDays(transactions.LeavePeriod);



                    Leavetransactions.Add(transactions);
                }
            }

        }


        public static async Task<string> LeaveDataPostAsync

            (
            string TransPkey, string EmpId,
            string EmpFirstName, string EmpLastName,
            string EmpDesignation, string EmpReportingTo,
            string EmpTeam, string EmpPath,
            string DepartureDate, string DepartureTime, 
            string ArrivalDate, string ArrivalTime,
            string AppliedDate,string AppliedTime,
            string LeavePeriod,string LeaveType,
            string Description,string ApprovedBy,
            string ApprovedDate, string ApprovedTime,
            string LeaveStatus
            )

        {


            var http = new HttpClient();
            string url = String.Format("https://api.mlab.com/api/1/databases/{0}/collections/{1}?apiKey={2}", Common.LeaveTransactionDBName, Common.LeaveTransactionCollectionName, Common.ApiKey);
            var address = new Uri(url);
            Leavetransaction TransactionData = new Leavetransaction();
            TransactionData.TransPkey = TransPkey;
            TransactionData.EmpId = EmpId;
            TransactionData.EmpFirstName = EmpFirstName;
            TransactionData.EmpLastName = EmpLastName;
            TransactionData.EmpDesignation = EmpDesignation;
            TransactionData.EmpReportingTo = EmpReportingTo;
            TransactionData.EmpTeam = EmpTeam;
            TransactionData.EmpPath = EmpPath;
            TransactionData.DepartureDate = DepartureDate;
            TransactionData.DepartureTime = DepartureTime;
            TransactionData.ArrivalDate = ArrivalDate;
            TransactionData.ArrivalTime = ArrivalTime;
            TransactionData.AppliedDate = AppliedDate;
            TransactionData.AppliedTime = AppliedTime;
            TransactionData.LeavePeriod = LeavePeriod;
            TransactionData.LeaveType = LeaveType;
            TransactionData.Description = Description;
            TransactionData.ApprovedBy = ApprovedBy;
            TransactionData.ApprovedDate = ApprovedDate;
            TransactionData.ApprovedTime = ApprovedTime;
            TransactionData.LeaveStatus = LeaveStatus;
            var SerializedData = JsonConvert.SerializeObject(TransactionData);
            http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var ResponseBody = await http.PostAsync(address, new StringContent(SerializedData, Encoding.UTF8, "application/json"));

            if (ResponseBody.StatusCode.ToString() == "OK")
            {
                return "Leave Applied";
            }
            else
            {
                return "Leave not applied";
            }



        }

        public static async Task<string> LeaveTransactionPutAsync(string condition, string setvalue)
        {
            var http = new HttpClient();



            string url = String.Format("https://api.mlab.com/api/1/databases/{0}/collections/{1}/{2}?apiKey={3}", Common.LeaveTransactionDBName, Common.LeaveTransactionCollectionName, condition, Common.ApiKey);

            http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var ResponseBody = await http.PutAsync(url.ToString(), new StringContent(setvalue.ToString(), Encoding.UTF8, "application/json"));
            return ResponseBody.StatusCode.ToString();
        }

    }



}
