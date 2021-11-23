using System;

namespace SortingAlgorithms
{
    public static class ShellSorter
    {
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
            Program.WriteWithDelay($"Расстояние между элементами, которые сравниваются {d}");
            
            while (d >= 1)
            {
                Program.WriteWithDelay($"Пока расстояние {d} больше единицы делаем сравнение");
                for (var i = d; i < array.Length; i++)
                {
                    Program.WriteWithDelay($"Сохраняем [{i}] в temp ");
                    var j = i;
                    Program.WriteWithDelay($"Cдвинуть ранее отсортированные по элементы вверх, пока не будет найдено правильное местоположение для [{i}]");
                    while ((j >= d) && (array[j - d].CompareTo(array[j]))>0)
                    {
                        Swap(ref array[j], ref array[j - d]);
                        Program.WriteWithDelay($"Помещается temp (исходный array[{j}]) в правильное место");
                        j -= d;
                    }
                }
                
                Program.WriteWithDelay($"{d} уменьшается в 2 раза");
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
                return 1;
            }

            if (a.Length < b.Length) return 0;
            return 1;
        }
        
        private static int Increment(long[] inc, long size) {
            int p1 = 1, p2 = 1, p3 = 1, s = -1;
            
            do 
            {
                if (++s % 2 != 0) 
                {
                    inc[s] = 8 * p1 - 6 * p2 + 1;
                } 
                else 
                {
                    inc[s] = 9 * p1 - 9 * p3 + 1;
                    p2 *= 2;
                    p3 *= 2;
                }
                p1 *= 2;
                
            } while(3 * inc[s] < size);  

            return s > 0 ? --s : 0;
        }
        
        public static void SedgwickSort<T>(this T[] a) 
            where T: IComparable
        {
            var size = a.Length;
            long j;
            var seq = new long[40];

            // вычисление последовательности приращений
            int s = Increment(seq, size);
            while (s >= 0) 
            {
                // сортировка вставками с инкрементами inc[] 
                var inc = seq[s--];
                for (var i = inc; i < size; i++) 
                {
                    var temp = a[i];
                    for (j = i - inc; (j >= 0) && (a[j].CompareTo(temp) > 0); j -= inc)
                        a[j + inc] = a[j];
                    a[j + inc] = temp;
                }
            }
        }
    }
}