// ***********************************************************************
// Assembly         : RS.Firstrac.DataObjects
// Author           : ricardo.fraire
// Created          : 04-21-2023
//
// Last Modified By : ricardo.fraire
// Last Modified On : 04-21-2023
// ***********************************************************************
// <copyright file="ILegalEntityTitleStore.cs" company="RS.Firstrac.DataObjects">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using RS.Firstrac.BusinessObjects.Models.Admin.Interfaces;
using RS.Firstrac.DataObjects.Stores.Interfaces;
using RS.Common.Data.API6.Interfaces.Generic;

namespace RS.Firstrac.DataObjects.Stores.Admin.Interfaces
{
    /// <summary>
    /// Interface ILegalEntityTitleStore
    /// Extends the <see cref="RS.Firstrac.DataObjects.Stores.Interfaces.IStoreBase{RS.Firstrac.BusinessObjects.Models.Admin.Interfaces.ILegalEntityTitle}" />
    /// </summary>
    /// <seealso cref="RS.Firstrac.DataObjects.Stores.Interfaces.IStoreBase{RS.Firstrac.BusinessObjects.Models.Admin.Interfaces.ILegalEntityTitle}" />
    public interface ILegalEntityTitleStore : IStoreBase<ILegalEntityTitle>
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
        Task<IAPIOperationResult<ILegalEntityTitle>> Get(int id);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Task&lt;IAPIOperationResult&lt;IEnumerable&lt;TInterface&gt;&gt;&gt;.</returns>
        Task<IAPIOperationResult<IEnumerable<ILegalEntityTitle>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true);
        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;IAPIOperationResult&lt;System.Boolean&gt;&gt;.</returns>
        Task<IAPIOperationResult<bool>> Save(ILegalEntityTitle model);

        #endregion
    }
}
