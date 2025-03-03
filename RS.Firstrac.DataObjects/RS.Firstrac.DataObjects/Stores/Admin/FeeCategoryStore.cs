// ***********************************************************************
// Assembly         : RS.Firstrac.DataObjects
// Author           : ricardo.fraire
// Created          : 04-21-2023
//
// Last Modified By : ricardo.fraire
// Last Modified On : 04-21-2023
// ***********************************************************************
// <copyright file="FeeCategoryStore.cs" company="RS.Firstrac.DataObjects">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using RS.Firstrac.BusinessObjects.Models.Admin.Interfaces;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Admin.Interfaces;
using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Admin
{
    /// <summary>
    /// Class FeeCategoryStore.
    /// Implements the <see cref="IFeeCategoryStore" />
    /// </summary>
    /// <seealso cref="IFeeCategoryStore" />
    public class FeeCategoryStore : StoreBase, IFeeCategoryStore
    {
        #region Private Member Variables

        /// <summary>
        /// The firstrac API helper
        /// </summary>
        private readonly IFirstracApiHelper _firstracApiHelper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FeeCategoryStore"/> class.
        /// </summary>
        /// <param name="firstracApiHelper">The firstrac API helper.</param>
        public FeeCategoryStore(IFirstracApiHelper firstracApiHelper) : base(firstracApiHelper)
        {
            _firstracApiHelper = firstracApiHelper;
        }


        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IFeeCategory&gt;&gt;.</returns>
        public async Task<IAPIOperationResult<IEnumerable<IFeeCategory>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true)
        {
            if (filterBy?.Any() ?? false)
                return await _firstracApiHelper.PostAsync<Dictionary<string, object>, APIOperationResult<IEnumerable<IFeeCategory>>>($"api/FeeCategory/filteredBy?activeOnly={activeOnly}&exactMatch={exactMatch}&mutuallyExclusive={mutuallyExclusive}&includeAllNavigationProperties={includeNavigationProperties}", filterBy);
            else
                return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<IFeeCategory>>>($"api/FeeCategory?activeOnly={activeOnly}&includeAllNavigationProperties={includeNavigationProperties}");
        }

        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IAssetGroupCusipLink&gt;&gt;.</returns>
        public override async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(Dictionary<string, object>? filterBy, bool exactMatch = false)
        {

            return await _firstracApiHelper.PostAsync<Dictionary<string, object>, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/FeeCategory/dropdownItems?exactMatch={exactMatch}", filterBy);
        }
        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Save(IFeeCategory model)
        {
            return await _firstracApiHelper.PostAsync<IFeeCategory, APIOperationResult<bool>>("api/FeeCategory", model);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Delete(int id, string deletedBy)
        {
            return await _firstracApiHelper.DeleteAsync<APIOperationResult<bool>>($"api/FeeCategory/{id}?deletedBy={deletedBy}");
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;IFeeCategory&gt;.</returns>
        public async Task<IAPIOperationResult<IFeeCategory>> Get(int id)
        {
            return await _firstracApiHelper.GetAsync<APIOperationResult<IFeeCategory>>($"api/FeeCategory/{id}");
        }

        /// <summary>
        /// Gets the by product service identifier.
        /// </summary>
        /// <param name="productServiceId">The product service identifier.</param>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IFeeCategory&gt;&gt;.</returns>
        public async Task<IAPIOperationResult<IEnumerable<IFeeCategory>>> GetByProductServiceId(int productServiceId)
        {
            return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<IFeeCategory>>>($"api/feeCategory/productServiceId/{productServiceId}");
        }
        #endregion
    }
}

