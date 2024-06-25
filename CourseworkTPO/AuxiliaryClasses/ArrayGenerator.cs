namespace CourseworkTPO.AuxiliaryClasses {
    /// <summary>
    /// This static class provides methods for generating arrays of different types.
    /// </summary>
    public static class ArrayGenerator {
        /// <summary>
        /// Generates an array of a specified type and size.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array. Must implement IComparable<T>.</typeparam>
        /// <param name="size">The size of the array to generate.</param>
        /// <returns>An array of the specified type and size.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the specified type is not supported.</exception>
        public static T[] GenerateArray<T>(int size) where T : IComparable<T> {
            if (typeof(T) == typeof(double)) {
                return GenerateDoubleArray(size) as T[];
            }
            else if (typeof(T) == typeof(Person)) {
                return GeneratePersonArray(size) as T[];
            }
            else {
                throw new InvalidOperationException("Unsupported type");
            }
        }

        /// <summary>
        /// Generates an array of double values with the specified size.
        /// </summary>
        /// <param name="size">The size of the array to generate.</param>
        /// <returns>An array of double values.</returns>
        private static double[] GenerateDoubleArray(int size) {
            double[] array = new double[size];
            Random random = new Random();

            for (int i = 0; i < size; i++) {
                array[i] = Math.Round(random.NextDouble() * 1000000, 3);
            }

            return array;
        }

        /// <summary>
        /// Generates an array of Person objects with the specified size.
        /// </summary>
        /// <param name="size">The size of the array to generate.</param>
        /// <returns>An array of Person objects.</returns>
        private static Person[] GeneratePersonArray(int size) {
            Person[] array = new Person[size];
            Random random = new Random();
            string[] names = { "Alice", "Bob", "Charlie", "David", "Eve", "Frank", "Grace", "Hank" };

            for (int i = 0; i < size; i++) {
                array[i] = new Person {
                    Name = names[random.Next(names.Length)],
                    Age = random.Next(1, 1000000)
                };
            }

            return array;
        }
    }
}