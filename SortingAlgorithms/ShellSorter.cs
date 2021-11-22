using System;

namespace SortingAlgorithms
{
    public static class ShellSorter
    {
        private static void Swap(ref int a, ref int b)
        {
            var t = a;
            a = b;
            b = t;
        }

        public static int[] ShellSort(this int[] array)
        {
            var d = array.Length / 2;
            Program.WriteLine($"Расстояние между элементами, которые сравниваются {d}");
            while (d >= 1)
            {
                Program.WriteLine($"Пока расстояние {d} больше единицы делаем сравнение");
                for (var i = d; i < array.Length; i++)
                {
                    Program.WriteLine($"Сохраняем [{i}] в temp ");
                    var j = i;
                    Program.WriteLine($"Cдвинуть ранее отсортированные по элементы вверх, пока не будет найдено правильное местоположение для [{i}]");
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        Program.WriteLine($"Помещается temp (исходный array[{j}]) в правильное место");
                        j -= d;
                    }
                }
                Program.WriteLine($"{d} уменьшается в 2 раза");
                d /= 2;
            }

            return array;
        }
        
        
        private static void Swap<T>(ref T a, ref T b)
        {
            var t = a;
            a = b;
            b = t;
        }
        
        public static T[] ShellSort<T>(this T[] array)
            where T: IComparable
        {
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d].CompareTo(array[j]))>0)
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j -= d;
                    }
                }

                d /= 2;
            }

            return array;
        }

        public static int CompareStrings(string a,string b)
        {
            a = a.ToLower();
            b = b.ToLower();
            int length = a.Length > b.Length ? b.Length : a.Length;
            for (int i = 0; i < length; i++)
            {
                if (a[i] == b[i]) continue;
                if (a[i] < b[i]) return 0;
                else return 1;
            }

            if (a.Length < b.Length) return 0;
            else return 1;
        }
        
    }
}