namespace CourseworkTPO.AuxiliaryClasses {
    /// <summary>
    /// Represents a person with a name and age, and provides comparison functionality.
    /// </summary>
    public class Person : IComparable<Person> {
        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the age of the person.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Compares the current person with another person based on age.
        /// </summary>
        /// <param name="other">The person to compare with the current person.</param>
        /// <returns>A value indicating the relative order of the persons being compared.</returns>
        public int CompareTo(Person other) {
            if (other == null) return 1;
            return this.Age.CompareTo(other.Age);
        }

        /// <summary>
        /// Returns a string that represents the current person.
        /// </summary>
        /// <returns>A string that contains the name and age of the person.</returns>
        public override string ToString() {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}