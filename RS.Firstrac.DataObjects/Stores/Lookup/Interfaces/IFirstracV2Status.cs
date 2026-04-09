using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Lookup.Interfaces;

namespace RS.Firstrac.DataObjects.Stores.Lookup.Interfaces;

public interface IFirstracV2Status
{
	/// <summary>
	/// Communicates with the API that responses with whether Firstrac V2 data is live or not.
	/// </summary>
	/// <returns></returns>
	Task<IAPIOperationResult<IFirstracV2LiveStatus>> IsFirstracV2Live();
}
