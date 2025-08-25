using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Lookup.Interfaces;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Lookup.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Lookup
{
    /// <summary>
    /// HandlingDestinationStore
    /// </summary>
    /// <seealso cref="RS.Firstrac.DataObjects.Stores.Lookup.Interfaces.IHandlingDestinationStore" />
    public class HandlingDestinationStore : StoreBase, IHandlingDestinationStore
    {

        #region Private Member Variables

        /// <summary>
        /// The firstrac API helper
        /// </summary>
        private readonly IFirstracApiHelper _firstracApiHelper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HandlingDestinationStore"/> class.
        /// </summary>
        /// <param name="firstracApiHelper">The firstrac API helper.</param>
        public HandlingDestinationStore(IFirstracApiHelper firstracApiHelper) : base(firstracApiHelper)
        {
            _firstracApiHelper = firstracApiHelper;
        }


        #endregion


        #region Public Methods
        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IHandlingDestination&gt;&gt;.</returns>
        public async Task<IAPIOperationResult<IEnumerable<IHandlingDestination>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true)
        {
            if (filterBy?.Any() ?? false)
                return await _firstracApiHelper.PostAsync<Dictionary<string, object>, APIOperationResult<IEnumerable<IHandlingDestination>>>($"api/HandlingDestination/filteredBy?activeOnly={activeOnly}&exactMatch={exactMatch}&mutuallyExclusive={mutuallyExclusive}&includeAllNavigationProperties={includeNavigationProperties}", filterBy);
            else
                return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<IHandlingDestination>>>($"api/HandlingDestination?activeOnly={activeOnly}&includeAllNavigationProperties={includeNavigationProperties}");

        }

        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IAssetGroupCusipLink&gt;&gt;.</returns>
        public override async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(Dictionary<string, object>? filterBy, bool exactMatch = false)
        {
            return await _firstracApiHelper.PostAsync<Dictionary<string, object>, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/HandlingDestination/dropdownItems?exactMatch={exactMatch}", filterBy);
        }

        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Save(IHandlingDestination model)
        {
            return await _firstracApiHelper.PostAsync<IHandlingDestination, APIOperationResult<bool>>("api/HandlingDestination", model);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Delete(int id, string deletedBy)
        {
            return await _firstracApiHelper.DeleteAsync<APIOperationResult<bool>>($"api/HandlingDestination/{id}?deletedBy={deletedBy}");
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;IHandlingDestination&gt;.</returns>
        public async Task<IAPIOperationResult<IHandlingDestination>> Get(int id)
        {
            return await _firstracApiHelper.GetAsync<APIOperationResult<IHandlingDestination>>("api/HandlingDestination/{id}", id);
        }

        #endregion
    }
}
