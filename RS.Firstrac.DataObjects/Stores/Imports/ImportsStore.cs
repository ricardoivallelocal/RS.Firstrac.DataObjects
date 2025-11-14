// ***********************************************************************
// Assembly         : RS.Firstrac.DataObjects
// Author           : ricardo.fraire
// Created          : 04-21-2023
//
// Last Modified By : ricardo.fraire
// Last Modified On : 04-21-2023
// ***********************************************************************
// <copyright file="AssetGroupCusipLinkStore.cs" company="RS.Firstrac.DataObjects">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.FileImport.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Interfaces.Requests;
using RS.Firstrac.BusinessObjects.Models.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Requests;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Admin.Interfaces;
using RS.Firstrac.DataObjects.Stores.Interfaces;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace RS.Firstrac.DataObjects.Stores.Admin
{
    /// <summary>
    /// Class AssetGroupCusipLinkStore.
    /// Implements the <see cref="IAssetGroupCusipLinkStore" />
    /// </summary>
    /// <seealso cref="IAssetGroupCusipLinkStore" />
    public class ImportsStore : StoreBase, IImportsStore
    {
        #region Private Member Variables

        /// <summary>
        /// The firstrac API helper
        /// </summary>
        private readonly IFirstracApiHelper _firstracApiHelper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetGroupCusipLinkStore"/> class.
        /// </summary>
        /// <param name="firstracApiHelper">The firstrac API helper.</param>
        public ImportsStore(IFirstracApiHelper firstracApiHelper) : base(firstracApiHelper)
        {
            _firstracApiHelper = firstracApiHelper;
        }


        #endregion

        #region Public Methods


        public async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetServiceDropdownItemsForImports(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string, object>? dependencies = null)
        {
            try
            {
                var request = GetForDropdownRequest.Build(filterBy, exactMatch, dependencies);
                return await _firstracApiHelper.PostAsync<IGetForDropdownRequest, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/Imports/serviceDropdownItems", request);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetFeeItemDropdownItemsForImports(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string, object>? dependencies = null)
        {
            var request = GetForDropdownRequest.Build(filterBy, exactMatch, dependencies);
            return await _firstracApiHelper.PostAsync<IGetForDropdownRequest, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/imports/feeItemDropdownItems/", request);

        }

        public async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetFileImportSources(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string, object>? dependencies = null)
        {
            var request = GetForDropdownRequest.Build(filterBy, exactMatch, dependencies);
            return await _firstracApiHelper.PostAsync<IGetForDropdownRequest, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/imports/fileImportSources/", request);

        }
        public async Task<IAPIOperationResult<int?>> RunPlanImport(IPlanImportRequest request)
        {

            return await _firstracApiHelper.PostAsync<IPlanImportRequest, APIOperationResult<int?>>($"api/imports/planImport/", request);

        }

        public async Task<IAPIOperationResult<int?>> RunFileImport(IFileImportRequest request)
        {

            return await _firstracApiHelper.PostAsync<IFileImportRequest, APIOperationResult<int?>>($"api/imports/fileImport/", request);

        }

        /// <summary>
        /// ValidateImportFile
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<IAPIOperationResult<ICollection<IFileImportRequestItem>>> ValidateImportFile(IFileImportRequest request)
        {
            return await _firstracApiHelper.PostAsync<IFileImportRequest, APIOperationResult<ICollection<IFileImportRequestItem>>>($"api/imports/validateImportFile/", request);
        }

        public async Task<IAPIOperationResult<IEnumerable<IFileImportBatchDropdownItem>>> GetFileImportBatches(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string, object>? dependencies = null)
        {
            var request = GetForDropdownRequest.Build(filterBy, exactMatch, dependencies);
            return await _firstracApiHelper.PostAsync<IGetForDropdownRequest, APIOperationResult<IEnumerable<IFileImportBatchDropdownItem>>>($"api/Imports/fileImportBatches", request);
        }

        public async Task<IAPIOperationResult<bool>> DeleteBatch(int batchId, string deletedBy)
        {
            return await _firstracApiHelper.DeleteAsync<APIOperationResult<bool>>($"api/Imports/Batch/{batchId}?deletedBy={deletedBy}");
        }


        public async Task<IAPIOperationResult<bool>> DeleteBatches(int[] batchIds, string deletedBy)
        {
            return await _firstracApiHelper.PostAsync<int[], APIOperationResult<bool>>($"api/Imports/deleteBatches?deletedBy={deletedBy}", batchIds);
        }

        public async Task<IAPIOperationResult<bool>> DeleteBatchItems(int[] batchDetailIds, string deletedBy)
        {
            return await _firstracApiHelper.PostAsync<int[],APIOperationResult<bool>>($"api/Imports/deleteBatchItems?deletedBy={deletedBy}",batchDetailIds);
        }

        Task<IAPIOperationResult<IImportRequestBase>> IStoreBase<IImportRequestBase>.Get(int id)
        {
            throw new NotImplementedException();
        }

        Task<IAPIOperationResult<IEnumerable<IImportRequestBase>>> IStoreBase<IImportRequestBase>.GetAll(bool? activeOnly, Dictionary<string, object>? filterBy, bool? exactMatch, bool? mutuallyExclusive, bool? includeNavigationProperties, Dictionary<string, object>? dependencies)
        {
            throw new NotImplementedException();
        }

        Task<IAPIOperationResult<bool>> IStoreBase<IImportRequestBase>.Save(RS.Firstrac.BusinessObjects.Models.FileImport.Interfaces.IImportRequestBase model) { throw new NotImplementedException(); }

        public Task<IAPIOperationResult<bool>> Save(IPlanImportRequest model)
        {
            throw new NotImplementedException();
        }

        public async Task<IAPIOperationResult<ICollection<IBatchDetailsResponse>>> GetBatchDetails(int[] importHeaderIds)
        {
            return await _firstracApiHelper.PostAsync<int[], APIOperationResult<ICollection<IBatchDetailsResponse>>>($"api/Imports/batchDetails", importHeaderIds);
        }
        #endregion
    }
}

