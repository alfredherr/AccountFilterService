using System;
using System.Threading.Tasks;

namespace Account_Code_Filter_Service.Models
{
    public class FilterRequest
    {
        public string AccountNumber { get; set; }
        public string AccountCodeToFilterOn { get; set; }

    }
}
