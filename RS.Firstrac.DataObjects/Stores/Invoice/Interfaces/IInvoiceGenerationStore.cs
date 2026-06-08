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
		/// Get all batch invoice history.
		/// </summary>
		/// <returns></returns>
		Task<IAPIOperationResult<IEnumerable<IBatchInvoiceHistoryItem>>> GetInvoiceHistoryBatch();

		/// <summary>
		/// Get batch invoice history detail by batch id.
		/// </summary>
		/// <returns></returns>
		Task<IAPIOperationResult<IBatchInvoiceHistoryDetail?>> GetBatchInvoiceHistoryDetailByBatchId(int batchId);

		/// <summary>
		/// Get batch invoice history by account number.
		/// </summary>
		/// <param name="accountNumber"></param>
		/// <returns></returns>
		Task<IAPIOperationResult<IEnumerable<IInvoiceHistoryItemOfAccount>>> GetInvoiceHistoryByAccountNumber(string accountNumber);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="batchId"></param>
		/// <returns></returns>
		Task<IAPIOperationResult<IBatchInvoiceResponse>> GetBatchDetails(int batchId);
		#endregion
	}
}
