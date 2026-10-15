namespace Task6.Application
{
    /// <summary>
    /// Provides operations for working with collections,
    /// including aggregation and dictionary generation.
    /// </summary>
    public class CollectionService
    {
        /// <summary>
        /// Calculates the sum of all elements in the specified collection.
        /// </summary>
        /// <param name="collection">
        /// The collection of integers whose elements are to be summed.
        /// </param>
        /// <returns>
        /// The total sum of all elements in the collection.
        /// </returns>
        public int GetSumOfElements(IEnumerable<int> collection)
        {
            return collection.Sum();
        }

        /// <summary>
        /// Generates and returns a read-only dictionary containing
        /// sample key-value pairs.
        /// </summary>
        /// <returns>
        /// An <see cref="IReadOnlyDictionary{TKey, TValue}"/> containing
        /// predefined string keys and integer values.
        /// </returns>
        public IReadOnlyDictionary<string, int> GenerateDictionary()
        {
            var dictionary = new Dictionary<string, int>();
            dictionary.Add("Ln", 10);
            dictionary.Add("Db", 20);
            dictionary.Add("Jk", 30);
            return dictionary;
        }
    }
}