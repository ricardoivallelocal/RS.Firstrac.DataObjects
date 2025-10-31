using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Interfaces.Requests;
using RS.Firstrac.BusinessObjects.Models.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Requests;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Lookup.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Lookup.Interfaces;
using RS.Firstrac.DataObjects.Stores.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Lookup
{
    public class FileImportTypeStore : StoreBase, IFileImportTypeStore
    {
        #region Private Member Variables

        /// <summary>
        /// The firstrac API helper
        /// </summary>
        private readonly IFirstracApiHelper _firstracApiHelper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FeeTypeStore"/> class.
        /// </summary>
        /// <param name="firstracApiHelper">The firstrac API helper.</param>
        public FileImportTypeStore(IFirstracApiHelper firstracApiHelper) : base(firstracApiHelper)
        {
            _firstracApiHelper = firstracApiHelper;
        }


        #endregion
        #region Methods
        /// <summary>
        /// Gets the dropdown items for imports.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetDropdownItems(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string, object>? dependencies = null)
        {
            var request = GetForDropdownRequest.Build(filterBy, exactMatch, dependencies);
            return await _firstracApiHelper.PostAsync<IGetForDropdownRequest, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/fileImportType/dropdownItems", request);

        }

        public Task<IAPIOperationResult<bool>> Save(IFeeType model)
        {
            throw new NotImplementedException();
        }

        Task<IAPIOperationResult<IFeeType>> IStoreBase<IFeeType>.Get(int id)
        {
            throw new NotImplementedException();
        }

        Task<IAPIOperationResult<IEnumerable<IFeeType>>> IStoreBase<IFeeType>.GetAll(bool? activeOnly, Dictionary<string, object>? filterBy, bool? exactMatch, bool? mutuallyExclusive, bool? includeNavigationProperties, Dictionary<string, object>? dependencies)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
