using System;
namespace Bank
{
    public class WithdrawTransaction
    {
        private Account _account;
        private decimal _amount;
        private bool _executed;
        private bool _success;
        private bool _reversed;

        public bool Executed { get { return _executed; } }
        public bool Success  { get { return _success; } } 
        public bool Reversed { get { return _executed; } } 

        public WithdrawTransaction(Account account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }

        public void Print()
        {
            Console.WriteLine($"\n* Withdrawal {(_success?"successful":"unsuccesful")} *\nAcc: {_account.Name}\nAmount: {_amount:c}");
        }

        public void Execute() 
        {
            if (_executed)
            {
                throw new InvalidOperationException("This operation has already been attempted!");
            }
            else
            {
                _executed = true;
                _account.Withdraw(_amount);
                _success = true;
            }
        }

        public void Rollback()
        {
            if (!_success) 
            {
                throw new InvalidOperationException("Withdrawal hasn't been finalised yet!");
            }
            else if (_reversed)
            {
                throw new InvalidOperationException("Withdrawal has already been reversed!");
            }
            else
            {
                _account.Deposit(_amount);
                _reversed = true;
            }
        }  
    }
}
