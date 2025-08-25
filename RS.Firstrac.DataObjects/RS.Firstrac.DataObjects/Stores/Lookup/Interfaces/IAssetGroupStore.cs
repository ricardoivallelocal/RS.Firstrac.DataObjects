using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Lookup.Interfaces;
using RS.Firstrac.DataObjects.Stores.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Lookup.Interfaces
{
    /// <summary>
    /// IAssetGroupStore Interface
    /// </summary>
    /// <seealso cref="RS.Firstrac.DataObjects.Stores.Interfaces.IStoreBase&lt;RS.Firstrac.BusinessObjects.Models.AssetGroup.Interfaces.IAssetGroup&gt;" />
    public interface IAssetGroupStore : IStoreBase<IAssetGroup>
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

        Task<IAPIOperationResult<IAssetGroup>> Get(int id);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Task&lt;IAPIOperationResult&lt;IEnumerable&lt;TInterface&gt;&gt;&gt;.</returns>

        Task<IAPIOperationResult<IEnumerable<IAssetGroup>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true);
        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;IAPIOperationResult&lt;System.Boolean&gt;&gt;.</returns>
        Task<IAPIOperationResult<bool>> Save(IAssetGroup model);

        /// <summary>
        /// Gets for dropdown.
        /// </summary>
        /// <param name="filterBy">The filter by.</param>
        /// <param name="exactMatch">if set to <c>true</c> [exact match].</param>
        /// <returns></returns>
        Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(Dictionary<string, object>? filterBy, bool exactMatch = false);
        #endregion
    }
}
