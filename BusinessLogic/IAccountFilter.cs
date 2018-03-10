using Account_Code_Filter_Service.Models;

namespace Account_Code_Filter_Service.BusinessLogic
{
    public interface IAccountFilter
    {
       bool Filter(string accountNumber, string filter, IAccountRepository repo);
        
    }
}