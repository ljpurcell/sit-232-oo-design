using System;

namespace MyDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            // MyDate object created with non-default attibutes
            MyDate today = new(2, 2, 2);
            Console.WriteLine(today.ToString());
            Console.WriteLine();


            // Incorrect arguments that should generate exceptions
            Console.WriteLine("A series of incorrect arguments:");
            today.SetDay(33);
            today.SetMonth(13);
            today.SetYear(0);
            today.SetYear(10000);


            // Shows date still the same after incorrect arguments
            Console.WriteLine(today.ToString());
            Console.WriteLine();


            // NextDay method edge case
            Console.WriteLine("NextDay:");
            today.SetDate(31, 12, 2000);
            Console.WriteLine(today.ToString());
            today.NextDay();
            Console.WriteLine(today.ToString());
            Console.WriteLine();


            // NextMonth method edge case
            Console.WriteLine("NextMonth:");
            today.SetDate(31, 10, 2012);
            Console.WriteLine(today.ToString());
            today.NextMonth();
            Console.WriteLine(today.ToString());
            Console.WriteLine();


            // NextYear method edge case
            Console.WriteLine("NextYear:");
            today.SetDate(29, 2, 2012);
            Console.WriteLine(today.ToString());
            today.NextYear();
            Console.WriteLine(today.ToString());
            Console.WriteLine();


            // PreviousDay method edge case
            Console.WriteLine("PreviousDay:");
            today.SetDate(1, 1, 2001);
            Console.WriteLine(today.ToString());
            today.PreviousDay();
            Console.WriteLine(today.ToString());
            Console.WriteLine();


            // PreviousMonth method edge case
            Console.WriteLine("PreviousMonth:");
            today.SetDate(31, 10, 2012);
            Console.WriteLine(today.ToString());
            today.PreviousMonth();
            Console.WriteLine(today.ToString());
            Console.WriteLine();


            // PreviousYear method edge case
            Console.WriteLine("PreviousYear:");
            today.SetDate(29, 2, 2012);
            Console.WriteLine(today.ToString());
            today.PreviousYear();
            Console.WriteLine(today.ToString());
            Console.WriteLine();
        }
    }
}
