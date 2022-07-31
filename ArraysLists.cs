using System;
using System.Collections.Generic;

namespace ArraysLists
{
    class Program
    {
        static void Main(string[] args)
        {

            // Question 1
            Console.WriteLine("QUESTION 1");

            double[] dblArray = new double[10];

            dblArray[0] = 1.0;
            dblArray[1] = 1.1;
            dblArray[2] = 1.2;
            dblArray[3] = 1.3;
            dblArray[4] = 1.4;
            dblArray[5] = 1.5;
            dblArray[6] = 1.6;
            dblArray[7] = 1.7;
            dblArray[8] = 1.8;
            dblArray[9] = 1.9;

            Console.WriteLine($"The element at index 0 is {dblArray[0]}");
            Console.WriteLine($"The element at index 1 is {dblArray[1]}");
            Console.WriteLine($"The element at index 2 is {dblArray[2]}");
            Console.WriteLine($"The element at index 3 is {dblArray[3]}");
            Console.WriteLine($"The element at index 4 is {dblArray[4]}");
            Console.WriteLine($"The element at index 5 is {dblArray[5]}");
            Console.WriteLine($"The element at index 6 is {dblArray[6]}");
            Console.WriteLine($"The element at index 7 is {dblArray[7]}");
            Console.WriteLine($"The element at index 8 is {dblArray[8]}");
            Console.WriteLine($"The element at index 9 is {dblArray[9]}");
            Console.WriteLine();


            // Question 2
            Console.WriteLine("QUESTION 2");

            int[] intArray = new int[10];

            for (int i = 0; i < 10; i++)
            {
                intArray[i] = i;

            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"The element at position {i} in the array is {intArray[i]}");
            }
            Console.WriteLine();


            // Question 3
            Console.WriteLine("QUESTION 3");

            int[] studentArray = { 87, 68, 94, 100, 83, 78, 85, 91, 76, 87 };
            int total = 0;

            for (int i = 0; i < studentArray.Length; i++)
            {
                total += studentArray[i];
            }

            Console.WriteLine($"The total marks for the student array is: {total}");
            Console.WriteLine($"This consists of {studentArray.Length} marks");
            Console.WriteLine($"Therefore the average marks is {(double)total / studentArray.Length}");
            Console.WriteLine();


            // Question 4
            Console.WriteLine("QUESTION 4");

            string[] studentNames = new string[6];

            for (int i = 0; i < studentNames.Length; i++)
            {
                Console.Write($"What is the name of student number {i + 1}: ");
                studentNames[i] = Console.ReadLine();
            }
            Console.WriteLine();


            // Question 5
            Console.WriteLine("QUESTION 5");

            double[] valuesArray = new double[10];

            for (int i = 0; i < valuesArray.Length; i++)
            {
                Console.Write($"What is the value at index {i}: ");
                try
                {
                    valuesArray[i] = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"Value at index {i} will be initialised to 0");
                }
            }
            Console.WriteLine();

            for (int i = 0; i < valuesArray.Length; i++)
            {
                Console.WriteLine($"The element at index {i} in the array is {valuesArray[i]}");
            }
            Console.WriteLine();

            int currentSize = 0; // Unsure why this was specified
            double currentLargest = valuesArray[0];
            double currentSmallest = valuesArray[0];

            for (int i = 0; i < valuesArray.Length; i++)
            {
                if (valuesArray[i] > currentLargest)
                    currentLargest = valuesArray[i];

                if (valuesArray[i] < currentSmallest)
                    currentSmallest = valuesArray[i];

                Console.WriteLine($"{i}: {valuesArray[i]}");
            }
            Console.WriteLine($"Largest: {currentLargest}");
            Console.WriteLine($"Smallest: {currentSmallest}");
            Console.WriteLine();


            // Question 6
            Console.WriteLine("QUESTION 6");

            int[,] myArray = new int[3, 4] { { 1, 2, 3, 4 }, { 1, 1, 1, 1 }, { 2, 2, 2, 2, } };

            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    Console.Write($"{myArray[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            // Question 7
            Console.WriteLine("QUESTION 7");

            List<string> myStudentList = new();
            Random randomValue = new();
            int randomNumber = randomValue.Next(1, 12);

            Console.WriteLine($"Adding {randomNumber} student(s) to class list");
            for (int i = 0; i < randomNumber; i++)
            {
                Console.Write($"Please enter the name of the student #{i + 1}: ");
                myStudentList.Add(Console.ReadLine());
            }
            Console.WriteLine($"List size: {myStudentList.Count}");
            Console.WriteLine();

            // Question 8
            Console.WriteLine("QUESTION 8");

            static bool Palindrome(int[] array)
            {
                int halfOfWord = (int)Math.Ceiling((double)array.Length / 2);
                if (array.Length < 1)
                    return false;
                else
                {
                    for (int i = 0; i < halfOfWord; i++)
                    {
                        if (array[i] != array[array.Length - 1 - i])
                            return false;
                    }
                }
                return true;
            }

            int[] notPal = { 1, 2, 3, 4 };
            int[] evenPal = { 1, 2, 3, 3, 2, 1 };
            int[] palSmallest = { 1 };
            int[] oddPal = { 1, 9, 11, 9, 1 };
            int[] tooSmall = { };

            Console.WriteLine($"False: {Palindrome(notPal)}");
            Console.WriteLine($"True:  {Palindrome(evenPal)}");
            Console.WriteLine($"True:  {Palindrome(palSmallest)}");
            Console.WriteLine($"True:  {Palindrome(oddPal)}");
            Console.WriteLine($"False: {Palindrome(tooSmall)}");
            Console.WriteLine();


            // Question 9
            Console.WriteLine("QUESTION 9");

            var sortedList_a = new List<int> { 1, 3, 3, 3, 5 };
            var sortedList_b = new List<int> { 11, 33, 43, 783, 1005 };
            var emptyList = new List<int> { };
            var unsortedList = new List<int> { 4, 3, 1, 3, 5 };

            static List<int> Merge(List<int> list_a, List<int> list_b)
            {

                static bool InAscOrder(List<int> list)
                {
                    for (int i = 1; i < list.Count; i++)
                    {
                        if (list[i] < list[i - 1])
                            return false;
                    }
                    return true;
                }

                bool isList_a_sorted = InAscOrder(list_a);
                bool isList_b_sorted = InAscOrder(list_b);


                if (!isList_a_sorted || !isList_b_sorted)
                {
                    return null;
                }

                else if (list_a.Count == 0)
                {
                    return list_b;
                }
                else if (list_b.Count == 0)
                {
                    return list_a;
                }
                else
                {
                    List<int> sortedList = new();
                    int current_a = 0;
                    int current_b = 0;

                    int sortedSize = list_a.Count + list_b.Count;

                    while (sortedList.Count < sortedSize)
                    {
                        if (list_a[current_a] < list_b[current_b])
                        {
                            sortedList.Add(list_a[current_a]);
                            current_a++;

                            if (current_a > list_a.Count - 1)
                            {
                                while (current_b < list_b.Count)
                                {
                                    sortedList.Add(list_b[current_b]);
                                    current_b++;
                                }
                            }
                        }
                        else
                        {
                            sortedList.Add(list_b[current_b]);
                            current_b++;

                            if (current_b > list_b.Count - 1)
                            {
                                while (current_a < list_a.Count)
                                {
                                    sortedList.Add(list_a[current_a]);
                                    current_a++;
                                }
                            }
                        }
                    }

                    return sortedList;
                }
            }


            List<int> listTrue = Merge(sortedList_a, sortedList_b);
            foreach (int number in listTrue)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();

            // Should output same as above, only this time parameters reversed
            List<int> listTrue2 = Merge(sortedList_b, sortedList_a);
            foreach (int number in listTrue2)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();


            List<int> listNull = Merge(sortedList_a, unsortedList);
            if (listNull == null)
            {
                Console.WriteLine("This is a null list!");
            }

            List<int> listTrue3 = Merge(emptyList, sortedList_b);
            foreach (int number in listTrue3)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();



            // Question 10
            Console.WriteLine("QUESTION 10");

            static int[] ArrayConversion(int[,] array)
            {
                List<int> convertedList = new();

                for(int i = 0; i < array.GetLength(1); i++)
                {
                    for (int j = 0; j < array.GetLength(0); j++)
                    {
                        if (array[j, i] % 2 != 0)
                        {
                            convertedList.Add(array[j, i]);
                        }
                    }
                }

                int arrSize = convertedList.Count;

                int[] convertedArray = new int[arrSize];

                for(int i = 0; i < arrSize; i++)
                {
                    convertedArray[i] = convertedList[i];
                }

                return convertedArray;                  
            }


            int[,] arrayTest = new int[4, 6]
            {
                { 0, 2, 4, 0, 9, 5 },
                { 7, 1, 3, 3, 2, 1 },
                { 1, 3, 9, 8, 5, 6 },
                { 4, 6, 7, 9, 1, 0 }
            };

            var final = ArrayConversion(arrayTest);

            foreach (int number in final)
            {
                Console.Write($"{number} ");
            }

        }

    }

}
