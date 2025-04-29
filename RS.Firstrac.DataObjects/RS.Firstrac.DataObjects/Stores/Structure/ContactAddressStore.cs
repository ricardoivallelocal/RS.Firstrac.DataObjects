// ***********************************************************************
// Assembly         : RS.Firstrac.DataObjects
// Author           : Michael Quinn
// Created          : 4/11/2025 3:54:54 PM
//
// Last Modified By : Michael Quinn
// Last Modified On : 4/11/2025 3:54:54 PM
// ***********************************************************************
// <copyright file="ContactAddressStore.cs" company="EdgeCo Holdings, Inc.">
//     Copyright (c) 2025 EdgeCo Holdings, Inc. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.Logging;
using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Structure.Interfaces;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Structure.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Structure
{
    /// <summary>
    /// The class purpose is what.
    /// </summary>
    public class ContactAddressStore : StoreBase, IContactAddressStore
	{
		#region Private Member Variables
		/// <summary>
		/// The firstrac API helper
		/// </summary>
		private readonly IFirstracApiHelper _firstracApiHelper;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="ContactAddressStore"/> class.
		/// </summary>
		/// <param name="firstracApiHelper">The firstrac API helper.</param>
		public ContactAddressStore(IFirstracApiHelper firstracApiHelper) : base(firstracApiHelper)
		{
			_firstracApiHelper = firstracApiHelper;
		}
		#endregion
		#region Public Methods

		/// <summary>
		/// Retrieves all account numbers that are active
		/// </summary>
		/// <returns>IAPIOperationResult&lt;IEnumerable&lt;IContactAddress&gt;&gt;.</returns>
		public async Task<IAPIOperationResult<IEnumerable<IContactAddress>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true)
		{
			if (filterBy?.Any() ?? false)
				return await _firstracApiHelper.PostAsync<Dictionary<string, object>, APIOperationResult<IEnumerable<IContactAddress>>>($"api/contactaddress/filteredBy?activeOnly={activeOnly}&exactMatch={exactMatch}&mutuallyExclusive={mutuallyExclusive}&includeAllNavigationProperties={includeNavigationProperties}", filterBy);
			else
				return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<IContactAddress>>>($"api/contactaddress?activeOnly={activeOnly}&includeAllNavigationProperties={includeNavigationProperties}");

		}

		/// <summary>
		/// Saves the specified model.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
		public async Task<IAPIOperationResult<bool>> Save(IContactAddress model)
		{
			return await _firstracApiHelper.PostAsync<IContactAddress, APIOperationResult<bool>>("api/contactaddress", model);
		}

		/// <summary>
		/// Deletes the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
		public async Task<IAPIOperationResult<bool>> Delete(int id, string deletedBy)
		{
			return await _firstracApiHelper.DeleteAsync<APIOperationResult<bool>>($"api/contactaddress/{id}?deletedBy={deletedBy}");
		}

		/// <summary>
		/// Gets the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>IAPIOperationResult&lt;IContactAddress&gt;.</returns>
		public async Task<IAPIOperationResult<IContactAddress>> Get(int id)
		{
			return await _firstracApiHelper.GetAsync<APIOperationResult<IContactAddress>>($"api/contactaddress/{id}");
		}

		public override async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(Dictionary<string, object>? filterBy, bool exactMatch = false)
		{

			return await _firstracApiHelper.PostAsync<Dictionary<string, object>, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/contactaddress/dropdownItems?exactMatch={exactMatch}", filterBy);
		}


		#endregion
	}
}