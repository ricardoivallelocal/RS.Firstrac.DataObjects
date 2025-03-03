using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Interfaces;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Interfaces;
using UnifiedTrust.Common.Business.Interfaces;

namespace RS.Firstrac.DataObjects.Stores
{
    public abstract class StoreBase : IStoreBase<IValidate>
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
        public StoreBase(IFirstracApiHelper firstracApiHelper)
        {
            _firstracApiHelper = firstracApiHelper;
        }

        #endregion

        #region Methods

        public virtual async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(Dictionary<string, object>? filterBy, bool exactMatch = false)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IAPIOperationResult<bool>> Delete(int id, string deletedBy)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IAPIOperationResult<IValidate>> Get(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IAPIOperationResult<IEnumerable<IValidate>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy, bool? exactMatch, bool? mutuallyExclusive, bool? includeNavigationProperties)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IAPIOperationResult<bool>> Save(IValidate model)
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
