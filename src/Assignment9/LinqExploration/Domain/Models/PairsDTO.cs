namespace LinqExploration.Domain.Models
{
    /// <summary>
    /// Represents a pair of numbers that satisfy a specified condition,
    /// such as summing up to a target value.
    /// </summary>
    public class PairsDTO
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PairsDTO"/> class.
        /// </summary>
        /// <param name="number1">
        /// The first number in the pair.
        /// </param>
        /// <param name="number2">
        /// The second number in the pair.
        /// </param>
        public PairsDTO(int number1, int number2)
        {
            this.FirstNumber = number1;
            this.SecondNumber = number2;
        }

        /// <summary>
        /// Gets or sets the first number.
        /// </summary>
        /// <value>
        /// The first value of the matching number pair.
        /// </value>
        public int FirstNumber { get; set; }

        /// <summary>
        /// Gets or sets the second number.
        /// </summary>
        /// <value>
        /// The second value of the matching number pair.
        /// </value>
        public int SecondNumber { get; set; }
    }
}