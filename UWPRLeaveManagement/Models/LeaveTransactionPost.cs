using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UWPRLeaveManagement.Models
{
    public class LeaveTransactionPost
    {

        public static async Task LeaveDataPostAsync
            
            (
            string EmpId, string EmpFirstName,
            string EmpLastName, string EmpDesignation,
            string EmpReportingTo, string EmpTeam,
            string DepartureDate, string DepartureTime,
            string ArrivalDate, string ArrivalTime,
            string AppliedDate, string AppliedTime,
            string LeavePeriod, string LeaveType,
            string Description, string ApprovedBy,
            string ApprovedDate, string ApprovedTime,
            string LeaveStatus
            )

        {

            var http = new HttpClient();
            string url = String.Format("https://api.mlab.com/api/1/databases/{0}/collections/{1}?apiKey={2}", Common.LeaveTransactionDBName, Common.LeaveTransactionCollectionName, Common.ApiKey);
            var address = new Uri(url);
            Leavetransaction TransactionData = new Leavetransaction();
            TransactionData.EmpId = EmpId;            TransactionData.EmpFirstName = EmpFirstName;            TransactionData.EmpLastName = EmpLastName;            TransactionData.EmpDesignation = EmpDesignation;            TransactionData.EmpReportingTo = EmpReportingTo;            TransactionData.EmpTeam = EmpTeam;            TransactionData.DepartureDate = DepartureDate;            TransactionData.DepartureTime = DepartureTime;            TransactionData.ArrivalDate = ArrivalDate;            TransactionData.ArrivalTime = ArrivalTime;            TransactionData.AppliedDate = AppliedDate;            TransactionData.AppliedTime = AppliedTime;            TransactionData.LeavePeriod = LeavePeriod;            TransactionData.LeaveType = LeaveType;            TransactionData.Description = Description;            TransactionData.ApprovedBy = ApprovedBy;            TransactionData.ApprovedDate = ApprovedDate;            TransactionData.ApprovedTime = ApprovedTime;            TransactionData.LeaveStatus = LeaveStatus;
            var SerializedData = JsonConvert.SerializeObject(TransactionData);
            http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var ResponseBody = await http.PostAsync(address, new StringContent(SerializedData, Encoding.UTF8, "application/json"));
            
        }

    }
}
