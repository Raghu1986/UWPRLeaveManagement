using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UWPRLeaveManagement.Models
{
    public class HId
    {
        [JsonProperty(PropertyName = "$oid")]
        public string Oid { get; set; }
    }

    [DataContract]
    public class HolidayMaster
    {
        [DataMember]
        public HId _id { get; set; }

        [DataMember]
        public string HDate { get; set; }

        [DataMember]
        public string Description { get; set; }

    }

}
