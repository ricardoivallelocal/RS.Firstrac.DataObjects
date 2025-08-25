using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Admin.Interfaces;
using RS.Firstrac.BusinessObjects.Models.DigitalAdministration.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Interfaces;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.DigitalAdministration.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.DigitalAdministration
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="RS.Firstrac.DataObjects.Stores.DigitalAdministration.Interfaces.IDigitalAdministrationStore" />
    public class DigitalAdministrationStore : StoreBase, IDigitalAdministrationStore
    {
        #region Private Member Variables

        /// <summary>
        /// The firstrac API helper
        /// </summary>
        private readonly IFirstracApiHelper _firstracApiHelper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WhiteLabelSubGroupStore"/> class.
        /// </summary>
        /// <param name="firstracApiHelper">The firstrac API helper.</param>
        public DigitalAdministrationStore(IFirstracApiHelper firstracApiHelper) : base(firstracApiHelper)
        {
            _firstracApiHelper = firstracApiHelper;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="deletedBy"></param>
        /// <returns>
        /// Task&lt;IAPIOperationResult&lt;System.Boolean&gt;&gt;.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<IAPIOperationResult<bool>> Delete(int id, string deletedBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Task&lt;IAPIOperationResult&lt;TInterface&gt;&gt;.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<IAPIOperationResult<IWhiteLabelPartnerInfo>> Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="activeOnly"></param>
        /// <param name="filterBy"></param>
        /// <param name="exactMatch"></param>
        /// <param name="mutuallyExclusive"></param>
        /// <param name="includeNavigationProperties"></param>
        /// <returns>
        /// Task&lt;IAPIOperationResult&lt;IEnumerable&lt;TInterface&gt;&gt;&gt;.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<IAPIOperationResult<IEnumerable<IWhiteLabelPartnerInfo>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true)
        {
            throw new NotImplementedException();
        }



        #endregion


        #region Public Methods

        /// <summary>
        /// Gets the white label partners by client identifier.
        /// </summary>
        /// <param name="ClientId">The client identifier.</param>
        /// <returns></returns>
        public async Task<IAPIOperationResult<IEnumerable<IWhiteLabelPartnerInfo>>> GetWhiteLabelPartnersByClientId(Guid ClientId)
        {
            return await
                _firstracApiHelper.
                         GetAsync<APIOperationResult<IEnumerable<IWhiteLabelPartnerInfo>>>($"api/DigitalAdministration/getWhiteLabelPartnersByClientId/{ClientId}");
        }

        public Task<IAPIOperationResult<bool>> Save(IWhiteLabelPartnerInfo model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IAssetGroupCusipLink&gt;&gt;.</returns>
        public override async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(Dictionary<string, object>? filterBy, bool exactMatch = false)
        {
            return await _firstracApiHelper.PostAsync<Dictionary<string, object>, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/DigitalAdministration/dropdownItems?exactMatch={exactMatch}", filterBy);
        }
        #endregion
    }
}
