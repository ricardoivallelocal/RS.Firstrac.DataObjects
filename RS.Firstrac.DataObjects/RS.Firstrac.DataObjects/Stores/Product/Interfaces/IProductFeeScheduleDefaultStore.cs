using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Product.Interfaces;
using RS.Firstrac.DataObjects.Stores.Interfaces;


namespace RS.Firstrac.DataObjects.Stores.Product.Interfaces
{
    /// <summary>
    /// IProductFeeScheduleDefault Interface
    /// </summary>
    /// <seealso cref="RS.Firstrac.DataObjects.Stores.Interfaces.IStoreBase&lt;RS.Firstrac.BusinessObjects.Models.Product.Interfaces.IProduct&gt;" />
    public interface IProductFeeScheduleDefaultStore : IStoreBase<IProductFeeScheduleDefault>
    {
        #region Methods

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IAPIOperationResult&lt;System.Boolean&gt;&gt;.</returns>
        
        Task<IAPIOperationResult<bool>> Delete(int id, string deletedBy);
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IAPIOperationResult&lt;TInterface&gt;&gt;.</returns>
        
        Task<IAPIOperationResult<IProductFeeScheduleDefault>> Get(int id);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Task&lt;IAPIOperationResult&lt;IEnumerable&lt;TInterface&gt;&gt;&gt;.</returns>
        
        Task<IAPIOperationResult<IEnumerable<IProductFeeScheduleDefault>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true);
        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;IAPIOperationResult&lt;System.Boolean&gt;&gt;.</returns>
        Task<IAPIOperationResult<bool>> Save(IProductFeeScheduleDefault model);

        #endregion
    }
}
