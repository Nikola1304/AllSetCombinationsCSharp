using System;

namespace AllSetCombinationsCSharp
{
    internal class Program
    {
        static void printIndex(MyPair[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i].getIndex() + " ");
            }
            Console.WriteLine();
        }
        static void printValue(MyPair[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i].getValue() + " ");
            }
            Console.WriteLine();
        }

        static MyPair[] reorderPairArray(MyPair[] arr)
        {
            int n = arr.Length;
            MyPair[] newArr = new MyPair[n];
            for (int i = 0; i < n; i++)
            {
                newArr[i] = new MyPair(arr[n - i - 1]);
            }

            return newArr;
        }

        static bool arePairsEqual(MyPair[] arr1, MyPair[] arr2)
        {
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i].getIndex() != arr2[i].getIndex())
                {
                    return false;
                }
            }
            return true;
        }

        static void allCombinations(int n)
        {
            Console.WriteLine("Insert names of all elements: ");
            if (n == 1)
            {
                string ns123 = Console.ReadLine();
                Console.WriteLine("List of all combinations: ");
                Console.WriteLine(ns123);
            }
            else
            {
                MyPair[] combination = new MyPair[n];
                for (int i = 1; i <= n; i++)
                {
                    string temp = Console.ReadLine();
                    combination[i - 1] = new MyPair(i, temp);
                }
                Console.WriteLine("List of all combinations: ");
                printValue(combination);

                MyPair[] firstBackwards = reorderPairArray(combination);

                while (!arePairsEqual(combination, firstBackwards))
                {
                    for (int i = n - 2; i >= 0; i--)
                    {
                        if (combination[i].getIndex() < combination[i + 1].getIndex())
                        {
                            // ovde sam ih postavio na nesto sto nema sanse da budu
                            int smallestElBefore = n + 1;
                            int indexSmallestElBefore = i;

                            bool smallerExists = false;
                            
                            for (int j = i + 1; j < n; j++)
                            {
                                if (combination[j].getIndex() > combination[i].getIndex())
                                {
                                    if (smallestElBefore > combination[j].getIndex())
                                    {
                                        smallestElBefore = combination[j].getIndex();
                                        indexSmallestElBefore = j;
                                        smallerExists = true;
                                    }
                                }
                            }

                            if (smallerExists == true)
                            {
                                MyPair temp = new MyPair(combination[i]);
                                combination[i] = combination[indexSmallestElBefore];
                                combination[indexSmallestElBefore] = temp;
                            }
                            
                            // niz svih elemenata nakon onog na kom smo stali
                            // trebace nam da ga okrenemo

                            int arrAfterLength = n - i - 1;

                            MyPair[] arrBehind = new MyPair[arrAfterLength];

                            for (int j = 0; j < arrAfterLength; j++)
                            {
                                arrBehind[j] = new MyPair(combination[j + i + 1]);
                            }
                            
                            // okrecemo ceo niz

                            MyPair[] arrBehindReordered = reorderPairArray(arrBehind);

                            for (int j = 0; j < arrAfterLength; j++)
                            {
                                combination[j + i + 1] = arrBehindReordered[j];
                            }
                            printValue(combination);
                            break;
                        }
                    }
                }
            }
        }
        
        
        
        static void Main(string[] args)
        {
            Console.WriteLine("Provide the number of elements your set has: ");
            int n = 0;
            try
            {
                n = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                n = 4;
            }

            if (n == 0) return;
            if (n < 0) n = n * -1;

            allCombinations(n);
            
            Console.WriteLine("Hello World!");
        }
    }
}