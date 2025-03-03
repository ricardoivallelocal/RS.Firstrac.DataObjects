using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Lookup.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Structure.Interfaces;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Lookup.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Lookup
{
    public class ACHBankSettingStore : StoreBase, IACHBankSettingStore
    {

        #region Private Member Variables

        /// <summary>
        /// The firstrac API helper
        /// </summary>
        private readonly IFirstracApiHelper _firstracApiHelper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ACHBankSettingStore"/> class.
        /// </summary>
        /// <param name="firstracApiHelper">The firstrac API helper.</param>
        public ACHBankSettingStore(IFirstracApiHelper firstracApiHelper) : base(firstracApiHelper)
        {
            _firstracApiHelper = firstracApiHelper;
        }


        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IACHBankSetting&gt;&gt;.</returns>
        public async Task<IAPIOperationResult<IEnumerable<IACHBankSetting>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true)
        {
            if (filterBy?.Any() ?? false)
                return await _firstracApiHelper.PostAsync<Dictionary<string, object>, APIOperationResult<IEnumerable<IACHBankSetting>>>($"api/ACHBankSetting/filteredBy?activeOnly={activeOnly}&exactMatch={exactMatch}&mutuallyExclusive={mutuallyExclusive}&includeAllNavigationProperties={includeNavigationProperties}", filterBy);
            else
                return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<IACHBankSetting>>>($"api/ACHBankSetting?activeOnly={activeOnly}&includeAllNavigationProperties={includeNavigationProperties}");


        }

        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IAssetGroupCusipLink&gt;&gt;.</returns>
        public override async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(Dictionary<string, object>? filterBy, bool exactMatch = false)
        {

            return await _firstracApiHelper.PostAsync<Dictionary<string, object>, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/ACHBankSetting/dropdownItems?exactMatch={exactMatch}", filterBy);
        }

        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Save(IACHBankSetting model)
        {
            return await _firstracApiHelper.PostAsync<IACHBankSetting, APIOperationResult<bool>>("api/ACHBankSetting", model);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Delete(int id, string deletedBy)
        {
            return await _firstracApiHelper.DeleteAsync<APIOperationResult<bool>>($"api/ACHBankSetting/{id}?deletedBy={deletedBy}");
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;IACHBankSetting&gt;.</returns>
        public async Task<IAPIOperationResult<IACHBankSetting>> Get(int id)
        {
            return await _firstracApiHelper.GetAsync<APIOperationResult<IACHBankSetting>>("api/ACHBankSetting/{id}", id);
        }

        /// <summary>
        /// Gets the by asset group identifier.
        /// </summary>
        /// <param name="assetGroupId">The asset group identifier.</param>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IACHBankSetting&gt;&gt;.</returns>
        public async Task<IAPIOperationResult<IEnumerable<IACHBankSetting>>> GetByAssetGroupId(int assetGroupId)
        {
            return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<IACHBankSetting>>>("api/ACHBankSetting/assetGroupId/{assetGroupId}", assetGroupId);
        }

        #endregion

    }
}
