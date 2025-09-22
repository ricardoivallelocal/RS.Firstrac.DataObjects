using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Interfaces.Requests;
using RS.Firstrac.BusinessObjects.Models.Invoice.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Lookup.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Requests;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Lookup.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Lookup
{
    public class AccountTypeStore : StoreBase, IAccountTypeStore
    {

        #region Private Member Variables

        /// <summary>
        /// The firstrac API helper
        /// </summary>
        private readonly IFirstracApiHelper _firstracApiHelper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTypeStore"/> class.
        /// </summary>
        /// <param name="firstracApiHelper">The firstrac API helper.</param>
        public AccountTypeStore(IFirstracApiHelper firstracApiHelper) : base(firstracApiHelper)
        {
            _firstracApiHelper = firstracApiHelper;
        }


        #endregion


        #region Public Methods
        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IAccountType&gt;&gt;.</returns>
        public async Task<IAPIOperationResult<IEnumerable<IAccountType>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true, Dictionary<string,object>? dependencies = null)
        {
            if (filterBy?.Any() ?? false)
            {
                var request = GetAllRequest.Build(activeOnly ?? true, filterBy, exactMatch ?? true, mutuallyExclusive ?? false, includeNavigationProperties ?? true, null, false, dependencies);
                return await _firstracApiHelper.PostAsync<IGetAllRequest, APIOperationResult<IEnumerable<IAccountType>>>($"api/AccountType/filteredBy", request);
               
            }
           
            else
                return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<IAccountType>>>($"api/AccountType?activeOnly={activeOnly}&includeAllNavigationProperties={includeNavigationProperties}");


        }

        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IAssetGroupCusipLink&gt;&gt;.</returns>
        public override async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string,object>? dependencies = null)
        {
            var request = GetForDropdownRequest.Build(filterBy, exactMatch, dependencies);
            return await _firstracApiHelper.PostAsync<IGetForDropdownRequest, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/AccountType/dropdownItems", request);
        }


        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Save(IAccountType model)
        {
            return await _firstracApiHelper.PostAsync<IAccountType, APIOperationResult<bool>>("api/AccountType", model);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Delete(int id, string deletedBy)
        {
            return await _firstracApiHelper.DeleteAsync<APIOperationResult<bool>>($"api/AccountType/{id}?deletedBy={deletedBy}");
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;IAccountType&gt;.</returns>
        public async Task<IAPIOperationResult<IAccountType>> Get(int id)
        {
            return await _firstracApiHelper.GetAsync<APIOperationResult<IAccountType>>("api/AccountType/{id}", id);
        }

        /// <summary>
        /// Gets the by asset group identifier.
        /// </summary>
        /// <param name="assetGroupId">The asset group identifier.</param>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IAccountType&gt;&gt;.</returns>
        public async Task<IAPIOperationResult<IEnumerable<IAccountType>>> GetByAssetGroupId(int assetGroupId)
        {
            return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<IAccountType>>>("api/AccountType/assetGroupId/{assetGroupId}", assetGroupId);
        }

        #endregion

    }
}
