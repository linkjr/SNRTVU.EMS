using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SNRTVU.EMS.Infrastructure.Repositories.EntityFramework.EntityTypeConfigurations;

namespace SNRTVU.EMS.Infrastructure.Repositories.EntityFramework
{
    /// <summary>
    /// 表示数据访问上下文类。
    /// </summary>
    public class EMSDbContext : DbContext
    {
        /// <summary>
        /// 初始化 <c>EMSDbContext</c> 类的新实例。
        /// </summary>
        public EMSDbContext()
            : base(nameOrConnectionString: "DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EMSDbContext, Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserEntityTypeConfiguration());
            //modelBuilder.Configurations.Add(new AccountLogEntityTypeConfiguration());

            //modelBuilder.Configurations.Add(new NewsEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
