using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SNRTVU.EMS.Repository.Security.EntityFramework.EntityTypeConfigurations;

namespace SNRTVU.EMS.Repository.Security.EntityFramework
{
    public class SecurityDbContext : DbContext
    {
        /// <summary>
        /// 初始化 <c>SecurityDbContext</c> 类的新实例。
        /// </summary>
        public SecurityDbContext()
            : base(nameOrConnectionString: "DefaultConnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SecurityDbContext, Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new AccountLogEntityTypeConfiguration());

            //modelBuilder.Configurations.Add(new NewsEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
