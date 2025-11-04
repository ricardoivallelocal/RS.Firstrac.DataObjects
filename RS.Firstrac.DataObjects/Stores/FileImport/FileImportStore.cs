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

namespace RS.Firstrac.DataObjects.Stores.Admin
{
    /// <summary>
    /// Class AssetGroupCusipLinkStore.
    /// Implements the <see cref="IAssetGroupCusipLinkStore" />
    /// </summary>
    /// <seealso cref="IAssetGroupCusipLinkStore" />
    public class FileImportStore : StoreBase, IFileImportStore
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
        public FileImportStore(IFirstracApiHelper firstracApiHelper) : base(firstracApiHelper)
        {
            _firstracApiHelper = firstracApiHelper;
        }


        #endregion

        #region Public Methods
     
        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Save(IPlanImportRequest model)
        {
            return await _firstracApiHelper.PostAsync<IPlanImportRequest, APIOperationResult<bool>>("api/fileImport/plan", model);
        }

        Task<IAPIOperationResult<IPlanImportRequest>> IStoreBase<IPlanImportRequest>.Get(int id)
        {
            throw new NotImplementedException();
        }

        Task<IAPIOperationResult<IEnumerable<IPlanImportRequest>>> IStoreBase<IPlanImportRequest>.GetAll(bool? activeOnly, Dictionary<string, object>? filterBy, bool? exactMatch, bool? mutuallyExclusive, bool? includeNavigationProperties, Dictionary<string, object>? dependencies)
        {
            throw new NotImplementedException();
        }

        public async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetServiceDropdownItemsForFileImports(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string, object>? dependencies = null)
        {
            var request = GetForDropdownRequest.Build(filterBy, exactMatch, dependencies);
            return await _firstracApiHelper.PostAsync<IGetForDropdownRequest, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/fileImport/serviceDropdownItems", request);

        }

        public async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetFeeItemDropdownItemsForFileImports(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string, object>? dependencies = null)
        {
            var request = GetForDropdownRequest.Build(filterBy, exactMatch, dependencies);
            return await _firstracApiHelper.PostAsync<IGetForDropdownRequest, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/fileImport/feeItemDropdownItems", request);

        }

        public async Task<IAPIOperationResult<int?>> RunPlanImport(IPlanImportRequest request)
        {
             
            return await _firstracApiHelper.PostAsync<IPlanImportRequest, APIOperationResult<int?>>($"api/fileImport/planImport", request);

        }
        #endregion
    }
}

