using RS.Firstrac.BusinessObjects.Models.Admin.Interfaces;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Admin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Firstrac.DataObjects.Tests
{
    public class Tests : ITests
    {
        private IFirstracApiHelper _helper;
        private ILegalEntityStore _store;
        public Tests(IFirstracApiHelper helper, ILegalEntityStore store)
        {
            _helper = helper;
            _store = store;
        }

        public async Task<IEnumerable<ILegalEntity>> RunTests()
        {
            try
            {
                var legalEntities = await _store.GetAll(false, null);
                return legalEntities?.Result ?? default;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
