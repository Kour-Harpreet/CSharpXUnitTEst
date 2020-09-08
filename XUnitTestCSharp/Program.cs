using System;
using System.Collections.Generic;

namespace XUnitTestCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            HelloWorld();
        }
        public static void HelloWorld()
        {
            Console.WriteLine("Hello, world!");
        }

        public static int Add(int first, int second)
        {
            if (first < 0 || second < 0)
            {
                throw new Exception("Numbers must be greater than or equal to zero!");
            }
            return first + second;
        }

        public static string Concatentate(string first, string second)
        {
            return first + second;
        }

        public static void AddToList(int one, int two, List<int> theList)
        {
            theList.Add(one);
            theList.Add(two);
        }
    }
}
