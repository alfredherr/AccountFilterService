using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account_Code_Filter_Service.Models
{
    public interface IAccountRepository
    {
        void Add(Account item);
        IEnumerable<Account> GetAll();
        Account Find(string key);
        Account Remove(string key);
        void Update(Account item);
    }
}

