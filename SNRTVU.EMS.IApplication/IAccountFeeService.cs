using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SNRTVU.EMS.TransferObjects;

namespace SNRTVU.EMS.IApplication
{
    public interface IAccountFeeService : IApplicationService
    {
        IQueryable<AccountFeeTransferObject> GetList(string studentID);
    }
}
