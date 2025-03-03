using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Product.Interfaces;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Product.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.ProductFeeScheduleDefault
{
    /// <summary>
    /// Class ProductFeeScheduleDefaultStore.
    /// Implements the <see cref="IProductFeeScheduleDefaultStore" />
    /// </summary>
    /// <seealso cref="IProductFeeScheduleDefaultStore" />
    public class ProductFeeScheduleDefaultStore : StoreBase, IProductFeeScheduleDefaultStore
    {
        #region Private Member Variables

        /// <summary>
        /// The firstrac API helper
        /// </summary>
        private readonly IFirstracApiHelper _firstracApiHelper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductFeeScheduleDefaultStore"/> class.
        /// </summary>
        /// <param name="firstracApiHelper">The firstrac API helper.</param>
        public ProductFeeScheduleDefaultStore(IFirstracApiHelper firstracApiHelper): base(firstracApiHelper)
        {
            _firstracApiHelper = firstracApiHelper;
        }


        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IProductFeeScheduleDefault&gt;&gt;.</returns>
        public async Task<IAPIOperationResult<IEnumerable<IProductFeeScheduleDefault>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true)
        {
            return await
                _firstracApiHelper.
                    GetAsync<APIOperationResult<IEnumerable<IProductFeeScheduleDefault>>>($"api/ProductFeeScheduleDefault?activeOnly={activeOnly}&includeAllNavigationProperties={includeNavigationProperties}");
        }

        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Save(IProductFeeScheduleDefault model)
        {
            return await _firstracApiHelper.PostAsync<IProductFeeScheduleDefault, APIOperationResult<bool>>("api/ProductFeeScheduleDefault", model);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Delete(int id, string deletedBy)
        {
            return await _firstracApiHelper.DeleteAsync<APIOperationResult<bool>>($"api/ProductFeeScheduleDefault/{id}?deletedBy={deletedBy}");
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;IProductFeeScheduleDefault&gt;.</returns>
        public async Task<IAPIOperationResult<IProductFeeScheduleDefault>> Get(int id)
        {
            return await _firstracApiHelper.GetAsync<APIOperationResult<IProductFeeScheduleDefault>>("api/ProductFeeScheduleDefault/{id}", id);
        }

        #endregion
    }
}
