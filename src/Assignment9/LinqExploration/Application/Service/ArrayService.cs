using LinqExploration.Domain.Models;

namespace LinqExploration.Application.Service
{
    /// <summary>
    /// Provides utility methods for performing LINQ operations on integer arrays.
    /// </summary>
    public class ArrayService
    {
        /// <summary>
        /// Finds the second highest distinct element in the array.
        /// </summary>
        /// <param name="arr">The source array.</param>
        /// <returns>The second highest distinct value.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the array contains fewer than two distinct elements.
        /// </exception>
        public int GetSecondHighestElement(int[] arr)
        {
            var distinctElements = arr
                .Distinct()
                .OrderByDescending(num => num)
                .ToList();

            if (distinctElements.Count < 2)
            {
                throw new InvalidOperationException(
                    "The array must contain at least two distinct elements.");
            }

            return distinctElements[1];
        }

        /// <summary>
        /// Finds all unique pairs of numbers whose sum equals the specified target value.
        /// </summary>
        /// <param name="arr">The source array.</param>
        /// <param name="target">The target sum.</param>
        /// <returns>
        /// A list of <see cref="PairsDTO"/> objects containing the matching pairs.
        /// </returns>
        public List<PairsDTO> GetPairsWithTargetSum(int[] arr, int target)
        {
            return arr.SelectMany(
                    (number, index) => arr
                        .Skip(index + 1)
                        .Where(otherNumber => otherNumber + number == target)
                        .Select(otherNumber => new PairsDTO(number, otherNumber)))
                .Distinct()
                .ToList();
        }
    }
}
