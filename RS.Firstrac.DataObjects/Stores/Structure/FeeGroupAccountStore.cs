using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.BusinessObjects.Models.Structure.Interfaces;
using RS.Firstrac.DataObjects.Stores.Structure.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Structure;
using RS.Firstrac.BusinessObjects.Models.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Interfaces.Requests;
using RS.Firstrac.BusinessObjects.Models.Requests;

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
        public async Task<IAPIOperationResult<IEnumerable<IFeeGroupAccount>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true, Dictionary<string,object>? dependencies = null)
        {
            try
            {
                if (filterBy?.Any() ?? false)
                {
                    var request = GetAllRequest.Build(activeOnly ?? true, filterBy, exactMatch ?? true, mutuallyExclusive ?? false, includeNavigationProperties ?? true, null, false, dependencies);
                    return await _firstracApiHelper.PostAsync<IGetAllRequest, APIOperationResult<IEnumerable<IFeeGroupAccount>>>($"api/FeeGroupAccount/filteredBy", request);
                    
                }

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
        public override async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string,object>? dependencies = null)
        {
            var request = GetForDropdownRequest.Build(filterBy, exactMatch, dependencies);
            return await _firstracApiHelper.PostAsync<IGetForDropdownRequest, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/FeeGroupAccount/dropdownItems", request);
        }

        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IAssetGroupCusipLink&gt;&gt;.</returns>
        public async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetTemplatesForDropdown(string searchPattern, bool activeOnly)
        {

            return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<IDropdownItem>>>($"api/FeeGroupAccount/template/dropdownItems?searchPattern={searchPattern}&activeOnly={activeOnly}");
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

        /// <summary>
        /// Gets for dropdown by white label sub group ids.
        /// </summary>
        /// <param name="filterBy">The filter by.</param>
        /// <param name="exactMatch">if set to <c>true</c> [exact match].</param>
        /// <param name="dependencies">The dependencies.</param>
        /// <returns></returns>
        public async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdownByWhiteLabelSubGroupsAndFeeGroup(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string, object>? dependencies = null)
        {
            var request = GetForDropdownRequest.Build(filterBy, exactMatch, dependencies);
            return await _firstracApiHelper.PostAsync<IGetForDropdownRequest, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/FeeGroupAccount/dropdownItemsByWhiteLabelSubGroupsAndFeeGroup", request);
        }
        #endregion
    }
}
