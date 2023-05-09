using System;

namespace Bank
{
    class BankTransactions
    {
        static void Main(string[] args)
        {

            Bank bank = new();

            switch (ReadUserOption())
            {
                case 0:
                    Console.WriteLine("\nYou selected WITHDRAW");
                    DoWithdraw(bank);
                    break;

                case (MenuOption)1:
                    Console.WriteLine("\nYou selected DEPOSIT");
                    DoDeposit(bank);
                    break;

                case (MenuOption)2:
                    Console.WriteLine("\nYou selected TRANSFER");
                    DoTransfer(bank);
                    break;

                case (MenuOption)3:
                    Console.WriteLine("\nYou selected PRINT");
                    DoPrint(bank);
                    break;

                case (MenuOption)4:
                    Console.WriteLine("\nYou selected ADD NEW ACCOUNT");
                    NewAccount(bank);
                    break;

                case (MenuOption)5:
                    Console.WriteLine("\nYou selected QUIT");
                    break;

                default:
                    ReadUserOption();
                    break;
            }

            Console.WriteLine("\nProgram complete.");
        }

        enum MenuOption
        {
            Withdraw,
            Deposit,
            Transfer,
            Print,
            AddAccount,
            Quit
        }

        static MenuOption ReadUserOption()
        {
            int selection = -1;

            do
            {
                Console.WriteLine("What option would you like to chose? Please input an integer between 1 and 5.");
                Console.WriteLine("1. Withdraw\n2. Deposit\n3. Transfer\n4. Print\n5. Add New Account\n6. Quit");
                Console.Write("Option: ");
                try
                {
                    selection = (Convert.ToInt32(Console.ReadLine()) - 1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message + "\n");
                }

            } while (selection < 0 || selection > 5);

            return (MenuOption)selection;
        }

        static void DoWithdraw(Bank bank)
        {
            
            try
            {
                Console.WriteLine("\n* * FOR WITHDRAW * *");
                Account account = FindAccount(bank);

                if (account == null)
                {
                    Console.WriteLine("Withdraw terminated.");
                    return;
                }

                Console.Write("Withdraw amount: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                WithdrawTransaction withdraw = new(account, amount);
                bank.ExecuteTransaction(withdraw);
                withdraw.Print();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        static void DoDeposit(Bank bank)
        {
            try
            {
                Console.WriteLine("\n* * FOR DEPOSIT * *");
                Account account = FindAccount(bank);

                if (account == null)
                {
                    Console.WriteLine("Deposit terminated.");
                    return;
                }

                Console.Write("Deposit amount: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                DepositTransaction deposit = new(account, amount);
                bank.ExecuteTransaction(deposit);
                deposit.Print();

            }
            catch(Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        static void DoTransfer(Bank bank)
        {
            try
            {
                Console.WriteLine("\n* * FOR TRANSFER * *");
                Console.WriteLine("Sending account...");
                Account fromAccount = FindAccount(bank);

                if (fromAccount == null)
                {
                    Console.WriteLine("Transfer terminated.");
                    return;
                }

                Console.WriteLine("Receiving account...");
                Account toAccount = FindAccount(bank);

                if (toAccount == null)
                {
                    Console.WriteLine("Transfer terminated.");
                    return;
                }

                Console.Write("Transfer amount: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                TransferTransaction transfer = new(fromAccount, toAccount, amount);
                transfer.Execute();
                transfer.Print();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        static void NewAccount(Bank bank)
        {
            try
            {
                Console.Write("What is the name of this account: ");
                string name = Console.ReadLine();
                Console.Write("What is the starting balance of this account: ");
                decimal balance = Convert.ToDecimal(Console.ReadLine());

                Account newAccount = new(name, balance);
                bank.AddAccount(newAccount);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        static void DoPrint(Bank bank)
        {
            Account acc = FindAccount(bank);
            acc.Print();
        }

        private static Account FindAccount(Bank bank)
        {
            Console.Write("Find account: ");
     
            string accName = Console.ReadLine();
            if (bank.GetAccount(accName) != null)
            {
                return bank.GetAccount(accName);
            }
            else
            {
                Console.WriteLine("No matching account found.");
                return null;
            }
        }
    }
}