using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account_Code_Filter_Service.BusinessLogic;
using Account_Code_Filter_Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;

namespace Account_Code_Filter_Service.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly ILogger _logger;
        private AccountRepository _db;
        private AccountFilter _filter = new AccountFilter();

        public AccountController(IAccountRepository repo, ILogger<FilterController> logger)
        {
            _db = (AccountRepository) repo;
            _logger = logger;
        }
        
        [HttpGet]
        [Route("xml")]
        [Produces("application/xml")]
        public AccountsResponse GetXml()
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

        [HttpGet("{accountNumber}.{format}"), FormatFilter]
        public Account GetXml(string accountNumber)
        {
            return _db.Find(accountNumber);
        }
       
        [Route("getbynumberxml")]
        [Produces("application/xml")]
        public Account GetWithParamsXml([FromQuery(Name = "account")] string number)
        { 
            if (string.IsNullOrEmpty(number) || _d qqqb.Find(number) == null)
            {
                return new Account($"{number} not found", "", false);
            }
            return _db.Find(number);
            
        }

        
        [HttpGet]
        [Route("getbynumber")]
        public Account GetWithParams([FromQuery(Name = "account")] string number)
        {
           
            if (string.IsNullOrEmpty(number) || _db.Find(number) == null)
            {
                return new Account($"{number} not found", "", false);
            }
            return _db.Find(number);
            
        }
    }
}