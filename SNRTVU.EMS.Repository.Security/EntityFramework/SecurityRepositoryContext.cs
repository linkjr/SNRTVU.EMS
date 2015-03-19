using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SNRTVU.EMS.Infrastructure.Repositories.EntityFramework;

namespace SNRTVU.EMS.Repository.Security.EntityFramework
{
    public class SecurityRepositoryContext : EntityFrameworkRepositoryContext
    {
        private readonly DbContext _context;

        #region Properties

        public override DbContext Context
        {
            get { return this._context; }
        }

        #endregion

        #region ctor

        public SecurityRepositoryContext()
        {
            this._context = new SecurityDbContext();
        }

        #endregion
    }
}
