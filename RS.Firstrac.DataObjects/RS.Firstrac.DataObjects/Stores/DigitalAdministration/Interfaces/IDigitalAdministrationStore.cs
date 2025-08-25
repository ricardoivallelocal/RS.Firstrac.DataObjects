using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.DigitalAdministration.Interfaces;
using RS.Firstrac.DataObjects.Stores.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.DigitalAdministration.Interfaces
{
    public interface IDigitalAdministrationStore : IStoreBase<IWhiteLabelPartnerInfo>
    {
        #region Methods

        /// <summary>
        /// Gets the white label partners by client identifier.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns></returns>
        Task<IAPIOperationResult<IEnumerable<IWhiteLabelPartnerInfo>>> GetWhiteLabelPartnersByClientId(Guid clientId);
        #endregion
    }
}
