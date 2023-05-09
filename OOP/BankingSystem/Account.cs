using System;

namespace Bank
{
    public class Account
    {
        private string _name = "default";
        private decimal _balance = 0.0m;

        public string Name { get { return _name; } }
        public decimal Balance { get { return _balance; } private set { _balance = value; } }

        public Account(string name, decimal balance)
        {
            _name = name;
            _balance = balance;
            Console.WriteLine("\n* New Account Created *");
            Print();
        }
                
        public void Print()
        {
           Console.WriteLine($"Name: {_name}. Balance: {_balance:c}\n");
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("Can't deposit that amount!");
            }
            else
            {
                Balance += amount;
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance || amount < 0)
            {
                throw new InvalidOperationException("Insufficient funds!");
            }
            else
            {
                Balance -= amount;
            }
        }
    }
}
