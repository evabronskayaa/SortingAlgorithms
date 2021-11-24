using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Table table = new Table(@"C:\Users\igorb\Desktop\Test.csv");
            Console.WriteLine(table.ToString());

            var col = ChooseOption(
                "Выберите столбец для сортировки",
                new Dictionary<string, Table.Column>(table.Columns.Select(c => new KeyValuePair<string, Table.Column>(c.Name, c)))
                );

            var type = ChooseOption(
                "Выберите тип данного столбца",
                new Dictionary<string, TableSorting.ColumnType>()
                {
                    { "Текст", TableSorting.ColumnType.Text },
                    { "Дата и время", TableSorting.ColumnType.DateTime },
                    { "Числа", TableSorting.ColumnType.Number }
                }
                );

            var order = ChooseOption(
                "Выберите тип сортировки",
                new Dictionary<string, TableSorting.Order>()
                {
                    { "По возрастанию", TableSorting.Order.Ascending },
                    { "По убыванию", TableSorting.Order.Descending }
                }
                );

            TableSorting.Sort(table, col, type, order);

            Console.WriteLine();
            Console.WriteLine(table.ToString());
            
            
            // Console.WriteLine("Hello World!");
            // int[] arr = {12, 11, 13, 5, 6, 7};
            //
            // arr.ShellSort(ascending: false);
            //
            // Console.WriteLine("Sorted array is");
            // PrintArray(arr);
        }
        private static void PrintArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
        }
        
        public static void WriteWithDelay(string arg)
        {
            Console.WriteLine(arg);
            Thread.Sleep(0);
        }

        public static T ChooseOption<T>(string comment, Dictionary<string, T> options)
        {
            Console.CursorVisible = false;
            ConsoleKey CK = ConsoleKey.A;
            int nowIndex = 0;
            while (CK != ConsoleKey.Enter)
            {
                nowIndex = CK switch
                {
                    ConsoleKey.A =>          nowIndex > 0 ? nowIndex - 1 : nowIndex,
                    ConsoleKey.D =>          nowIndex < options.Count - 1 ? nowIndex + 1 : nowIndex,
                    ConsoleKey.LeftArrow =>  nowIndex > 0 ? nowIndex - 1 : nowIndex,
                    ConsoleKey.RightArrow => nowIndex < options.Count - 1 ? nowIndex + 1 : nowIndex,
                    _ => nowIndex
                };
                Console.SetCursorPosition(0, Console.CursorTop - 1);

                Console.Write($"{comment} => ");

                Console.ForegroundColor = nowIndex > 0 ? ConsoleColor.Yellow : ConsoleColor.DarkGray;
                Console.Write("<<" );
                Console.ResetColor();

                Console.Write($" {options.ElementAt(nowIndex).Key} ");

                Console.ForegroundColor = nowIndex < options.Count - 1 ? ConsoleColor.Yellow : ConsoleColor.DarkGray;
                Console.Write(">>");
                Console.ResetColor();

                Console.WriteLine(new string(' ', 10));
                CK = Console.ReadKey(true).Key;
            }
            Console.WriteLine();
            return options.ElementAt(nowIndex).Value;
        }
    }
}