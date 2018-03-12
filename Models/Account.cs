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
        public Account(string accountNumber, string accountCode)
        {
            AccountNumber = accountNumber;
            AccountCode = accountCode;
        }
        public string AccountNumber { get; }
        public string AccountCode { get; }

    }
}
