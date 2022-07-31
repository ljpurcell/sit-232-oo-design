using System;
using System.Collections.Generic;

namespace ExceptionHandling
{

    class Account
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Balance { get; private set; }

        public Account(string firstName, string lastName, int balance)
        {
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
        }

        public void Withdraw(int amount)
        {
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient fund");
            }
            Balance = Balance - amount;
        }

        // For DivideByZeroException
        public decimal ShareMoney(int numberPeople)
        {
            decimal eachGets = Balance / numberPeople;
            return eachGets;
        }

        public decimal DontShareMoney()
        {
            return ShareMoney(0);
        }
    }

    class ErrorMethod
    {
        // For StackOverflow
        static public int AddOneRecursively(int number)
        {
            return AddOneRecursively(number + 1);
        }

        // For ArgumentOutOfRange 
        static public int OneToFive(int number)
        {
            if (number >= 1 && number <= 5)
            { return number; }

            else
            { throw new ArgumentOutOfRangeException(); }
        }

        // For OutOfMemory
        static public string[] OutOfMemory()
        {
            List<string> maxedOut = new();

            maxedOut.Add("First words... ");

            for (int i = 1; i <= int.MaxValue; i++)
            {
                maxedOut.Add(" and more words...");
            }

            return maxedOut.ToArray();
        }

        static public string YellOrNull(string phrase)
        {
            if (phrase == null)
            { throw new ArgumentNullException(); }

            else
            { return phrase.ToUpper() + "!!!"; }
        }
    }


    internal class Program
    {
        public static void Main()
        {
            Account myAccount = new Account("Sergey", "P", 100);

            //InvalidOperationException
            try
            {
                myAccount.Withdraw(1000);
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine("The following error detected: " + exception.GetType().ToString()+ " with message \"" + exception.Message+"\"");
            }

            // NullReferenceException
            try
            {
                string nullValue = null;
                Console.WriteLine(nullValue.ToString()); 
            }
            catch(NullReferenceException exception)
            {
                Console.WriteLine("The following error detected: " + exception.GetType().ToString() + " with message \"" + exception.Message + "\"");
            }

            // IndexOutOfRangeException
            try
            {
                int[] array = new int[10];

                for(int i = 0; i < array.Length; i++)
                {
                    array[i] = i;
                }

                Console.WriteLine(array[100]);
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine("The following error detected: " + exception.GetType().ToString() + " with message \"" + exception.Message + "\"");
            }

            // DivideByZeroException
            try
            {
                myAccount.DontShareMoney();
            }
            catch(DivideByZeroException exception)
            {
                Console.WriteLine("The following error detected: " + exception.GetType().ToString() + " with message \"" + exception.Message + "\"");
            }

            // ArgumentNullException
            try
            {
                string nullValue = null;
                Console.WriteLine(ErrorMethod.YellOrNull(nullValue));
            }
            catch (Exception exception)
            {
                Console.WriteLine("The following error detected: " + exception.GetType().ToString() + " with message \"" + exception.Message + "\"");
            }

            // ArgumentOutOfRangeException
            try
            {
                ErrorMethod.OneToFive(6);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine("The following error detected: " + exception.GetType().ToString() + " with message \"" + exception.Message + "\"");
            }

            // FormatException
            try
            {
                int age = Convert.ToInt32(myAccount.FirstName);
            }
            catch (FormatException exception)
            {
                Console.WriteLine("The following error detected: " + exception.GetType().ToString() + " with message \"" + exception.Message + "\"");
            }

            // OutOfMemoryException
            try
            {
                string[] errorArray = ErrorMethod.OutOfMemory();
                Console.WriteLine(errorArray);

            }
            catch (OutOfMemoryException exception)
            {
                Console.WriteLine("The following error detected: " + exception.GetType().ToString() + " with message \"" + exception.Message + "\"");
            }

            // StackOverflowException
            try
            {
                ErrorMethod.AddOneRecursively(1);
            }
            catch (StackOverflowException exception)
            {
                Console.WriteLine("The following error detected: " + exception.GetType().ToString() + " with message \"" + exception.Message + "\"");
            }
        }
    }
}
