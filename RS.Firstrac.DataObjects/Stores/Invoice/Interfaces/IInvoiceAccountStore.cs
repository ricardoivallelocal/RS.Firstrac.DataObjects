using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Invoice.Interfaces;
using RS.Firstrac.DataObjects.Stores.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Invoice.Interfaces
{

    /// <summary>
    /// IInvoiceAccountStore
    /// </summary>
    /// <seealso cref="RS.Firstrac.DataObjects.Stores.Interfaces.IStoreBase&lt;RS.Firstrac.BusinessObjects.Models.Invoice.Interfaces.IInvoiceAccount&gt;" />
    public interface IInvoiceAccountStore : IStoreBase<IInvoiceAccount>
    {
        #region Methods        
        /// <summary>
        /// Gets the by fee group account identifier.
        /// </summary>
        /// <param name="feeGroupAccountId">The fee group account identifier.</param>
        /// <returns></returns>
        Task<IAPIOperationResult<IEnumerable<IInvoiceAccount>>> GetByFeeGroupAccountId(int feeGroupAccountId);
        #endregion
    }
}
