using System;

namespace _8._1_LambdaExpressions_And_Generics
{
    // For ease of method calling in Tester class
    public delegate Account findDelegate(Func<Account, bool> criteria);

    // For testing the above generic stack methods
    class Tester
    {
        static void Main(string[] args)
        {
            Account smallestBalance = new("Littlest", 10m);
            Account secondSmallestBalance = new("LittleMedium", 250m);
            Account middleBalance = new("Medium", 500m);
            Account secondLargestBalance = new("MediumLarge", 1000m);
            Account largestBalance = new("Largest", 5000m);


            // Create new stack object and add accounts to it smallest to largest 

            MyStack<Account> AccountStack = new(5);
            AccountStack.Push(smallestBalance);
            AccountStack.Push(secondSmallestBalance);
            AccountStack.Push(middleBalance);
            AccountStack.Push(secondLargestBalance);
            AccountStack.Push(largestBalance);


            // Test for Find
            Console.WriteLine("* Tests for 'Find' *");

            findDelegate find = AccountStack.Find;

            Func<Account, bool> nullCriteria = null;
            Console.Write("Null criteria: ");
            find(nullCriteria);

            Func<Account, bool> hasMoney = (x) => x.Balance > 0;
            Console.Write("First account with money: ");
            Console.WriteLine(find(hasMoney).Name); 

            Func<Account, bool> lessThanThreeFigures = (x) => x.Balance < 100;
            Console.Write("First account with under $100: ");
            Console.WriteLine(find(lessThanThreeFigures).Name); 

            Func<Account, bool> hasOneGrand = (x) => x.Balance == 1000;
            Console.Write("First account with exactly $1,000: ");
            Console.WriteLine(find(hasOneGrand).Name); 

            Func<Account, bool> atLeastFourFigures = (x) => x.Balance < 1000 && x.Balance > 99;
            Console.Write("First account with less than $1,000 but more than $100: ");
            Console.WriteLine(find(atLeastFourFigures).Name); 


            // Test for FindAll

            Console.WriteLine("\n* Tests for 'FindAll' *");

            Account anotherSmallestBalance = new("AlsoLittlest", 10m);
            Account sameNameAsSmallestBalance = new("Littlest", 10.5m);
            Account oneThousandBalance = new("Grand1", 1000m);
            Account oneThousandBalance2 = new("Grand2", 1000m);

            void reMakeStack() // Reestablishes stack after manipulating it
            {
                AccountStack = new(9);
                AccountStack.Push(smallestBalance);
                AccountStack.Push(secondSmallestBalance);
                AccountStack.Push(middleBalance);
                AccountStack.Push(secondLargestBalance);
                AccountStack.Push(largestBalance);
                AccountStack.Push(anotherSmallestBalance);
                AccountStack.Push(sameNameAsSmallestBalance);
                AccountStack.Push(oneThousandBalance);
                AccountStack.Push(oneThousandBalance2);
            }

            reMakeStack();


            Account[] foundAll = AccountStack.FindAll(hasMoney);

            Console.WriteLine("\n1. Has money:");
            foreach(Account account in foundAll)
            {
                account.Print();
            }

            foundAll = AccountStack.FindAll(hasOneGrand); 

            Console.WriteLine("\n2. Has $1,000:");
            foreach (Account account in foundAll)
            {
                account.Print();
            }

            Func<Account, bool> hasTenDollars = (x) => x.Balance == 10;
            foundAll = AccountStack.FindAll(hasTenDollars);

            Console.WriteLine("\n3. Has $10:");
            foreach (Account account in foundAll)
            {
                account.Print();
            }

            Func<Account, bool> hasNameLittlest = (x) => x.Name == "Littlest";
            foundAll = AccountStack.FindAll(hasNameLittlest);

            Console.WriteLine("\n4. Has name 'Littlest':");
            foreach (Account account in foundAll)
            {
                account.Print();
            }


            Console.WriteLine("\n5. Null:");
            foundAll = AccountStack.FindAll(nullCriteria);


            // Test for RemoveAll

            Console.WriteLine("\n* Tests for 'RemoveAll' *");

            int itemsRemoved = AccountStack.RemoveAll(hasMoney);

            Console.WriteLine("\n1. Has money:");
            Console.WriteLine($"Items removed: {itemsRemoved}");

            reMakeStack();

            itemsRemoved = AccountStack.RemoveAll(hasOneGrand);

            Console.WriteLine("\n2. Has $1,000:");
            Console.WriteLine($"Items removed: {itemsRemoved}");

            reMakeStack();

            Console.WriteLine("\n3. Null:");
            itemsRemoved = AccountStack.RemoveAll(nullCriteria);
            Console.WriteLine($"Items removed: {itemsRemoved}");


            // Test for Min

            Console.WriteLine("\n* Test for 'Min' *");

            Account minimum = AccountStack.Min();
            minimum.Print();

            AccountStack = new(10);
            AccountStack.Push(smallestBalance);
            AccountStack.Push(secondSmallestBalance);
            AccountStack.Push(middleBalance);
            AccountStack.Push(secondLargestBalance);
            AccountStack.Push(largestBalance);
            AccountStack.Push(anotherSmallestBalance);
            AccountStack.Push(sameNameAsSmallestBalance);
            AccountStack.Push(oneThousandBalance);
            AccountStack.Push(oneThousandBalance2);
            AccountStack.Push(new Account("El Cheapo", 0.1m)); // New minimum element

            minimum = AccountStack.Min();
            minimum.Print();


            // Test for Max

            Console.WriteLine("\n* Test for 'Max' *");

            Account maximum = AccountStack.Max();
            maximum.Print();

            AccountStack = new(10);
            AccountStack.Push(smallestBalance);
            AccountStack.Push(secondSmallestBalance);
            AccountStack.Push(middleBalance);
            AccountStack.Push(secondLargestBalance);
            AccountStack.Push(largestBalance);
            AccountStack.Push(anotherSmallestBalance);
            AccountStack.Push(sameNameAsSmallestBalance);
            AccountStack.Push(oneThousandBalance);
            AccountStack.Push(oneThousandBalance2);
            AccountStack.Push(new Account("El Richo", 10000000m)); // New maximum element

            maximum = AccountStack.Max();
            maximum.Print();

        }
    }
}
