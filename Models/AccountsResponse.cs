using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Account_Code_Filter_Service.Models
{
    [DataContract]
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
        [DataMember]
        public Account[] Accounts { get; set; }
    }
}