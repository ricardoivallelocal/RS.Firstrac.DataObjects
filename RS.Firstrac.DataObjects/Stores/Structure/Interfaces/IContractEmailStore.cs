// ***********************************************************************
// Assembly         : RS.Firstrac.DataObjects
// Author           : Michael Quinn
// Created          : 4/11/2025 3:59:07 PM
//
// Last Modified By : Michael Quinn
// Last Modified On : 4/11/2025 3:59:07 PM
// ***********************************************************************
// <copyright file="IContactEmailStore.cs" company="EdgeCo Holdings, Inc.">
//     Copyright (c) 2025 EdgeCo Holdings, Inc. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Structure.Interfaces;
using RS.Firstrac.DataObjects.Stores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Firstrac.DataObjects.Stores.Structure.Interfaces
{
    public interface IContractEmailStore : IStoreBase<IContactEmail>
	{
		/// <summary>
		/// Deletes the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Task&lt;IAPIOperationResult&lt;System.Boolean&gt;&gt;.</returns>

		Task<IAPIOperationResult<bool>> Delete(int id, string deletedBy);
		/// <summary>
		/// Gets the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Task&lt;IAPIOperationResult&lt;TInterface&gt;&gt;.</returns>

		Task<IAPIOperationResult<IContactEmail>> Get(int id);

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <returns>Task&lt;IAPIOperationResult&lt;IEnumerable&lt;TInterface&gt;&gt;&gt;.</returns>       
		Task<IAPIOperationResult<IEnumerable<IContactEmail>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true);

		/// <summary>
		/// Saves the specified model.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns>Task&lt;IAPIOperationResult&lt;System.Boolean&gt;&gt;.</returns>
		Task<IAPIOperationResult<bool>> Save(IContactEmail model);
	}
}
