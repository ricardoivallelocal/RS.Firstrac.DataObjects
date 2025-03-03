using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Admin.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Invoice.Interfaces;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Invoice.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Invoice
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="RS.Firstrac.DataObjects.Stores.Invoice.Interfaces.IInvoiceAccountStore" />
    /// <seealso cref="IInvoiceAccountStore1" />
    public class InvoiceAccountStore : StoreBase, IInvoiceAccountStore
    {
        #region Private Member Variables

        /// <summary>
        /// The firstrac API helper
        /// </summary>
        private readonly IFirstracApiHelper _firstracApiHelper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="invoiceAccountStore"/> class.
        /// </summary>
        /// <param name="firstracApiHelper">The firstrac API helper.</param>
        public InvoiceAccountStore(IFirstracApiHelper firstracApiHelper) : base(firstracApiHelper)
        {
            _firstracApiHelper = firstracApiHelper;
        }


        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;InvoiceAccount&gt;&gt;.</returns>
        public async Task<IAPIOperationResult<IEnumerable<IInvoiceAccount>>> GetAll(bool? activeOnly, Dictionary<string, object>? filterBy = null, bool? exactMatch = true, bool? mutuallyExclusive = false, bool? includeNavigationProperties = true)
        {
            if (filterBy?.Any() ?? false)
                return await _firstracApiHelper.PostAsync<Dictionary<string, object>, APIOperationResult<IEnumerable<InvoiceAccount>>>($"api/invoiceAccount/filteredBy?activeOnly={activeOnly}&exactMatch={exactMatch}&mutuallyExclusive={mutuallyExclusive}&includeAllNavigationProperties={includeNavigationProperties}", filterBy);
            else
                return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<IInvoiceAccount>>>($"api/InvoiceAccount?activeOnly={activeOnly}&includeAllNavigationProperties={includeNavigationProperties}");

        }

        /// <summary>
        /// Retrieves all account numbers that are active
        /// </summary>
        /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IAssetGroupCusipLink&gt;&gt;.</returns>
        public override async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(Dictionary<string, object>? filterBy, bool exactMatch = false)
        {
            return await _firstracApiHelper.PostAsync<Dictionary<string, object>, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/InvoiceAccount/dropdownItems?exactMatch={exactMatch}", filterBy);
        }

        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Save(IInvoiceAccount model)
        {
            return await _firstracApiHelper.PostAsync<IInvoiceAccount, APIOperationResult<bool>>("api/InvoiceAccount", model);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;System.Boolean&gt;.</returns>
        public async Task<IAPIOperationResult<bool>> Delete(int id, string deletedBy)
        {
            return await _firstracApiHelper.DeleteAsync<APIOperationResult<bool>>($"api/InvoiceAccount/{id}?deletedBy={deletedBy}");
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IAPIOperationResult&lt;InvoiceAccount&gt;.</returns>
        public async Task<IAPIOperationResult<IInvoiceAccount>> Get(int id)
        {
            return await _firstracApiHelper.GetAsync<APIOperationResult<IInvoiceAccount>>($"api/InvoiceAccount/{id}");
        }

        /// <summary>
        /// Gets the by fee group account identifier.
        /// </summary>
        /// <param name="feeGroupAccountId">The fee group account identifier.</param>
        /// <returns></returns>
        public async Task<IAPIOperationResult<IEnumerable<IInvoiceAccount>>> GetByFeeGroupAccountId(int feeGroupAccountId)
        {
            return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<IInvoiceAccount>>>($"api/InvoiceAccount/account/{feeGroupAccountId}");
        }
        #endregion
    }
}
