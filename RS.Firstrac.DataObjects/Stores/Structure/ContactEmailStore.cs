// ***********************************************************************
// Assembly         : RS.Firstrac.DataObjects
// Author           : Michael Quinn
// Created          : 4/11/2025 3:59:07 PM
//
// Last Modified By : Michael Quinn
// Last Modified On : 4/29/2025 3:59:07 PM
// ***********************************************************************
// <copyright file="ContactEmailStore.cs" company="EdgeCo Holdings, Inc.">
//     Copyright (c) 2025 EdgeCo Holdings, Inc. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.Logging;
using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Interfaces.Requests;
using RS.Firstrac.BusinessObjects.Models.Requests;
using RS.Firstrac.BusinessObjects.Models.Structure.Interfaces;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Structure.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Structure
{
    /// <summary>
    /// The class purpose is what.
    /// </summary>
    public class ContactEmailStore : StoreBase, IContractEmailStore
	{
		#region Private Member Variables
		/// <summary>
		/// The firstrac API helper
		/// </summary>
		private readonly IFirstracApiHelper _firstracApiHelper;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="ContactEmailStore"/> class.
		/// </summary>
		/// <param name="firstracApiHelper">The firstrac API helper.</param>
		public ContactEmailStore(IFirstracApiHelper firstracApiHelper) : base(firstracApiHelper)
		{
			_firstracApiHelper = firstracApiHelper;
		}
		#endregion
		#region Public Methods

		/// <summary>
		/// Retrieves all account numbers that are active
		/// </summary>
		/// <returns>IAPIOperationResult&lt;IEnumerable&lt;IContactAddress&gt;&gt;.</returns>
		public async Task<IAPIOperationResult<IEnumerable<IContactEmail>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true, Dictionary<string,object>? dependencies = null)
		{
			if (filterBy?.Any() ?? false)
			{
                var request = GetAllRequest.Build(activeOnly ?? true, filterBy, exactMatch ?? true, mutuallyExclusive ?? false, includeNavigationProperties ?? true, null, false, dependencies);
                return await _firstracApiHelper.PostAsync<IGetAllRequest, APIOperationResult<IEnumerable<IContactEmail>>>($"api/contactemail/filteredBy", request);
               
            }

			else
				return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<IContactEmail>>>($"api/contactemail?activeOnly={activeOnly}&includeAllNavigationProperties={includeNavigationProperties}");

		}

		/// <summary>
		/// Saves the specified model.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
		public async Task<IAPIOperationResult<bool>> Save(IContactEmail model)
		{
			return await _firstracApiHelper.PostAsync<IContactEmail, APIOperationResult<bool>>("api/contactemail", model);
		}

		/// <summary>
		/// Deletes the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
		public async Task<IAPIOperationResult<bool>> Delete(int id, string deletedBy)
		{
			return await _firstracApiHelper.DeleteAsync<APIOperationResult<bool>>($"api/contactemail/{id}?deletedBy={deletedBy}");
		}

		/// <summary>
		/// Gets the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>IAPIOperationResult&lt;IContactAddress&gt;.</returns>
		public async Task<IAPIOperationResult<IContactEmail>> Get(int id)
		{
			return await _firstracApiHelper.GetAsync<APIOperationResult<IContactEmail>>($"api/contactemail/{id}");
		}

		public override async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string,object>? dependencies = null)
		{
            var request = GetForDropdownRequest.Build(filterBy, exactMatch, dependencies);
            return await _firstracApiHelper.PostAsync<IGetForDropdownRequest, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/contactemail/dropdownItems", request);
		}


		#endregion

	}
}