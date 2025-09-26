using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Invoice.Interfaces;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Invoice.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Invoice
{

    /// <summary>
    /// InvoiceGenerationStore
    /// </summary>
    public class InvoiceGenerationStore : IInvoiceGenerationStore
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
        public InvoiceGenerationStore(IFirstracApiHelper firstracApiHelper)
        {
            _firstracApiHelper = firstracApiHelper;
        }


        #endregion
        #region Methods

        /// <summary>
        /// Batch
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IAPIOperationResult<IBatchInvoiceResponse>> Batch(IBatchInvoiceRequest request)
        {
            return await _firstracApiHelper.PostAsync<IBatchInvoiceRequest, APIOperationResult<IBatchInvoiceResponse>>($"api/invoiceGeneration/batch/", request);
        }

        /// <summary>
        /// Single
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IAPIOperationResult<ISingleInvoiceResponse>> Single(ISingleInvoiceRequest request)
        {
            return await _firstracApiHelper.PostAsync<ISingleInvoiceRequest, APIOperationResult<ISingleInvoiceResponse>>($"api/invoiceGeneration/single/", request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IAPIOperationResult<bool>> Void(IVoidInvoiceRequest request)
        {
            return await _firstracApiHelper.PostAsync<IVoidInvoiceRequest, APIOperationResult<bool>>($"api/invoiceGeneration/void/", request);
        }
        #endregion
    }
}
