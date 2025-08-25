// ***********************************************************************
// Assembly         : RS.Firstrac.DataObjects
// Author           : ricardo.fraire
// Created          : 04-21-2023
//
// Last Modified By : ricardo.fraire
// Last Modified On : 04-21-2023
// ***********************************************************************
// <copyright file="IStoreBase.cs" company="RS.Firstrac.DataObjects">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Admin.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Interfaces;
using UnifiedTrust.Common.Business.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Interfaces
{
    /// <summary>
    /// Interface IStoreBase
    /// </summary>
    /// <typeparam name="TInterface">The type of the t interface.</typeparam>
    public interface IStoreBase<TInterface>
      where TInterface : IValidate
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
        Task<IAPIOperationResult<TInterface>> Get(int id);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Task&lt;IAPIOperationResult&lt;IEnumerable&lt;TInterface&gt;&gt;&gt;.</returns>
        Task<IAPIOperationResult<IEnumerable<TInterface>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true);
        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;IAPIOperationResult&lt;System.Boolean&gt;&gt;.</returns>
        Task<IAPIOperationResult<bool>> Save(TInterface model);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Task&lt;IAPIOperationResult&lt;IEnumerable&lt;TInterface&gt;&gt;&gt;.</returns>
        Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(Dictionary<string, object>? filterBy, bool exactMatch = false);

        #endregion
    }
}
