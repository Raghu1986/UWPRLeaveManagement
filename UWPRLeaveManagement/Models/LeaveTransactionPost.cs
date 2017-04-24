﻿using Newtonsoft.Json;
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

        public static async Task<string> LeaveDataPostAsync

            (
            string TransPkey, string EmpId,
            string EmpFirstName, string EmpLastName,
            string EmpDesignation, string EmpReportingTo,
            string EmpTeam, string DepartureDate,
            string DepartureTime, string ArrivalDate,
            string ArrivalTime, string AppliedDate,
            string AppliedTime, string LeavePeriod,
            string LeaveType, string Description,
            string ApprovedBy, string ApprovedDate,
            string ApprovedTime, string LeaveStatus
            )

        {
                        

            var http = new HttpClient();
            string url = String.Format("https://api.mlab.com/api/1/databases/{0}/collections/{1}?apiKey={2}", Common.LeaveTransactionDBName, Common.LeaveTransactionCollectionName, Common.ApiKey);
            var address = new Uri(url);
            Leavetransaction TransactionData = new Leavetransaction();
            TransactionData.TransPkey = TransPkey;
            TransactionData.EmpId = EmpId;            TransactionData.EmpFirstName = EmpFirstName;            TransactionData.EmpLastName = EmpLastName;            TransactionData.EmpDesignation = EmpDesignation;            TransactionData.EmpReportingTo = EmpReportingTo;            TransactionData.EmpTeam = EmpTeam;            TransactionData.DepartureDate = DepartureDate;            TransactionData.DepartureTime = DepartureTime;            TransactionData.ArrivalDate = ArrivalDate;            TransactionData.ArrivalTime = ArrivalTime;            TransactionData.AppliedDate = AppliedDate;            TransactionData.AppliedTime = AppliedTime;            TransactionData.LeavePeriod = LeavePeriod;            TransactionData.LeaveType = LeaveType;            TransactionData.Description = Description;            TransactionData.ApprovedBy = ApprovedBy;            TransactionData.ApprovedDate = ApprovedDate;            TransactionData.ApprovedTime = ApprovedTime;            TransactionData.LeaveStatus = LeaveStatus;
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
