using System;
namespace Bank
{
    public class TransferTransaction
    {
        private Account _fromAccount;
        private Account _toAccount;
        private decimal _amount;
        private DepositTransaction _deposit;
        private WithdrawTransaction _withdraw;
        private bool _executed;
        private bool _reversed;

        public bool Executed { get { return _executed; } }
        public bool Success  { get { return _withdraw.Success && _deposit.Success; } } 
        public bool Reversed { get { return _reversed; } }

        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _amount = amount;

            _withdraw = new WithdrawTransaction(fromAccount, amount);
            _deposit = new DepositTransaction(toAccount, amount);
        }

        public void Print()
        {
            Console.WriteLine($"\n* * Transfer * *" +
                $"\nFrom: {_fromAccount.Name}\nTo: {_toAccount.Name}\nAmount: {_amount:c}");
            _withdraw.Print();
            _deposit.Print();
        }

        public void Execute()
        {
            if (_executed)
            {
                throw new InvalidOperationException("This operation has already been attempted!");
            }
            else if (_amount < 0)
            {
                throw new InvalidOperationException("Can't transfer a negative amount!");
            }
            else if (_amount > _fromAccount.Balance)
            {
                throw new InvalidOperationException($"Insufficient funds in sending account: {_fromAccount.Name}");
            }
            else
            {
                _executed = true;
                _withdraw.Execute();

                if (!_withdraw.Success) 
                {
                    throw new InvalidOperationException("Withdraw for Transfer failed!");
                }
                else
                {
                    _deposit.Execute();
                }

                if (!_deposit.Success)
                {
                    throw new InvalidOperationException("Deposit for Transfer failed!");
                }
            }
        }

        public void Rollback()
        {
            if (!Success)
            {
                throw new InvalidOperationException("Transfer hasn't been finalised yet!");
            }
            else if (_reversed)
            {
                throw new InvalidOperationException("Transfer has already been reversed!");
            }
            else if (_amount > _toAccount.Balance)
            {
                throw new InvalidOperationException("Insufficent funds to cover return!");
            }
            else
            {
                _deposit.Rollback();
                _withdraw.Rollback();
                _reversed = true;
            }
        }
    }
}
