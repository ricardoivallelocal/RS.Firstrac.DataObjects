using RS.Firstrac.BusinessObjects.Models.Admin.Interfaces;

namespace RS.Firstrac.DataObjects.Tests
{
    public interface ITests
    {

        Task<IEnumerable<ILegalEntity>> RunTests();
    }
}
