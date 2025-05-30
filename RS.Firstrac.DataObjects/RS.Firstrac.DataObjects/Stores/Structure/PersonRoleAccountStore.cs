// ***********************************************************************
// Assembly         : RS.Firstrac.DataObjects
// Author           : Michael Quinn
// Created          : 5/30/2025 10:46:10 AM
//
// Last Modified By : Michael Quinn
// Last Modified On : 5/30/2025 10:46:10 AM
// ***********************************************************************
// <copyright file="PersonRoleAccountStore.cs" company="EdgeCo Holdings, Inc.">
//     Copyright (c) 2025 EdgeCo Holdings, Inc. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.Logging;
using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Structure.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Structure;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Structure.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Structure
{
	/// <summary>
	/// The class purpose is what.
	/// </summary>
	public class PersonRoleAccountStore : IPersonRoleAccountStore
	{
		private readonly IFirstracApiHelper _firstracApiHelper;

		public PersonRoleAccountStore(IFirstracApiHelper firstracApiHelper)
		{
			_firstracApiHelper = firstracApiHelper;
		}

		/// <summary>
		/// Retrieves all person role accounts.
		/// </summary>
		/// <returns>IAPIOperationResult&lt;IEnumerable&lt;IPersonRoleAccount&gt;&gt;.</returns>
		public async Task<IAPIOperationResult<IEnumerable<IPersonRoleAccount>>> GetPersonRoleAccounts(int companyId)
		{
			return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<PersonRoleAccount>>>("api/personroleaccount/GetPersonRoleAccounts/{0}", companyId);
		}

	}
}