// ***********************************************************************
// Assembly         : RS.Firstrac.DataObjects
// Author           : Michael Quinn
// Created          : 4/11/2025 3:05:17 PM
//
// Last Modified By : Michael Quinn
// Last Modified On : 4/11/2025 3:05:17 PM
// ***********************************************************************
// <copyright file="CompanyStore.cs" company="EdgeCo Holdings, Inc.">
//     Copyright (c) 2025 EdgeCo Holdings, Inc. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.Logging;
using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Structure.Interfaces;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Interfaces;
using RS.Firstrac.DataObjects.Stores.Structure.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Structure
{
    /// <summary>
    /// The class purpose is what.
    /// </summary>
    public class CompanyStore : StoreBase, ICompanyStore
	{
		#region Private Member Variables
		/// <summary>
		/// The firstrac API helper
		/// </summary>
		private readonly IFirstracApiHelper _firstracApiHelper;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CompanyStore"/> class.
		/// </summary>
		/// <param name="firstracApiHelper">The firstrac API helper.</param>
		public CompanyStore(IFirstracApiHelper firstracApiHelper) : base(firstracApiHelper)
		{
			_firstracApiHelper = firstracApiHelper;
		}

		public async Task<IAPIOperationResult<IEnumerable<ICompany>>> GetAll()
		{
			return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<ICompany>>>($"api/companies");
		}

		public async Task<IAPIOperationResult<bool>> Save(ICompany model)
		{
			return await _firstracApiHelper.PostAsync<ICompany, APIOperationResult<bool>>("api/company", model);
		}

		public async Task<IAPIOperationResult<ICompany>> Get(int id)
		{
			return await _firstracApiHelper.GetAsync<APIOperationResult<ICompany>>($"api/company/company/{id}");
		}

		Task<IAPIOperationResult<IEnumerable<ICompany>>> IStoreBase<ICompany>.GetAll(bool? activeOnly, Dictionary<string, object>? filterBy, bool? exactMatch, bool? mutuallyExclusive, bool? includeNavigationProperties)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}