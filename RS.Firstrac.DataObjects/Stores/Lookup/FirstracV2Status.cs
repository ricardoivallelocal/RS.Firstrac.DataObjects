using RS.Common.Data.API6.Generic;
using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Lookup;
using RS.Firstrac.BusinessObjects.Models.Lookup.Interfaces;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Lookup.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Lookup;

public class FirstracV2Status : IFirstracV2Status
{
	private readonly IFirstracApiHelper _firstracApiHelper;

	public FirstracV2Status(IFirstracApiHelper firstracApiHelper)
	{
		_firstracApiHelper = firstracApiHelper;
	}

	/// <inheritdoc cref="IFirstracV2Status.IsFirstracV2Live"/>
	public async Task<IAPIOperationResult<IFirstracV2LiveStatus>> IsFirstracV2Live()
	{
		return await _firstracApiHelper.GetAsync<APIOperationResult<FirstracV2LiveStatus>>($"api/firstracv2-status/is-live");
	}
}
