using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Structure.Interfaces;
using RS.Firstrac.DataObjects.Stores.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Structure.Interfaces
{
    /// <summary>
    /// Interface IFeeGroupStore
    /// Extends the <see cref="RS.Firstrac.DataObjects.Stores.Interfaces.IStoreBase{RS.Firstrac.BusinessObjects.Models.Admin.Interfaces.IFeeGroup}" />
    /// </summary>
    /// <seealso cref="RS.Firstrac.DataObjects.Stores.Interfaces.IStoreBase{RS.Firstrac.BusinessObjects.Models.Admin.Interfaces.IFeeGroup}" />
    public interface IFeeGroupStore : IStoreBase<IFeeGroup>
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
        Task<IAPIOperationResult<IFeeGroup>> Get(int id);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Task&lt;IAPIOperationResult&lt;IEnumerable&lt;TInterface&gt;&gt;&gt;.</returns>
        Task<IAPIOperationResult<IEnumerable<IFeeGroup>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true);
        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;IAPIOperationResult&lt;System.Boolean&gt;&gt;.</returns>
        Task<IAPIOperationResult<bool>> Save(IFeeGroup model);

        #endregion
    }
}
