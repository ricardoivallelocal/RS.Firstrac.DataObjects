// ***********************************************************************
// Assembly         : RS.Firstrac.DataObjects
// Author           : ricardo.fraire
// Created          : 04-21-2023
//
// Last Modified By : ricardo.fraire
// Last Modified On : 04-21-2023
// ***********************************************************************
// <copyright file="IWhiteLabelSubGroupStore.cs" company="RS.Firstrac.DataObjects">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using RS.Firstrac.BusinessObjects.Models.Admin.Interfaces;
using RS.Firstrac.DataObjects.Stores.Interfaces;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Admin.Interfaces
{
    /// <summary>
    /// Interface IWhiteLabelSubGroupStore
    /// Extends the <see cref="RS.Firstrac.DataObjects.Stores.Interfaces.IStoreBase{RS.Firstrac.BusinessObjects.Models.Admin.Interfaces.IWhiteLabelSubGroup}" />
    /// </summary>
    /// <seealso cref="RS.Firstrac.DataObjects.Stores.Interfaces.IStoreBase{RS.Firstrac.BusinessObjects.Models.Admin.Interfaces.IWhiteLabelSubGroup}" />
    public interface IWhiteLabelSubGroupStore : IStoreBase<IWhiteLabelSubGroup>
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
        Task<IAPIOperationResult<IWhiteLabelSubGroup>> Get(int id);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Task&lt;IAPIOperationResult&lt;IEnumerable&lt;TInterface&gt;&gt;&gt;.</returns>
        Task<IAPIOperationResult<IEnumerable<IWhiteLabelSubGroup>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true, Dictionary<string,object> dependencies = null);
        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;IAPIOperationResult&lt;System.Boolean&gt;&gt;.</returns>
        Task<IAPIOperationResult<bool>> Save(IWhiteLabelSubGroup model);

        /// <summary>
        /// Gets for dropdown by white label external identifier.
        /// </summary>
        /// <param name="filterBy">The filter by.</param>
        /// <param name="exactMatch">if set to <c>true</c> [exact match].</param>
        /// <param name="dependencies">The dependencies.</param>
        /// <returns></returns>
        Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdownByWhiteLabelExternalId(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string, object> dependencies = null);
        #endregion
    }
}
