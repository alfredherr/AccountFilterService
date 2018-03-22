using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Account_Code_Filter_Service.Controllers;

namespace Account_Code_Filter_Service.Models
{
    [DataContract]
    public class Account
    {
        public Account()
        {
            
        }
        public Account(string accountNumber, string accountCode, bool addNotes)
        {
            AccountNumber = accountNumber;
            AccountCode = accountCode;
            AddNotes = addNotes;
        }
        [DataMember]
        public string AccountNumber { get; set; }
        [DataMember]
        public string AccountCode { get; set; }
        [DataMember]
        public bool AddNotes { get; set; }
    

    }
}
