using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Interfaces.Requests;
using RS.Firstrac.BusinessObjects.Models.Product;
using RS.Firstrac.BusinessObjects.Models.Product.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Requests;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Structure.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Structure
{
    public class ProductFeeStore : IProductFeeStore
    {
        private readonly IFirstracApiHelper _firstracApiHelper;

        public ProductFeeStore(IFirstracApiHelper firstracApiHelper)
        {
            _firstracApiHelper = firstracApiHelper;
        }

        public async Task<IAPIOperationResult<IEnumerable<IProductFee>>> GetProductFees()
        {
            return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<ProductFee>>>("api/productfee/GetProductFees", null);
        }

        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IAssetGroupCusipLink&gt;&gt;.</returns>
        public async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true, Dictionary<string,object>? dependencies = null)
        {
            var request = GetForDropdownRequest.Build(filterBy, exactMatch ?? false, dependencies);
            return await _firstracApiHelper.PostAsync<IGetForDropdownRequest, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/productfee/dropdownItems", request);
        }

        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IAssetGroupCusipLink&gt;&gt;.</returns>
        public async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string,object>? dependencies = null)
        {
            return await _firstracApiHelper.PostAsync<Dictionary<string, object>, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/productfee/dropdownItems?exactMatch={exactMatch}", filterBy);
        }
    }
}
