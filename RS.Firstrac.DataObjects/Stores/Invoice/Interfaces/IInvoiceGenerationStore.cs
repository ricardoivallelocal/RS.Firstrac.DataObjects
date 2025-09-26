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
        #endregion
    }
}
