using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Invoice;
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
        /// Initializes a new instance of the <see cref="InvoiceGenerationStore"/> class.
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

        /// <inheritdoc cref="IInvoiceGenerationStore.GetBatchInvoiceHistory(string?)"/>
        public async Task<IAPIOperationResult<IEnumerable<IBatchInvoiceHistoryItem>>> GetBatchInvoiceHistory(string? accountNumber = null)
        {
            return await _firstracApiHelper.GetAsync<APIOperationResult<IEnumerable<BatchInvoiceHistoryItem>>>($"api/invoiceGeneration/batch-invoice-history?accountNumber={accountNumber}");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchId"></param>
        /// <returns></returns>
        public async Task<IAPIOperationResult<IBatchInvoiceResponse>> GetBatchDetails(int batchId)
        {
            return await _firstracApiHelper.GetAsync<APIOperationResult<IBatchInvoiceResponse>>($"api/invoiceGeneration/batchDetails?batchId={batchId}");
        }
        #endregion
    }
}
