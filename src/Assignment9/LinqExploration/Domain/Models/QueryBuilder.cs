namespace LinqExploration.Domain.Models
{
    /// <summary>
    /// Provides a fluent API for building and executing LINQ queries.
    /// Supports filtering, sorting, and joining operations.
    /// </summary>
    /// <typeparam name="T">The type of the primary data source.</typeparam>
    public class QueryBuilder<T>
    {
        private IEnumerable<T> _query;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilder{T}"/> class
        /// with the specified data source.
        /// </summary>
        /// <param name="data">The collection to query against.</param>
        public QueryBuilder(IEnumerable<T> data)
        {
            this._query = data;
        }

        /// <summary>
        /// Applies a filter condition to the current query.
        /// </summary>
        /// <param name="predicate">
        /// A function that defines the condition used to filter elements.
        /// </param>
        /// <returns>
        /// The current <see cref="QueryBuilder{T}"/> instance to enable fluent chaining.
        /// </returns>
        public QueryBuilder<T> Filter(Func<T, bool> predicate)
        {
            this._query = this._query.Where(predicate);
            return this;
        }

        /// <summary>
        /// Sorts the current query in ascending order based on the specified key.
        /// </summary>
        /// <typeparam name="TKey">
        /// The type of the value used as the sort key.
        /// </typeparam>
        /// <param name="keySelector">
        /// A function that selects the property to sort by.
        /// </param>
        /// <returns>
        /// The current <see cref="QueryBuilder{T}"/> instance to enable fluent chaining.
        /// </returns>
        public QueryBuilder<T> SortBy<TKey>(Func<T, TKey> keySelector)
        {
            this._query = this._query.OrderBy(keySelector);
            return this;
        }

        /// <summary>
        /// Joins the current query with another collection based on matching keys.
        /// </summary>
        /// <typeparam name="TInner">
        /// The type of elements in the collection being joined.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key used to match elements from both collections.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the object produced by the join operation.
        /// </typeparam>
        /// <param name="inner">
        /// The collection to join with.
        /// </param>
        /// <param name="outerKey">
        /// A function that selects the join key from the current query.
        /// </param>
        /// <param name="innerKey">
        /// A function that selects the join key from the inner collection.
        /// </param>
        /// <param name="resultSelector">
        /// A function that creates the result object from matching elements.
        /// </param>
        /// <returns>
        /// A new <see cref="QueryBuilder{TResult}"/> containing the joined results.
        /// </returns>
        public QueryBuilder<TResult> Join<TInner, TKey, TResult>(
            IEnumerable<TInner> inner,
            Func<T, TKey> outerKey,
            Func<TInner, TKey> innerKey,
            Func<T, TInner, TResult> resultSelector)
        {
            var joinedData = this._query.Join(
                inner,
                outerKey,
                innerKey,
                resultSelector);

            return new QueryBuilder<TResult>(joinedData);
        }

        /// <summary>
        /// Executes the constructed query and materializes the results into a list.
        /// </summary>
        /// <returns>
        /// A list containing the query results.
        /// </returns>
        public List<T> Execute()
        {
            return this._query.ToList();
        }
    }
}