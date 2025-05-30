using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Product.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Structure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Firstrac.DataObjects.Stores.Structure.Interfaces
{
	public interface IPersonRoleAccountStore
	{
		#region Methods

		Task<IAPIOperationResult<IEnumerable<IPersonRoleAccount>>> GetPersonRoleAccounts(int companyId);

		#endregion
	}
}