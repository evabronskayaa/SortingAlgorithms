using System;
using System.IO;
using System.Threading;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Table table = new Table(@"C:\Users\igorb\Desktop\Test.csv");
            Console.WriteLine(table.ToString());
            
            //Console.WriteLine("Hello World!");
            //int[] arr = {12, 11, 13, 5, 6, 7};

            //arr.HeapSort();
            
            //Console.WriteLine("Sorted array is");
            //PrintArray(arr);
        }
        
        public static void WriteWithDelay(string arg)
        {
            Console.WriteLine(arg);
            Thread.Sleep(200);
        }
    }
}