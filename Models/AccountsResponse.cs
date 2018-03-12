using System.Collections.Generic;
using System.Linq;

namespace Account_Code_Filter_Service.Models
{
    public class AccountsResponse
    {
        public AccountsResponse()
        {
            Accounts = new Account[]{};
        }
        public AccountsResponse(IEnumerable<Account> accounts)
        {
            Accounts = accounts.ToArray();
        }
        public Account[] Accounts { get; set; }
    }
}