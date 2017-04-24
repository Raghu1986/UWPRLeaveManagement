using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UWPRLeaveManagement.Models
{
  
        public class Id
        {
            [JsonProperty(PropertyName = "$oid")]
            public string Oid { get; set; }
        }

        [DataContract]
        public class EmployeeMaster
        {

            [DataMember]
            public string EmpPkey { get; set; }

            [DataMember]
            public string EmpId { get; set; }

            [DataMember]
            public string EmpFirstName { get; set; }

            [DataMember]
            public string EmpLastName { get; set; }

            [DataMember]
            public string EmpDOB { get; set; }

            [DataMember]
            public string EmpDOJ { get; set; }

            [DataMember]
            public string EmpDesignation { get; set; }

            [DataMember]
            public string EmpReportingTo { get; set; }

            [DataMember]
            public string EmpTeam { get; set; }

            [DataMember]
            public string EmpEmailId { get; set; }

            [DataMember]
            public string EmpPath { get; set; }


    }
    
}
