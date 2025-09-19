// ***********************************************************************
// Assembly         : RS.Firstrac.DataObjects
// Author           : Michael Quinn
// Created          : 5/27/2025 12:52:05 PM
//
// Last Modified By : Michael Quinn
// Last Modified On : 5/27/2025 12:52:05 PM
// ***********************************************************************
// <copyright file="ContactRoleStore.cs" company="EdgeCo Holdings, Inc.">
//     Copyright (c) 2025 EdgeCo Holdings, Inc. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.Logging;
using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Interfaces.Requests;
using RS.Firstrac.BusinessObjects.Models.Lookup.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Requests;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Lookup.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Lookup
{
	/// <summary>
	/// The class purpose is what.
	/// </summary>
	public class ContactRoleStore : StoreBase, IContactRoleStore
	{
		#region Private Member Variables

		/// <summary>
		/// The firstrac API helper
		/// </summary>
		private readonly IFirstracApiHelper _firstracApiHelper;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="ContactRoleStore"/> class.
		/// </summary>
		/// <param name="firstracApiHelper">The firstrac API helper.</param>
		public ContactRoleStore(IFirstracApiHelper firstracApiHelper) : base(firstracApiHelper)
		{
			_firstracApiHelper = firstracApiHelper;
		}

		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves all contact roles that are active
		/// </summary>
		/// <returns>IAPIOperationResult&lt;IEnumerable&lt;IContactRole&gt;&gt;.</returns>
		public async Task<IAPIOperationResult<IEnumerable<IContactRole>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true, Dictionary<string,object>? dependencies = null)
		{
			if (filterBy?.Any() ?? false)
			{
                var request = GetAllRequest.Build(activeOnly ?? true, filterBy, exactMatch ?? true, mutuallyExclusive ?? false, includeNavigationProperties ?? true, null, false, dependencies);
                return await _firstracApiHelper.PostAsync<IGetAllRequest, APIOperationResult<IEnumerable<IContactRole>>>($"api/contactrole/filteredBy", request);
                
            }
           
			else
				return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<IContactRole>>>($"api/contactrole?activeOnly={activeOnly}&includeAllNavigationProperties={includeNavigationProperties}");


		}

		/// <summary>
		/// Retrieves all contact roles that are active
		/// </summary>
		/// <returns>IAPIOperationResult&lt;IEnumerable&lt;IContactRole&gt;&gt;.</returns>
		public override async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string,object>? dependencies = null)
		{
            var request = GetForDropdownRequest.Build(filterBy, exactMatch, dependencies);
            return await _firstracApiHelper.PostAsync<IGetForDropdownRequest, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/contactrole/dropdownItems", request);
		}


		/// <summary>
		/// Saves the specified model.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
		public async Task<IAPIOperationResult<bool>> Save(IContactRole model)
		{
			return await _firstracApiHelper.PostAsync<IContactRole, APIOperationResult<bool>>("api/contactrole", model);
		}

		/// <summary>
		/// Deletes the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
		public async Task<IAPIOperationResult<bool>> Delete(int id, string deletedBy)
		{
			return await _firstracApiHelper.DeleteAsync<APIOperationResult<bool>>($"api/contactrole/{id}?deletedBy={deletedBy}");
		}

		/// <summary>
		/// Gets the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>IAPIOperationResult&lt;IAccountType&gt;.</returns>
		public async Task<IAPIOperationResult<IContactRole>> Get(int id)
		{
			return await _firstracApiHelper.GetAsync<APIOperationResult<IContactRole>>("api/contactrole/{id}", id);
		}

		#endregion

	}
}
