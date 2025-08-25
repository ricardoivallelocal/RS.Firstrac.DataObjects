// ***********************************************************************
// Assembly         : RS.Firstrac.DataObjects
// Author           : ricardo.fraire
// Created          : 04-21-2023
//
// Last Modified By : ricardo.fraire
// Last Modified On : 04-21-2023
// ***********************************************************************
// <copyright file="ProductServiceStore.cs" company="RS.Firstrac.DataObjects">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using RS.Firstrac.BusinessObjects.Models.Admin.Interfaces;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Common.Data.API6.Generic;
using RS.Firstrac.DataObjects.Stores.Admin.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Admin
{
    /// <summary>
    /// Class ProductServiceStore.
    /// Implements the <see cref="IProductServiceStore" />
    /// </summary>
    /// <seealso cref="IProductServiceStore" />
    public class ProductServiceStore : StoreBase, IProductServiceStore
    {
        #region Private Member Variables

        /// <summary>
        /// The firstrac API helper
        /// </summary>
        private readonly IFirstracApiHelper _firstracApiHelper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductServiceStore"/> class.
        /// </summary>
        /// <param name="firstracApiHelper">The firstrac API helper.</param>
        public ProductServiceStore(IFirstracApiHelper firstracApiHelper) : base(firstracApiHelper)
        {
            _firstracApiHelper = firstracApiHelper;
        }


        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IProductService&gt;&gt;.</returns>
        public async Task<IAPIOperationResult<IEnumerable<IProductService>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true)
        {
            if (filterBy?.Any() ?? false)
                return await _firstracApiHelper.PostAsync<Dictionary<string, object>, APIOperationResult<IEnumerable<IProductService>>>($"api/ProductService/filteredBy?activeOnly={activeOnly}&exactMatch={exactMatch}&mutuallyExclusive={mutuallyExclusive}&includeAllNavigationProperties={includeNavigationProperties}", filterBy);
            else
                return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<IProductService>>>($"api/ProductService?activeOnly={activeOnly}&includeAllNavigationProperties={includeNavigationProperties}");
        }

        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IAssetGroupCusipLink&gt;&gt;.</returns>
        public override async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(Dictionary<string, object>? filterBy, bool exactMatch = false)
        {
            return await _firstracApiHelper.PostAsync<Dictionary<string, object>, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/ProductService/dropdownItems?exactMatch={exactMatch}", filterBy);
        }

        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Save(IProductService model)
        {
            return await _firstracApiHelper.PostAsync<IProductService, APIOperationResult<bool>>("api/ProductService", model);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Delete(int id, string deletedBy)
        {
            return await _firstracApiHelper.DeleteAsync<APIOperationResult<bool>>($"api/ProductService/{id}?deletedBy={deletedBy}");
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;IProductService&gt;.</returns>
        public async Task<IAPIOperationResult<IProductService>> Get(int id)
        {
            return await _firstracApiHelper.GetAsync<APIOperationResult<IProductService>>("api/ProductService/{id}", id);
        }

        #endregion
    }
}

