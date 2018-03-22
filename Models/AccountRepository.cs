using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Microsoft.Extensions.Logging;

namespace Account_Code_Filter_Service.Models
{
    [DataContract]
    public class AccountRepository : IAccountRepository
    {
        public ILogger _logger;
        private const string AccountsFile = "Accounts.txt";

        public AccountRepository(ILogger<AccountRepository> logger)
        {
            _logger = logger;
            LoadAccountsDataStore();

        }

        [DataMember]
        static ConcurrentDictionary<string, Account> _accounts = new ConcurrentDictionary<string, Account>();

        private void LoadAccountsDataStore()
        {
            if (_accounts.Count == 0)
            {
                LoadFile();
            }

        }
        public ConcurrentDictionary<string, Account> ReloadAccountsDataStore()
        {
            return LoadFile();
        }
        private ConcurrentDictionary<string, Account> LoadFile()
        {

            var accounts = new ConcurrentDictionary<string, Account>();
            try
            {
                var file = File.ReadAllLines(AccountsFile);
                foreach (var line in file)
                {
                    var fields = line.Split("\t");

                    if (fields.Length < 3)
                        throw new Exception($"File {AccountsFile} doesn't have the right layout. It has {fields.Length} fields, but need 3. ");

                    bool note = fields.Length > 2 && fields[2] == "true";
                    accounts[fields[0]] = new Account(fields[0], fields[1],note);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            _accounts = accounts;
            return accounts;
        }


        public IEnumerable<Account> GetAll()
        {
            return _accounts.Values;
        }

        public void Add(Account account)
        {
            _accounts[account.AccountNumber] = account;
        }

        public Account Find(string key)
        {
            Account account;
            _accounts.TryGetValue(key, out account);
            return account;
        }

        public Account Remove(string key)
        {
            Account account;
            _accounts.TryGetValue(key, out account);
            _accounts.TryRemove(key, out account);
            return account;
        }

        public void Update(Account account)
        {
            _accounts[account.AccountNumber] = account;
        }
    }
}