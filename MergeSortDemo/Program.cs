using System;

namespace MergeSortDemo
{
    class Program
    {
        static void Main()
        {
            int[] array = { 54, 34, 786, 13, 6, 65, 2, 3, 2 };
            MergeSort(array);
            PrintArray(array);
            Console.ReadKey();
        }

        public static void PrintArray(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
        }

        public static void MergeSort(int[] array)
        {
            if (array.Length < 2)
            {
                return;
            }
            int step = 1;
            int startL, startR;

            while (step < array.Length)
            {
                startL = 0;
                startR = step;
                while (startR + step <= array.Length)
                {
                    Merge(array, startL, startL + step, startR, startR + step);
                    startL = startR + step;
                    startR = startL + step;
                }
                if (startR < array.Length)
                {
                    Merge(array, startL, startL + step, startR, array.Length);
                }
                step *= 2;
            }
        }

        public static void Merge(int[] array, int startL, int stopL, int startR, int stopR)
        {
            int[] right = new int[stopR - startR + 1];
            int[] left = new int[stopL - startL + 1];

            for (int i = 0, k = startR; i < (right.Length - 1); ++i, ++k)
            {
                right[i] = array[k];
            }
            for (int i = 0, k = startL; i < (left.Length - 1); ++i, ++k)
            {
                left[i] = array[k];
            }

            right[right.Length - 1] = Int32.MaxValue;
            left[left.Length - 1] = Int32.MaxValue;

            for (int k = startL, m = 0, n = 0; k < stopR; ++k)
            {
                if (left[m] <= right[n])
                {
                    array[k] = left[m];
                    m++;
                }
                else
                {
                    array[k] = right[n];
                    n++;
                }
            }
        }
    }
}
