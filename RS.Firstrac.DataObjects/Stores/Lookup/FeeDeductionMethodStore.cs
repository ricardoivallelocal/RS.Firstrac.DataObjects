using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Lookup.Interfaces;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Lookup.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Lookup
{

    /// <summary>
    /// FeeDeductionMethodStore
    /// </summary>
    /// <seealso cref="RS.Firstrac.DataObjects.Stores.Lookup.Interfaces.IFeeDeductionMethodStore" />
    public class FeeDeductionMethodStore : StoreBase, IFeeDeductionMethodStore
    {

        #region Private Member Variables

        /// <summary>
        /// The firstrac API helper
        /// </summary>
        private readonly IFirstracApiHelper _firstracApiHelper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FeeDeductionMethodStore"/> class.
        /// </summary>
        /// <param name="firstracApiHelper">The firstrac API helper.</param>
        public FeeDeductionMethodStore(IFirstracApiHelper firstracApiHelper) : base(firstracApiHelper)
        {
            _firstracApiHelper = firstracApiHelper;
        }


        #endregion


        #region Public Methods
        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IFeeDeductionMethod&gt;&gt;.</returns>
        public async Task<IAPIOperationResult<IEnumerable<IFeeDeductionMethod>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true)
        {
            if (filterBy?.Any() ?? false)
                return await _firstracApiHelper.PostAsync<Dictionary<string, object>, APIOperationResult<IEnumerable<IFeeDeductionMethod>>>($"api/FeeDeductionMethod/filteredBy?activeOnly={activeOnly}&exactMatch={exactMatch}&mutuallyExclusive={mutuallyExclusive}&includeAllNavigationProperties={includeNavigationProperties}", filterBy);
            else
                return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<IFeeDeductionMethod>>>($"api/FeeDeductionMethod?activeOnly={activeOnly}&includeAllNavigationProperties={includeNavigationProperties}");

        }

        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IAssetGroupCusipLink&gt;&gt;.</returns>
        public override async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(Dictionary<string, object>? filterBy, bool exactMatch = false)
        {
            return await _firstracApiHelper.PostAsync<Dictionary<string, object>, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/FeeDeductionMethod/dropdownItems?exactMatch={exactMatch}", filterBy);
        }

        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Save(IFeeDeductionMethod model)
        {
            return await _firstracApiHelper.PostAsync<IFeeDeductionMethod, APIOperationResult<bool>>("api/FeeDeductionMethod", model);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Delete(int id, string deletedBy)
        {
            return await _firstracApiHelper.DeleteAsync<APIOperationResult<bool>>($"api/FeeDeductionMethod/{id}?deletedBy={deletedBy}");
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;IFeeDeductionMethod&gt;.</returns>
        public async Task<IAPIOperationResult<IFeeDeductionMethod>> Get(int id)
        {
            return await _firstracApiHelper.GetAsync<APIOperationResult<IFeeDeductionMethod>>("api/FeeDeductionMethod/{id}", id);
        }

        #endregion

    }
}
