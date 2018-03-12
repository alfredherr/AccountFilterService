using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account_Code_Filter_Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Account_Code_Filter_Service.BusinessLogic;


namespace Account_Code_Filter_Service.Controllers
{
    [Route("api/[controller]")]
    public class FilterController : Controller
    {
        private readonly ILogger _logger;
        private AccountRepository _db;
        private AccountFilter  _filter = new AccountFilter();

        public FilterController(IAccountRepository repo, ILogger<FilterController> logger)
        {
            _db = (AccountRepository) repo;
            _logger = logger;
        }


        [HttpGet]
        public AccountsResponse Get()
        {
            AccountsResponse accounts;
            try
            {
                accounts = new AccountsResponse(_db.GetAll());
            }
            catch (Exception e)
            {
                _logger.LogError(e.StackTrace);
                throw;
            }
            return accounts;
        }


        [HttpGet("{accountNumber}")]
        public Account Get(string accountNumber)
        {
            return _db.Find(accountNumber);
        }


        [HttpPost("{accountNumber}/{filter}")]
        public bool Post(string accountNumber, string filter)
        {
            var result = false;
            try
            {
                result = _filter.Filter(accountNumber, filter, _db);
            }
            catch (Exception e)
            {
                _logger.LogError(e.StackTrace);
            }
            return result;
        }
 
    }
}
