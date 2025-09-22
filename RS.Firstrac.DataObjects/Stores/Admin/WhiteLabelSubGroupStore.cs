// ***********************************************************************
// Assembly         : RS.Firstrac.DataObjects
// Author           : ricardo.fraire
// Created          : 04-21-2023
//
// Last Modified By : ricardo.fraire
// Last Modified On : 04-21-2023
// ***********************************************************************
// <copyright file="WhiteLabelSubGroupStore.cs" company="RS.Firstrac.DataObjects">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using RS.Firstrac.BusinessObjects.Models.Admin.Interfaces;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Common.Data.API6.Generic;
using RS.Firstrac.DataObjects.Stores.Admin.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Structure.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Interfaces.Requests;
using RS.Firstrac.BusinessObjects.Models.Requests;

namespace RS.Firstrac.DataObjects.Stores.Admin
{
    /// <summary>
    /// Class WhiteLabelSubGroupStore.
    /// Implements the <see cref="IWhiteLabelSubGroupStore" />
    /// </summary>
    /// <seealso cref="IWhiteLabelSubGroupStore" />
    public class WhiteLabelSubGroupStore : StoreBase, IWhiteLabelSubGroupStore
    {
        #region Private Member Variables

        /// <summary>
        /// The firstrac API helper
        /// </summary>
        private readonly IFirstracApiHelper _firstracApiHelper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WhiteLabelSubGroupStore"/> class.
        /// </summary>
        /// <param name="firstracApiHelper">The firstrac API helper.</param>
        public WhiteLabelSubGroupStore(IFirstracApiHelper firstracApiHelper) : base(firstracApiHelper)
        {
            _firstracApiHelper = firstracApiHelper;
        }


        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IWhiteLabelSubGroup&gt;&gt;.</returns>
        public async Task<IAPIOperationResult<IEnumerable<IWhiteLabelSubGroup>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true, Dictionary<string, object> dependencies = null)
        {
            if (filterBy?.Any() ?? false)
            {
                var request = GetAllRequest.Build(activeOnly ?? true, filterBy, exactMatch ?? true, mutuallyExclusive ?? false, includeNavigationProperties ?? true, null, false, dependencies);
                return await _firstracApiHelper.PostAsync<IGetAllRequest, APIOperationResult<IEnumerable<IWhiteLabelSubGroup>>>($"api/WhiteLabelSubGroup/filteredBy", request);            
            }
           
            else
                return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<IWhiteLabelSubGroup>>>($"api/WhiteLabelSubGroup?activeOnly={activeOnly}&includeAllNavigationProperties={includeNavigationProperties}");
        }

        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IAssetGroupCusipLink&gt;&gt;.</returns>
        public override async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string, object> dependencies = null)
        {
            var request = GetForDropdownRequest.Build(filterBy, exactMatch, dependencies);
            return await _firstracApiHelper.PostAsync<IGetForDropdownRequest, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/WhiteLabelSubGroup/dropdownItems", request);
        }

        /// <summary>
        /// Gets for dropdown by white label external identifier.
        /// </summary>
        /// <param name="filterBy">The filter by.</param>
        /// <param name="exactMatch">if set to <c>true</c> [exact match].</param>
        /// <param name="dependencies">The dependencies.</param>
        /// <returns></returns>
        public async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdownByWhiteLabelExternalId(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string, object> dependencies = null)
        {
            var request = GetForDropdownRequest.Build(filterBy, exactMatch, dependencies);
            return await _firstracApiHelper.PostAsync<IGetForDropdownRequest, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/WhiteLabelSubGroup/dropdownItemsByWhiteLabelExternalId", request);
        }

        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Save(IWhiteLabelSubGroup model)
        {
            return await _firstracApiHelper.PostAsync<IWhiteLabelSubGroup, APIOperationResult<bool>>("api/WhiteLabelSubGroup", model);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Delete(int id, string deletedBy)
        {
            return await _firstracApiHelper.DeleteAsync<APIOperationResult<bool>>($"api/WhiteLabelSubGroup/{id}?deletedBy={deletedBy}");
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;IWhiteLabelSubGroup&gt;.</returns>
        public async Task<IAPIOperationResult<IWhiteLabelSubGroup>> Get(int id)
        {
            return await _firstracApiHelper.GetAsync<APIOperationResult<IWhiteLabelSubGroup>>("api/WhiteLabelSubGroup/{id}", id);
        }

        #endregion
    }
}

