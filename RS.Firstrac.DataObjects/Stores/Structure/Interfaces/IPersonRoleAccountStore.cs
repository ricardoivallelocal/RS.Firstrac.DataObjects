using RS.Common.Data.API6.Interfaces.Generic;
using RS.Firstrac.BusinessObjects.Models.Product.Interfaces;
using RS.Firstrac.BusinessObjects.Models.Structure.Interfaces;
using RS.Firstrac.DataObjects.Stores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Firstrac.DataObjects.Stores.Structure.Interfaces
{
	public interface IPersonRoleAccountStore : IStoreBase<IPersonRoleAccount>
	{
		#region Methods

		Task<IAPIOperationResult<IEnumerable<IPersonRoleAccount>>> GetPersonRoleAccounts(int companyId);

		Task<IAPIOperationResult<IEnumerable<IPersonRoleAccount>>> GetCompanyRoleAccounts(int personId);

		Task<IAPIOperationResult<IEnumerable<IPersonRoleAccount>>> GetAccountRoles(int feeGroupAccountId);

		#endregion
	}
}