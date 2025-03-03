using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.BusinessObjects.Models.Structure.Interfaces;
using RS.Firstrac.DataObjects.Stores.Structure.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Structure;
using RS.Firstrac.BusinessObjects.Models.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Structure
{
    /// <summary>
    /// Class FeeGroupStore.
    /// Implements the <see cref="IFeeGroupStore" />
    /// </summary>
    /// <seealso cref="IFeeGroupStore" />
    public class FeeGroupAccountStore : StoreBase, IFeeGroupAccountStore
    {
        #region Private Member Variables

        /// <summary>
        /// The firstrac API helper
        /// </summary>
        private readonly IFirstracApiHelper _firstracApiHelper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FeeGroupStore"/> class.
        /// </summary>
        /// <param name="firstracApiHelper">The firstrac API helper.</param>
        public FeeGroupAccountStore(IFirstracApiHelper firstracApiHelper) : base(firstracApiHelper)
        {
            _firstracApiHelper = firstracApiHelper;
        }


        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IFeeGroup&gt;&gt;.</returns>
        public async Task<IAPIOperationResult<IEnumerable<IFeeGroupAccount>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true)
        {
            try
            {
                if (filterBy?.Any() ?? false)
                    return await _firstracApiHelper.PostAsync<Dictionary<string, object>, APIOperationResult<IEnumerable<IFeeGroupAccount>>>($"api/FeeGroupAccount/filteredBy?activeOnly={activeOnly}&exactMatch={exactMatch}&mutuallyExclusive={mutuallyExclusive}&includeAllNavigationProperties={includeNavigationProperties}", filterBy);
                else
                    return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<IFeeGroupAccount>>>($"api/FeeGroupAccount?activeOnly={activeOnly}&includeAllNavigationProperties={includeNavigationProperties}");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IAssetGroupCusipLink&gt;&gt;.</returns>
        public override async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(Dictionary<string, object>? filterBy, bool exactMatch = false)
        {

            return await _firstracApiHelper.PostAsync<Dictionary<string, object>, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/FeeGroupAccount/dropdownItems?exactMatch={exactMatch}", filterBy);
        }

        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Save(IFeeGroupAccount model)
        {
            return await _firstracApiHelper.PostAsync<IFeeGroupAccount, APIOperationResult<bool>>("api/FeeGroupAccount", model);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Delete(int id, string deletedBy)
        {
            return await _firstracApiHelper.DeleteAsync<APIOperationResult<bool>>($"api/FeeGroupAccount/{id}?deletedBy={deletedBy}");
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;IFeeGroup&gt;.</returns>
        public async Task<IAPIOperationResult<IFeeGroupAccount>> Get(int id)
        {
            return await _firstracApiHelper.GetAsync<APIOperationResult<IFeeGroupAccount>>($"api/FeeGroupAccount/{id}");
        }

        /// <summary>
        /// Searches the by other fields.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<IAPIOperationResult<IEnumerable<IFeeGroupAccount>>> SearchByOtherFields(SearchFeeGroupAccountsbyOtherFieldsRequest request)
        {
            return await _firstracApiHelper.PostAsync<SearchFeeGroupAccountsbyOtherFieldsRequest, APIOperationResult<IEnumerable<IFeeGroupAccount>>>($"api/FeeGroupAccount/searchByOtherFields", request);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;IFeeGroup&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Close(int feeGroupAccountId)
        {
            return await _firstracApiHelper.GetAsync<APIOperationResult<bool>>($"api/FeeGroupAccount/close/{feeGroupAccountId}");
        }
        #endregion
    }
}
