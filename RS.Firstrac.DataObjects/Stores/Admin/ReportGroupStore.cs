using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Interfaces.Requests;
using RS.Firstrac.BusinessObjects.Models.Requests;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Admin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Firstrac.DataObjects.Stores.Admin
{
    //public class ReportGroupStore : StoreBase, IReportGroupStore
    //{

    //    #region Private Member Variables

    //    /// <summary>
    //    /// The firstrac API helper
    //    /// </summary>
    //    private readonly IFirstracApiHelper _firstracApiHelper;

    //    #endregion

    //    #region Constructors

    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="WhiteLabelSubGroupStore"/> class.
    //    /// </summary>
    //    /// <param name="firstracApiHelper">The firstrac API helper.</param>
    //    public ReportGroupStore(IFirstracApiHelper firstracApiHelper) : base(firstracApiHelper)
    //    {
    //        _firstracApiHelper = firstracApiHelper;
    //    }


    //    #endregion
    //    #region Methods

    //    /// <summary>
    //    /// Retrieves all account numbers that are active
    //    /// </summary>
    //    /// <returns>IAPIOperationResult&lt;IEnumerable&lt;IAssetGroupCusipLink&gt;&gt;.</returns>
    //    public override async Task<IAPIOperationResult<IEnumerable<IDropdownItem>>> GetForDropdown(Dictionary<string, object>? filterBy, bool exactMatch = false, Dictionary<string, object>? dependencies = null)
    //    {
    //        var request = GetForDropdownRequest.Build(filterBy, exactMatch, dependencies);
    //        return await _firstracApiHelper.PostAsync<IGetForDropdownRequest, APIOperationResult<IEnumerable<IDropdownItem>>>($"api/ReportGroup/dropdownItems", request);
    //    }
    //    #endregion
    //}
}
