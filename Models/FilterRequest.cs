using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Account_Code_Filter_Service.Models
{
    [DataContract]
    public class FilterRequest
    {
        [DataMember]
        public string AccountNumber { get; set; }
        [DataMember]
        public string AccountCodeToFilterOn { get; set; }

    }
}
