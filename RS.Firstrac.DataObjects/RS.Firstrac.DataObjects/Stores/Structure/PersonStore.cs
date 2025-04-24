// ***********************************************************************
// Assembly         : RS.Firstrac.DataObjects
// Author           : Michael Quinn
// Created          : 4/11/2025 3:45:56 PM
//
// Last Modified By : Michael Quinn
// Last Modified On : 4/11/2025 3:45:56 PM
// ***********************************************************************
// <copyright file="PersonStore.cs" company="EdgeCo Holdings, Inc.">
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
    public class PersonStore : StoreBase, IPersonStore
	{
		#region Private Member Variables
		/// <summary>
		/// The firstrac API helper
		/// </summary>
		private readonly IFirstracApiHelper _firstracApiHelper;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="PersonStore"/> class.
		/// </summary>
		/// <param name="firstracApiHelper">The firstrac API helper.</param>
		public PersonStore(IFirstracApiHelper firstracApiHelper) : base(firstracApiHelper)
		{
			_firstracApiHelper = firstracApiHelper;
		}

		public async Task<IAPIOperationResult<IPerson>> Get(int id)
		{
			return await _firstracApiHelper.GetAsync<APIOperationResult<IPerson>>($"api/person/{id}");
		}

		public async Task<IAPIOperationResult<IEnumerable<IPerson>>> GetAll()
		{
			return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<IPerson>>>($"api/person/");
		}

		public async Task<IAPIOperationResult<bool>> Save(IPerson model)
		{
			return await _firstracApiHelper.PostAsync<IPerson, APIOperationResult<bool>>("api/person", model);
		}

		Task<IAPIOperationResult<IEnumerable<IPerson>>> IStoreBase<IPerson>.GetAll(bool? activeOnly, Dictionary<string, object>? filterBy, bool? exactMatch, bool? mutuallyExclusive, bool? includeNavigationProperties)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}