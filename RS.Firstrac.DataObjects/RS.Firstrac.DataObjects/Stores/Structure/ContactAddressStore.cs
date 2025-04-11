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
using RS.Firstrac.BusinessObjects.Models.Structure.Interfaces;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Structure.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Structure
{
    /// <summary>
    /// The class purpose is what.
    /// </summary>
    public class ContactAddressStore : IContactAddressStore
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
		public ContactAddressStore(IFirstracApiHelper firstracApiHelper)
		{
			_firstracApiHelper = firstracApiHelper;
		}

		public async Task<IAPIOperationResult<IContactAddress>> Get(int id)
		{
			return await _firstracApiHelper.GetAsync<APIOperationResult<IContactAddress>>($"api/contactaddress/{id}");
		}

		public async Task<IAPIOperationResult<IEnumerable<IContactAddress>>> GetAll()
		{
			return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<IContactAddress>>>($"api/contactaddress/addresses");
		}

		public async Task<IAPIOperationResult<bool>> Save(IContactAddress model)
		{
			return await _firstracApiHelper.PostAsync<IContactAddress, APIOperationResult<bool>>("api/contactaddress", model);
		}

		#endregion
	}
}