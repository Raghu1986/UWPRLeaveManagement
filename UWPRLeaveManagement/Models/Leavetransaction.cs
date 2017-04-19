using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UWPRLeaveManagement.Models
{
    public class LId
    {
        [JsonProperty(PropertyName = "$oid")]
        public string Oid { get; set; }
    }

    [DataContract]
    public class Leavetransaction
    {
        [DataMember]
        public string EmpId { get; set; }

        [DataMember]
        public string EmpFirstName { get; set; }

        [DataMember]
        public string EmpLastName { get; set; }

        [DataMember]
        public string EmpDesignation { get; set; }

        [DataMember]
        public string EmpReportingTo { get; set; }

        [DataMember]
        public string EmpTeam { get; set; }

        [DataMember]
        public string DepartureDate { get; set; }

        [DataMember]
        public string DepartureTime { get; set; }

        [DataMember]
        public string ArrivalDate { get; set; }

        [DataMember]
        public string ArrivalTime { get; set; }

        [DataMember]
        public string AppliedDate { get; set; }

        [DataMember]
        public string AppliedTime { get; set; }

        [DataMember]
        public string LeavePeriod { get; set; }

        [DataMember]
        public string LeaveType { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string ApprovedBy { get; set; }

        [DataMember]
        public string ApprovedDate { get; set; }

        [DataMember]
        public string ApprovedTime { get; set; }

        [DataMember]
        public string LeaveStatus { get; set; }


    }
}
