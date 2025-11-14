// ***********************************************************************
// Assembly         : RS.Firstrac.DataObjects
// Author           : ricardo.fraire
// Created          : 04-21-2023
//
// Last Modified By : ricardo.fraire
// Last Modified On : 04-24-2023
// ***********************************************************************
// <copyright file="IAssetGroupCusipLinkStore.cs" company="RS.Firstrac.DataObjects">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using RS.Firstrac.BusinessObjects.Models.Admin.Interfaces;
using RS.Firstrac.DataObjects.Stores.Interfaces;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.FileImport.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Admin.Interfaces
{
    /// <summary>
    /// Interface IAssetGroupCusipLinkStore
    /// Extends the <see cref="RS.Firstrac.DataObjects.Stores.Interfaces.IStoreBase{RS.Firstrac.BusinessObjects.Models.Admin.Interfaces.IAssetGroupCusipLink}" />
    /// </summary>
    /// <seealso cref="RS.Firstrac.DataObjects.Stores.Interfaces.IStoreBase{RS.Firstrac.BusinessObjects.Models.Admin.Interfaces.IAssetGroupCusipLink}" />
    public interface IImportsStore : IStoreBase<IImportRequestBase>
    {
        #region Methods

        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;IAPIOperationResult&lt;System.Boolean&gt;&gt;.</returns>
        Task<IAPIOperationResult<bool>> Save(IPlanImportRequest model);

        /// <summary>
        /// Gets the service dropdown items for file imports.
        /// </summary>
        /// <param name="filterBy">The filter by.</param>
        /// <param name="exactMatch">if set to <c>true</c> [exact match].</param>
        /// <param name="dependencies">The dependencies.</param>
        /// <returns></returns>
        Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetServiceDropdownItemsForImports(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string, object>? dependencies = null);

        /// <summary>
        /// Gets the fee item dropdown items for file imports.
        /// </summary>
        /// <param name="filterBy">The filter by.</param>
        /// <param name="exactMatch">if set to <c>true</c> [exact match].</param>
        /// <param name="dependencies">The dependencies.</param>
        /// <returns></returns>
        Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetFeeItemDropdownItemsForImports(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string, object>? dependencies = null);

        /// <summary>
        /// Runs the plan import.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<IAPIOperationResult<int?>> RunPlanImport(IPlanImportRequest request);

        /// <summary>
        /// Runs the file import.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<IAPIOperationResult<int?>> RunFileImport(IFileImportRequest request);

        /// <summary>
        /// Runs the file import.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<IAPIOperationResult<ICollection<IFileImportRequestItem>>> ValidateImportFile(IFileImportRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterBy"></param>
        /// <param name="exactMatch"></param>
        /// <param name="dependencies"></param>
        /// <returns></returns>
        Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetFileImportSources(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string, object>? dependencies = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IAPIOperationResult<IEnumerable<IFileImportBatchDropdownItem>>> GetFileImportBatches(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string, object>? dependencies = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchId"></param>
        /// <param name="deletedBy"></param>
        /// <returns></returns>
        Task<IAPIOperationResult<bool>> DeleteBatch(int batchId, string deletedBy);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchId"></param>
        /// <param name="deletedBy"></param>
        /// <returns></returns>
        Task<IAPIOperationResult<bool>> DeleteBatches(int[] batchIds, string deletedBy);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchDetailId"></param>
        /// <param name="deletedBy"></param>
        /// <returns></returns>
        Task<IAPIOperationResult<bool>> DeleteBatchItems(int[] batchDetailIds, string deletedBy);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="importHeaderIds"></param>
        /// <returns></returns>
        Task<IAPIOperationResult<ICollection<IBatchDetailsResponse>>> GetBatchDetails(int[] importHeaderIds);

        #endregion
    }
}
