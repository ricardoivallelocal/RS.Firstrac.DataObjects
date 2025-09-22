using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Interfaces.Requests;
using RS.Firstrac.BusinessObjects.Models.Lookup.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Product.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Requests;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Product.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Product
{
    /// <summary>
    /// Class ProductStore.
    /// Implements the <see cref="IProductStore" />
    /// </summary>
    /// <seealso cref="IProductStore" />
    public class ProductStore : StoreBase, IProductStore
    {
        #region Private Member Variables

        /// <summary>
        /// The firstrac API helper
        /// </summary>
        private readonly IFirstracApiHelper _firstracApiHelper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductStore"/> class.
        /// </summary>
        /// <param name="firstracApiHelper">The firstrac API helper.</param>
        public ProductStore(IFirstracApiHelper firstracApiHelper): base(firstracApiHelper)
        {
            _firstracApiHelper = firstracApiHelper;
        }


        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IAssetGroupCusipLink&gt;&gt;.</returns>
        public override async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string,object>? dependencies = null)
        {
            var request = GetForDropdownRequest.Build(filterBy, exactMatch, dependencies);
            return await _firstracApiHelper.PostAsync<IGetForDropdownRequest, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/Product/dropdownItems", request);
        }

        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IProduct&gt;&gt;.</returns>
        public async Task<IAPIOperationResult<IEnumerable<IProduct>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true, Dictionary<string,object>? dependencies = null)
        {
            if (filterBy?.Any() ?? false)
            {
                var request = GetAllRequest.Build(activeOnly ?? true, filterBy, exactMatch ?? true, mutuallyExclusive ?? false, includeNavigationProperties ?? true, null, false, dependencies);
                return await _firstracApiHelper.PostAsync<IGetAllRequest, APIOperationResult<IEnumerable<IProduct>>>($"api/Product/filteredBy", request);
                 
            }

            else
                return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<IProduct>>>($"api/Product?activeOnly={activeOnly}&includeAllNavigationProperties={includeNavigationProperties}");

        }

        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Save(IProduct model)
        {
            return await _firstracApiHelper.PostAsync<IProduct, APIOperationResult<bool>>("api/Product", model);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Delete(int id, string deletedBy)
        {
            return await _firstracApiHelper.DeleteAsync<APIOperationResult<bool>>($"api/Product/{id}?deletedBy={deletedBy}");
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;IProduct&gt;.</returns>
        public async Task<IAPIOperationResult<IProduct>> Get(int id)
        {
            return await _firstracApiHelper.GetAsync<APIOperationResult<IProduct>>($"api/Product/{id}");
        }

        /// <summary>
        /// Adds from request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<IAPIOperationResult<bool>> AddFromRequest(IProductSaveRequest request)
        {
            return await _firstracApiHelper.PostAsync<IProductSaveRequest, APIOperationResult<bool>>("api/Product/addFromRequest", request);
        }


        #endregion
    }
}
