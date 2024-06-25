using CourseworkTPO.AuxiliaryClasses;
using CourseworkTPO.QuickSortAlgorithms;
using CourseworkTPO.SortTestClass;

namespace CourseworkTPO {
    public class Program {
        public static void Main(string[] args) {

            int[] threads = { 2, 4, 6, 8, 12, 16 };

            int[] arraySizes = { 600_000, 1_200_000, 2_400_000, 6_000_000, 12_000_000,
                                24_000_000, 60_000_000, 120_000_000, 240_000_000};
            
            int repetitions = 5;

            SortTest.TestSequentialSort<double>(arraySizes, repetitions);
            SortTest.TestParallelSort<double>(arraySizes, repetitions, threads);
        }
    }
}