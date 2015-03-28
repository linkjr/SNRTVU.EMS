using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SNRTVU.EMS.Domain.Models;
using SNRTVU.EMS.Domain.Repositories;
using SNRTVU.EMS.Infrastructure.Repositories.EntityFramework;

namespace SNRTVU.EMS.Repository.Security.EntityFramework
{
    public class StudentRepository : EntityFrameworkRepository<Student>, IStudentRepository
    {
        public StudentRepository(IRepositoryContext context)
            : base(context) { }
    }
}
