using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Structure.Interfaces;
using RS.Firstrac.DataObjects.Stores.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Lookup.Interfaces
{

    /// <summary>
    /// IACHBankSettingStore
    /// </summary>
    public interface IACHBankSettingStore : IStoreBase<IACHBankSetting>
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
        Task<IAPIOperationResult<IACHBankSetting>> Get(int id);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Task&lt;IAPIOperationResult&lt;IEnumerable&lt;TInterface&gt;&gt;&gt;.</returns>
        Task<IAPIOperationResult<IEnumerable<IACHBankSetting>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true, Dictionary<string,object>? dependencies = null);
        /// <summary>
        /// Gets the by asset group identifier.
        /// </summary>
        /// <param name="assetGroupId">The asset group identifier.</param>
        /// <returns>Task&lt;IAPIOperationResult&lt;IEnumerable&lt;IACHBankSetting&gt;&gt;&gt;.</returns>
        Task<IAPIOperationResult<IEnumerable<IACHBankSetting>>> GetByAssetGroupId(int assetGroupId);
        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;IAPIOperationResult&lt;System.Boolean&gt;&gt;.</returns>
        Task<IAPIOperationResult<bool>> Save(IACHBankSetting model);

        #endregion
    }
}
