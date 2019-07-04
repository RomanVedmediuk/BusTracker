namespace BusTracker.Utilities.Serializers
{
    /// <summary>
    /// Interface IDataContractSerializer
    /// </summary>
    public interface IDataContractSerializer
    {
        /// <summary>
        /// Serializes the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>System.String.</returns>
        string Serialize<TEntity>(TEntity entity)
            where TEntity : class, new();

        /// <summary>
        /// Deserializes the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>TEntity.</returns>
        TEntity Deserialize<TEntity>(string entity)
            where TEntity : class, new();
    }
}