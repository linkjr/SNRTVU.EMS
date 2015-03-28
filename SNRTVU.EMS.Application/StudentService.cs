using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SNRTVU.EMS.Domain.Repositories;
using SNRTVU.EMS.IApplication;
using SNRTVU.EMS.TransferObjects;

namespace SNRTVU.EMS.Application
{
    public class StudentService : ApplicationService, IStudentService
    {
        private readonly IStudentRepository repository;

        public StudentService(IRepositoryContext context,
            IStudentRepository repository)
            : base(context)
        {
            this.repository = repository;
        }

        public IQueryable<StudentTransferObject> FindListByIdentification(string identification)
        {
            var list = from m in this.repository.FindAll().Where(m => m.IDNumber == identification)
                       select new StudentTransferObject
                       {
                           StuID = m.StuID,
                           StuName = m.StuName,
                           ClassID = m.ClassID,
                           IDNumber = m.IDNumber
                       };
            return list;
        }
    }
}
