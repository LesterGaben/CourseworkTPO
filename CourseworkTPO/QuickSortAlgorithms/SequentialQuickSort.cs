﻿namespace CourseworkTPO.QuickSortAlgorithms {
    /// <summary>
    /// This static class provides an implementation of the Sequential QuickSort algorithm.
    /// </summary>
    public static class SequentialQuickSort {
        /// <summary>
        /// Sorts an array using the QuickSort algorithm.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array. Must implement IComparable<T>.</typeparam>
        /// <param name="array">The array to be sorted.</param>
        /// <param name="minIndex">The starting index of the portion of the array to be sorted.</param>
        /// <param name="maxIndex">The ending index of the portion of the array to be sorted.</param>
        public static void Sort<T>(T[] array, int minIndex, int maxIndex) where T : IComparable<T> {
            if (minIndex < maxIndex) {
                int pivotIndex = Partition(array, minIndex, maxIndex);

                Sort(array, minIndex, pivotIndex - 1);
                Sort(array, pivotIndex + 1, maxIndex);
            }
        }

        /// <summary>
        /// Partitions the array into two halves and returns the pivot index.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array. Must implement IComparable<T>.</typeparam>
        /// <param name="array">The array to be partitioned.</param>
        /// <param name="minIndex">The starting index of the portion of the array to be partitioned.</param>
        /// <param name="maxIndex">The ending index of the portion of the array to be partitioned.</param>
        /// <returns>The index of the pivot element after partitioning.</returns>
        private static int Partition<T>(T[] array, int minIndex, int maxIndex) where T : IComparable<T> {
            T pivot = array[maxIndex];
            int i = minIndex - 1;

            for (int j = minIndex; j < maxIndex; j++) {
                if (array[j].CompareTo(pivot) < 0) {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, maxIndex);
            return i + 1;
        }

        /// <summary>
        /// Swaps the elements at the specified indices in the array.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The array in which elements are to be swapped.</param>
        /// <param name="i">The index of the first element to be swapped.</param>
        /// <param name="j">The index of the second element to be swapped.</param>
        private static void Swap<T>(T[] array, int i, int j) {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}