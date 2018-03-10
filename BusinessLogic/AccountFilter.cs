using Account_Code_Filter_Service.Models;

namespace Account_Code_Filter_Service.BusinessLogic
{
    public class AccountFilter : IAccountFilter
    {
        public AccountFilter()
        {
            
        }
        public bool Filter(string accountNumber, string filter, IAccountRepository repo)
        {
            Account account = repo.Find(accountNumber);
            if (account != null && account.AccountCode.Equals(filter))
                return true;
            return false;
        }
    }
}
