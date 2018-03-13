using System.Linq;
using System.Threading.Tasks;
using Account_Code_Filter_Service.Controllers;

namespace Account_Code_Filter_Service.Models
{
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
        public string AccountNumber { get; }
        public string AccountCode { get; }
        public bool AddNotes { get; }
    

    }
}
