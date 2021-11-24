using System;

namespace SortingAlgorithms
{
    public static class HeapSorter
    {
        public static void HeapSort<T>(this T[] array, bool ascending = true)
            where T: IComparable
        {
            var n = array.Length;
            Program.WriteWithDelay($"{n} - размер массива");
            Program.WriteWithDelay("Построение кучи (перегруппировка массива)");
            for (var i = n / 2 - 1; i >= 0; i--) Heapify(array, n, i);
            
            Program.WriteWithDelay("Один за другим извлекаем элементы из кучи");
            for (var i = n - 1; i >= 0; i--)
            {
                Program.WriteWithDelay("Перемещаем текущий корень в конец ");
                Program.WriteWithDelay($"Меняем местами array[0] и array[{i}]");
                var temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                Program.WriteWithDelay("Вызываем процедуру heapify на уменьшенной куче");
                Heapify(array, i, 0);
            }

            if (!ascending)
            {
                for (int i = 0; i < array.Length - i; i++)
                {
                    var value = array[array.Length - i - 1];
                    array[array.Length - i - 1] = array[i];
                    array[i] = value;
                }
            }
        }

        private static void Heapify<T>(T[] array, int n, int i)
            where T: IComparable
        {
            var largest = i;
            Program.WriteWithDelay($"Инициалация наибольший элемент как корня largest={largest}");
            
            var left = 2 * i + 1;
            Program.WriteWithDelay($"Левый дочерний элемент = 2*{i} + 1");
            
            var right = 2 * i + 2;
            Program.WriteWithDelay($"Правый дочерний элемент = 2*{i} + 2");

            if (left < n && array[left].CompareTo(array[largest]) > 0)
            {
                Program.WriteWithDelay($"Левый дочерний элемент left={left} больше корня largest={largest}");
                largest = left;
            }

            if (right < n && array[right].CompareTo(array[largest]) > 0)
            {
                Program.WriteWithDelay($"Правый дочерний элемент right={right} больше корня largest={largest}");
                largest = right;
            }

            if (largest != i)
            {
                Program.WriteWithDelay("Самый большой элемент не корень");
                var swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;

                Program.WriteWithDelay("Вызываем процедуру heapify на уменьшенной куче");
                Heapify(array, n, largest);
            }
        }
        
        public static void HeapSort<T>(this T[] array, Func<T, IComparable> comparer, bool ascending = true)
            where T: IComparable
        {
            var n = array.Length;
            Program.WriteWithDelay($"{n} - размер массива");
            Program.WriteWithDelay("Построение кучи (перегруппировка массива)");
            for (var i = n / 2 - 1; i >= 0; i--) Heapify(array, n, i);
            
            Program.WriteWithDelay("Один за другим извлекаем элементы из кучи");
            for (var i = n - 1; i >= 0; i--)
            {
                Program.WriteWithDelay("Перемещаем текущий корень в конец ");
                Program.WriteWithDelay($"Меняем местами array[0] и array[{i}]");
                var temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                Program.WriteWithDelay("Вызываем процедуру heapify на уменьшенной куче");
                Heapify(array, i, 0, comparer);
            }

            if (!ascending)
            {
                for (int i = 0; i < array.Length - i; i++)
                {
                    var value = array[array.Length - i - 1];
                    array[array.Length - i - 1] = array[i];
                    array[i] = value;
                }
            }
        }

        private static void Heapify<T>(T[] array, int n, int i, Func<T, IComparable> comparer)
            where T: IComparable
        {
            var largest = i;
            Program.WriteWithDelay($"Инициалация наибольший элемент как корня largest={largest}");
            
            var left = 2 * i + 1;
            Program.WriteWithDelay($"Левый дочерний элемент = 2*{i} + 1");
            
            var right = 2 * i + 2;
            Program.WriteWithDelay($"Правый дочерний элемент = 2*{i} + 2");

            if (left < n && comparer(array[left]).CompareTo(comparer(array[largest])) > 0)
            {
                Program.WriteWithDelay($"Левый дочерний элемент left={left} больше корня largest={largest}");
                largest = left;
            }

            if (right < n && comparer(array[right]).CompareTo(comparer(array[largest])) > 0)
            {
                Program.WriteWithDelay($"Правый дочерний элемент right={right} больше корня largest={largest}");
                largest = right;
            }

            if (largest != i)
            {
                Program.WriteWithDelay("Самый большой элемент не корень");
                var swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;

                Program.WriteWithDelay("Вызываем процедуру heapify на уменьшенной куче");
                Heapify(array, n, largest, comparer);
            }
        }
    }
}