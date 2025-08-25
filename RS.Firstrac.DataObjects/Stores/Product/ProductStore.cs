using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Product.Interfaces;
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
        public override async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(Dictionary<string, object>? filterBy, bool exactMatch = false)
        {

            return await _firstracApiHelper.PostAsync<Dictionary<string, object>, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/Product/dropdownItems?exactMatch={exactMatch}", filterBy);
        }

        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IProduct&gt;&gt;.</returns>
        public async Task<IAPIOperationResult<IEnumerable<IProduct>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true)
        {
            if (filterBy?.Any() ?? false)
                return await _firstracApiHelper.PostAsync<Dictionary<string, object>, APIOperationResult<IEnumerable<IProduct>>>($"api/Product/filteredBy?activeOnly={activeOnly}&exactMatch={exactMatch}&mutuallyExclusive={mutuallyExclusive}&includeAllNavigationProperties={includeNavigationProperties}", filterBy);
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
