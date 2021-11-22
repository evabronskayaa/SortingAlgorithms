using System;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] arr = {12, 11, 13, 5, 6, 7};

            arr.ShellSort();
            //HeapSort.Sort(arr);

            Console.WriteLine("Sorted array is");
            PrintArray(arr);
        }
        
        private static void PrintArray(int[] arr)
        {
            int n = arr.Length;
            for (int i=0; i<n; ++i)
                Console.Write(arr[i]+" ");
        }

    }
}