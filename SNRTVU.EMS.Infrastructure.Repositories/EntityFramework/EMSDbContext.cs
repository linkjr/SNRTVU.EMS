using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRTVU.EMS.Infrastructure.Repositories.EntityFramework
{
    public class EMSDbContext<TContext> : DbContext
        where TContext : DbContext
    {
        /// <summary>
        /// 初始化 <c>EMSDbContext</c> 类的新实例。
        /// </summary>
        public EMSDbContext()
            : base(nameOrConnectionString: "DefaultConnection")
        {
            Database.SetInitializer<TContext>(null);
        }
    }
}
