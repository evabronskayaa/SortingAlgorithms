namespace SortingAlgorithms
{
    public static class HeapSort
    {
        public static void Sort(int[] arr)
        {
            var n = arr.Length;
            for (var i = n / 2 - 1; i >= 0; i--) Heapify(arr, n, i);

            for (var i = n-1; i >= 0; i--) 
            {
                var temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                Heapify(arr, i, 0);
            }
        }

        private static void Heapify(int[] arr, int n, int i)
        {
            var largest = i;
            var left = 2 * i + 1;
            var right = 2 * i + 2;

            if (left < n && arr[left] > arr[largest]) largest = left;
            if (right < n && arr[right] > arr[largest]) largest = right;

            if (largest != i)
            {
                var swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                Heapify(arr, n, largest);
            }
        }
    }
}