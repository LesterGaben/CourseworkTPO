namespace CourseworkTPO.AuxiliaryClasses {
    /// <summary>
    /// This static class provides utility methods for array operations.
    /// </summary>
    public static class ArrayUtilities {

        /// <summary>
        /// Prints the elements of an array to the console.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The array whose elements are to be printed.</param>
        public static void PrintArray<T>(T[] array) {
            for (int i = 0; i < array.Length; i++) {
                if (i > 0) {
                    Console.Write("; ");
                }
                Console.Write(array[i]);
            }
            Console.WriteLine("\n");
        }

        /// <summary>
        /// Checks if the elements in the array are sorted in ascending order.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array. Must implement IComparable<T>.</typeparam>
        /// <param name="array">The array to be checked.</param>
        /// <returns>True if the array is sorted in ascending order, otherwise false.</returns>
        public static bool IsSorted<T>(T[] array) where T : IComparable<T> {
            for (int i = 1; i < array.Length; i++) {
                if (array[i - 1].CompareTo(array[i]) > 0) {
                    return false;
                }
            }
            return true;
        }
    }
}