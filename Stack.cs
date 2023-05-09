using System;
using System.Collections.Generic;

namespace _8._1_LambdaExpressions_And_Generics
{
    // Generic stack data structure and accompanying methods
    public class MyStack<T>
    {
        private T[] array;
        public int Count { get; private set; }

        public MyStack(int capacity)
        {
            array = new T[capacity];
            Count = 0;
        }

        public void Push(T val)
        {
            if (Count < array.Length) array[Count++] = val;
            else throw new InvalidOperationException("The stack is out of capacity.");
        }

        public T Pop()
        {
            if (Count > 0) return array[--Count];
            else throw new InvalidOperationException("The stack is empty.");
        }

        public T Find(Func<T, bool> criteria)
        {
            try
            {
                if (criteria == null) throw new ArgumentNullException($"Criteria parameter was null!");
                for (int i = Count - 1; i >= 0; i--)
                {
                    if (criteria(array[i])) return array[i];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            return default;
        }

        public T[] FindAll(Func<T, bool> criteria)
        {
            try
            {
                if (criteria == null) throw new ArgumentNullException($"Criteria paramater was null!");

                int trueElements = 0;
                for (int i = Count - 1; i >= 0; i--)
                {
                    if (criteria(array[i])) trueElements++;
                }

                if (trueElements == 0) return null;

                T[] newArray = new T[trueElements];
                int addToNew = trueElements - 1;

                for (int i = Count - 1; i >= 0; i--)
                {
                    if (criteria(array[i]))
                    {
                        newArray[addToNew--] = array[i];
                    }
                }
                return newArray;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            return default;
        }

        public int RemoveAll(Func<T, bool> criteria)
        {
            try
            {
                if (criteria == null) throw new ArgumentNullException($"Criteria parameter was null!");

                int elementsToRemove = 0;
                for (int i = Count - 1; i >= 0; i--)
                {
                    if (criteria(array[i])) elementsToRemove++;
                }

                if (elementsToRemove == 0) return 0;

                int arrayResize = Count - elementsToRemove;
                T[] copiedArray = (T[])array.Clone();
                array = new T[arrayResize];

                int newIndex = arrayResize - 1;
                for (int i = copiedArray.Length - 1; i >= 0; i--)
                {
                    if (!criteria(copiedArray[i]))
                    {
                        array[newIndex--] = copiedArray[i];
                    }
                }
                return elementsToRemove;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            return default;
        }

        public T Max()
        {
            if (Count == 0) return default;
            else
            {
                T currentMax = array[0];
                Comparer<T> comparer = Comparer<T>.Default;
                int result;

                for (int i = 1; i < Count; i++)
                {
                    result = comparer.Compare(array[i], currentMax);
                    if (result > 0) currentMax = array[i];
                }

                return currentMax;
            }
        }

        public T Min()
        {
            if (Count == 0) return default;
            else
            {
                T currentMin = array[0];
                Comparer<T> comparer = Comparer<T>.Default;
                int result;

                for (int i = 1; i < Count; i++)
                {
                    result = comparer.Compare(array[i], currentMin);
                    if (result < 0) currentMin = array[i];
                }

                return currentMin;
            }
        }
    }
}
