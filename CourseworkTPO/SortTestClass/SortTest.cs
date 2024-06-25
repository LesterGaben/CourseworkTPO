using CourseworkTPO.AuxiliaryClasses;
using CourseworkTPO.QuickSortAlgorithms;
using System.Diagnostics;

namespace CourseworkTPO.SortTestClass {
    /// <summary>
    /// This static class provides methods to test the performance of sequential and parallel QuickSort algorithms.
    /// </summary>
    public static class SortTest {
        /// <summary>
        /// Tests the performance of the sequential QuickSort algorithm.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array. Must implement IComparable<T>.</typeparam>
        /// <param name="arraySizes">An array of sizes for the arrays to be tested.</param>
        /// <param name="repetitions">The number of repetitions for each test.</param>
        public static void TestSequentialSort<T>(int[] arraySizes, int repetitions) where T : IComparable<T> {
            foreach (int size in arraySizes) {
                double totalDuration = 0;
                for (int i = 0; i < repetitions; i++) {
                    T[] array = ArrayGenerator.GenerateArray<T>(size);
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    SequentialQuickSort.Sort(array, 0, array.Length - 1);
                    stopwatch.Stop();
                    totalDuration += stopwatch.Elapsed.TotalMilliseconds;

                    if (!ArrayUtilities.IsSorted(array)) {
                        Console.WriteLine($"Array is not sorted correctly for size {size}.");
                    }
                }
                double averageDuration = totalDuration / repetitions;
                Console.WriteLine($"Average duration for sequential sort with array size {size}: {averageDuration} ms");
            }
        }

        /// <summary>
        /// Tests the performance of the parallel QuickSort algorithm.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array. Must implement IComparable<T>.</typeparam>
        /// <param name="arraySizes">An array of sizes for the arrays to be tested.</param>
        /// <param name="repetitions">The number of repetitions for each test.</param>
        /// <param name="threadCounts">An array of thread counts to be used for parallel sorting.</param>
        public static void TestParallelSort<T>(int[] arraySizes, int repetitions, int[] threadCounts) where T : IComparable<T> {
            foreach (int size in arraySizes) {
                foreach (int threadCount in threadCounts) {
                    double totalDuration = 0;
                    for (int i = 0; i < repetitions; i++) {
                        T[] array = ArrayGenerator.GenerateArray<T>(size);
                        Stopwatch stopwatch = Stopwatch.StartNew();
                        ParallelQuickSort.Sort(array, threadCount);
                        stopwatch.Stop();
                        totalDuration += stopwatch.Elapsed.TotalMilliseconds;

                        if (!ArrayUtilities.IsSorted(array)) {
                            Console.WriteLine($"Array is not sorted correctly for size {size} and thread count {threadCount}.");
                        }
                    }
                    double averageDuration = totalDuration / repetitions;
                    Console.WriteLine($"Average duration for parallel sort with array size {size} and thread count {threadCount}: {averageDuration} ms");
                }
            }
        }

        /// <summary>
        /// Tests the performance of the parallel QuickSort algorithm with different sequential thresholds.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array. Must implement IComparable<T>.</typeparam>
        /// <param name="arraySizes">An array of sizes for the arrays to be tested.</param>
        /// <param name="repetitions">The number of repetitions for each test.</param>
        /// <param name="thresholds">An array of thresholds for switching to sequential sort.</param>
        public static void TestParallelSortWithThreshold<T>(int[] arraySizes, int repetitions, int[] thresholds) where T : IComparable<T> {
            int threadCount = Environment.ProcessorCount;
            foreach (int size in arraySizes) {
                foreach (int threshold in thresholds) {
                    double totalDuration = 0;
                    for (int i = 0; i < repetitions; i++) {
                        T[] array = ArrayGenerator.GenerateArray<T>(size);
                        Stopwatch stopwatch = Stopwatch.StartNew();
                        ParallelQuickSort.Sort(array, threadCount, threshold);
                        stopwatch.Stop();
                        totalDuration += stopwatch.Elapsed.TotalMilliseconds;

                        if (!ArrayUtilities.IsSorted(array)) {
                            Console.WriteLine($"Array is not sorted correctly for size {size}, thread count {threadCount}, and threshold {threshold}.");
                        }
                    }
                    double averageDuration = totalDuration / repetitions;
                    Console.WriteLine($"Average duration for parallel sort with array size {size}, thread count {threadCount}, and threshold {threshold}: {averageDuration} ms");
                }
            }
        }
    }
}