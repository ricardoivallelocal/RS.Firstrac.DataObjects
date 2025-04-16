// ***********************************************************************
// Assembly         : RS.Firstrac.DataObjects
// Author           : Michael Quinn
// Created          : 4/11/2025 3:45:56 PM
//
// Last Modified By : Michael Quinn
// Last Modified On : 4/11/2025 3:45:56 PM
// ***********************************************************************
// <copyright file="IPersonStore.cs" company="EdgeCo Holdings, Inc.">
//     Copyright (c) 2025 EdgeCo Holdings, Inc. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Structure.Interfaces;
using RS.Firstrac.DataObjects.Stores.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Structure.Interfaces
{
    public interface IPersonStore : IStoreBase<IPerson>
	{
		/// <summary>
		/// Gets the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Task&lt;IAPIOperationResult&lt;TInterface&gt;&gt;.</returns>
		Task<IAPIOperationResult<IPerson>> Get(int id);
		/// <summary>
		/// Gets all.
		/// </summary>
		/// <returns>Task&lt;IAPIOperationResult&lt;IEnumerable&lt;TInterface&gt;&gt;&gt;.</returns>
		Task<IAPIOperationResult<IEnumerable<IPerson>>> GetAll();
		/// <summary>
		/// Saves the specified model.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns>Task&lt;IAPIOperationResult&lt;System.Boolean&gt;&gt;.</returns>
		Task<IAPIOperationResult<bool>> Save(IPerson model);
	}
}
