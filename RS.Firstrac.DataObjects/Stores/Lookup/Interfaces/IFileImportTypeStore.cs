using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Lookup.Interfaces;
using RS.Firstrac.DataObjects.Stores.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Lookup.Interfaces
{
    public interface IFileImportTypeStore : IStoreBase<IFeeType>
    {
        /// <summary>
        /// Gets the dropdown items for imports.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetDropdownItems(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string, object>? dependencies = null);

    }
}
