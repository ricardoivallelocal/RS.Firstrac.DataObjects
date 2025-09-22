// ***********************************************************************
// Assembly         : RS.Firstrac.DataObjects
// Author           : ricardo.fraire
// Created          : 04-21-2023
//
// Last Modified By : ricardo.fraire
// Last Modified On : 04-21-2023
// ***********************************************************************
// <copyright file="IFeeCategoryStore.cs" company="RS.Firstrac.DataObjects">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Admin.Interfaces;
using RS.Firstrac.DataObjects.Stores.Interfaces;


namespace RS.Firstrac.DataObjects.Stores.Admin.Interfaces
{
    /// <summary>
    /// Interface IFeeCategoryStore
    /// Extends the <see cref="RS.Firstrac.DataObjects.Stores.Interfaces.IStoreBase{RS.Firstrac.BusinessObjects.Models.Admin.Interfaces.IFeeCategory}" />
    /// </summary>
    /// <seealso cref="RS.Firstrac.DataObjects.Stores.Interfaces.IStoreBase{RS.Firstrac.BusinessObjects.Models.Admin.Interfaces.IFeeCategory}" />
    public interface IFeeCategoryStore : IStoreBase<IFeeCategory>
    {
        #region Methods

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
        Task<IAPIOperationResult<IFeeCategory>> Get(int id);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Task&lt;IAPIOperationResult&lt;IEnumerable&lt;TInterface&gt;&gt;&gt;.</returns>
        Task<IAPIOperationResult<IEnumerable<IFeeCategory>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true, Dictionary<string,object>? dependencies = null);
        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;IAPIOperationResult&lt;System.Boolean&gt;&gt;.</returns>
        Task<IAPIOperationResult<bool>> Save(IFeeCategory model);

        /// <summary>
        /// Gets the by product service identifier.
        /// </summary>
        /// <param name="productServiceId">The product service identifier.</param>
        /// <returns>Task&lt;IAPIOperationResult&lt;IEnumerable&lt;IFeeCategory&gt;&gt;&gt;.</returns>
        Task<IAPIOperationResult<IEnumerable<IFeeCategory>>> GetByProductServiceId(int productServiceId);
        
        #endregion
    }
}
