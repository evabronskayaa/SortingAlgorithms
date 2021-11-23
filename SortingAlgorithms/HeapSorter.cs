using System;

namespace SortingAlgorithms
{
    public static class HeapSorter
    {
        public static void HeapSort(this int[] array)
        {
            var n = array.Length;
            Program.WriteWithDelay($"{n} - размер массива");
            Program.WriteWithDelay("Построение кучи (перегруппировка массива)");
            for (var i = n / 2 - 1; i >= 0; i--) Heapify(array, n, i);

            Program.WriteWithDelay("Один за другим извлекаем элементы из кучи");
            for (var i = n-1; i >= 0; i--) 
            {
                Program.WriteWithDelay("Перемещаем текущий корень в конец ");
                Program.WriteWithDelay($"Меняем местами array[0] и array[{i}]");
                var temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                Program.WriteWithDelay("Вызываем процедуру heapify на уменьшенной куче");
                Heapify(array, i, 0);
            }
        }

        private static void Heapify(int[] array, int n, int i)
        {
            var largest = i;
            Program.WriteWithDelay($"Инициалация наибольший элемент как корня largest={largest}");
            var left = 2 * i + 1;
            Program.WriteWithDelay($"Левый дочерний элемент = 2*{i} + 1");
            var right = 2 * i + 2;
            Program.WriteWithDelay($"Правый дочерний элемент = 2*{i} + 2");
            
            if (left < n && array[left] > array[largest])
            {
                largest = left;
                Program.WriteWithDelay($"Левый дочерний элемент left={left} больше корня largest={largest}");
            }

            
            if (right < n && array[right] > array[largest])
            {
                largest = right;
                Program.WriteWithDelay($"Правый дочерний элемент right={right} больше корня largest={largest}");
            }
            
            if (largest != i)
            {
                Program.WriteWithDelay("Самый большой элемент не корень");
                var swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;

                Program.WriteWithDelay("Рекурсивно преобразуем в двоичную кучу затронутое поддерево");
                Heapify(array, n, largest);
            }
        }

        public static void HeapSort<T>(this T[] array)
            where T: IComparable
        {
            var n = array.Length;
            for (var i = n / 2 - 1; i >= 0; i--) Heapify(array, n, i);

            for (var i = n - 1; i >= 0; i--)
            {
                var temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                Heapify(array, i, 0);
            }
        }

        private static void Heapify<T>(T[] array, int n, int i)
            where T: IComparable
        {
            var largest = i;
            var left = 2 * i + 1;
            var right = 2 * i + 2;

            if (left < n && array[left].CompareTo(array[largest]) > 0) largest = left;
            if (right < n && array[right].CompareTo(array[largest]) > 0) largest = right;

            if (largest != i)
            {
                var swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;

                Heapify(array, n, largest);
            }
        }
    }
}