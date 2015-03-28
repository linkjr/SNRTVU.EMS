using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SNRTVU.EMS.TransferObjects;

namespace SNRTVU.EMS.IApplication
{
    public interface IStudentService
    {
        IQueryable<StudentTransferObject> FindListByIdentification(string identification);
    }
}
