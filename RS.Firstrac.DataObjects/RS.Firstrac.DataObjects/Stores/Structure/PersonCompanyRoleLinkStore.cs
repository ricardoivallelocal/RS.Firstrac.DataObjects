// ***********************************************************************
// Assembly         : RS.Firstrac.DataObjects
// Author           : ricardo.fraire
// Created          : 04-21-2023
//
// Last Modified By : ricardo.fraire
// Last Modified On : 04-21-2023
// ***********************************************************************
// <copyright file="PersonCompanyRoleLinkStore.cs" company="RS.Firstrac.DataObjects">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Common.Data.API6.Generic;
using RS.Firstrac.DataObjects.Stores.Admin.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Structure.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Admin
{
    /// <summary>
    /// Class PersonCompanyRoleLinkStore.
    /// Implements the <see cref="IPersonCompanyRoleLinkStore" />
    /// </summary>
    /// <seealso cref="IPersonCompanyRoleLinkStore" />
    public class PersonCompanyRoleLinkStore : StoreBase, IPersonCompanyRoleLinkStore
    {
        #region Private Member Variables

        /// <summary>
        /// The firstrac API helper
        /// </summary>
        private readonly IFirstracApiHelper _firstracApiHelper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonCompanyRoleLinkStore"/> class.
        /// </summary>
        /// <param name="firstracApiHelper">The firstrac API helper.</param>
        public PersonCompanyRoleLinkStore(IFirstracApiHelper firstracApiHelper) : base(firstracApiHelper)
        {
            _firstracApiHelper = firstracApiHelper;
        }


        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IPersonCompanyRoleLink&gt;&gt;.</returns>
        public async Task<IAPIOperationResult<IEnumerable<IPersonCompanyRoleLink>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true)
        {
            if (filterBy?.Any() ?? false)
                return await _firstracApiHelper.PostAsync<Dictionary<string, object>, APIOperationResult<IEnumerable<IPersonCompanyRoleLink>>>($"api/PersonCompanyRoleLink/filteredBy?activeOnly={activeOnly}&exactMatch={exactMatch}&mutuallyExclusive={mutuallyExclusive}&includeAllNavigationProperties={includeNavigationProperties}", filterBy);
            else
                return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<IPersonCompanyRoleLink>>>($"api/PersonCompanyRoleLink?activeOnly={activeOnly}&includeAllNavigationProperties={includeNavigationProperties}");
        }

        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IAssetGroupCusipLink&gt;&gt;.</returns>
        public override async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(Dictionary<string, object>? filterBy, bool exactMatch = false)
        {
            return await _firstracApiHelper.PostAsync<Dictionary<string, object>, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/PersonCompanyRoleLink/dropdownItems?exactMatch={exactMatch}", filterBy);
        }

        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Save(IPersonCompanyRoleLink model)
        {
            return await _firstracApiHelper.PostAsync<IPersonCompanyRoleLink, APIOperationResult<bool>>("api/PersonCompanyRoleLink", model);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Delete(int id, string deletedBy)
        {
            return await _firstracApiHelper.DeleteAsync<APIOperationResult<bool>>($"api/PersonCompanyRoleLink/{id}?deletedBy={deletedBy}");
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;IPersonCompanyRoleLink&gt;.</returns>
        public async Task<IAPIOperationResult<IPersonCompanyRoleLink>> Get(int id)
        {
            return await _firstracApiHelper.GetAsync<APIOperationResult<IPersonCompanyRoleLink>>("api/PersonCompanyRoleLink/{id}", id);
        }

        #endregion
    }
}

