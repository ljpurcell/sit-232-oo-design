using System;
using System.Collections.Generic;

namespace Bank
{
    public class Bank
    {
        private List<Account> _accounts = new();

        public Bank() 
        {
            if (_accounts.Count == 0)
            {
                Console.WriteLine("$ $ BANK SYSTEM CREATED $ $");
                AddAccount(new Account("Lyndon", 100.0m));
                AddAccount(new Account("Ash", 1.0m));
                AddAccount(new Account("Gary", 100000.0m));
                AddAccount(new Account("Brock", 1500.0m));
                AddAccount(new Account("Misty", 99999999.0m));
            }
        }

        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }

        public Account GetAccount(string name)
        {
            return _accounts.Find(acc => acc.Name == name);
        }

        public void ExecuteTransaction(DepositTransaction toExecute)
        {
            toExecute.Execute();
        }

        public void ExecuteTransaction(WithdrawTransaction toExecute)
        {
            toExecute.Execute();
        }

        public void ExecuteTransaction(TransferTransaction toExecute)
        {
            toExecute.Execute();
        }
    }
}
