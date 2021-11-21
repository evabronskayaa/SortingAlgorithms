using System;

namespace SortingAlgorithms
{
    public static class HeapSorter
    {
        public static void HeapSort(this int[] array)
        {
            var n = array.Length;
            for (var i = n / 2 - 1; i >= 0; i--) Heapify(array, n, i);

            for (var i = n-1; i >= 0; i--) 
            {
                var temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                Heapify(array, i, 0);
            }
        }

        private static void Heapify(int[] array, int n, int i)
        {
            var largest = i;
            var left = 2 * i + 1;
            var right = 2 * i + 2;

            if (left < n && array[left] > array[largest]) largest = left;
            if (right < n && array[right] > array[largest]) largest = right;

            if (largest != i)
            {
                var swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;

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

            if (left < n && array[left].CompareTo(array[largest])>0) largest = left;
            if (right < n && array[right].CompareTo(array[largest])>0) largest = right;

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