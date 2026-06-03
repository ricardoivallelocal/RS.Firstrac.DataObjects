using RS.Common.Data.API6.Interfaces;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Invoice.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Invoice.Interfaces
{

    /// <summary>
    /// IInvoiceGenerationStore
    /// </summary>
    public interface IInvoiceGenerationStore
    {
        #region Methods

        /// <summary>
        /// Batch
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IAPIOperationResult<IBatchInvoiceResponse>> Batch(IBatchInvoiceRequest request);

        /// <summary>
        /// Single
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IAPIOperationResult<ISingleInvoiceResponse>> Single(ISingleInvoiceRequest request);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IAPIOperationResult<bool>> Void(IVoidInvoiceRequest request);

        /// <summary>
        /// Get batch invoice history, optionally filtering by account number.
        /// </summary>
        /// <returns></returns>
        Task<IAPIOperationResult<IEnumerable<IBatchInvoiceHistoryItem>>> GetBatchInvoiceHistory(string? accountNumber = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchId"></param>
        /// <returns></returns>
        Task<IAPIOperationResult<IBatchInvoiceResponse>> GetBatchDetails(int batchId);
        #endregion
    }
}
