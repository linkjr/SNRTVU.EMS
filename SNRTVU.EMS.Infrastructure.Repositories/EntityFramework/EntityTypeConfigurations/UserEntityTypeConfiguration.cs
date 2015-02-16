using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SNRTVU.EMS.Domain.Models;

namespace SNRTVU.EMS.Infrastructure.Repositories.EntityFramework.EntityTypeConfigurations
{
    /// <summary>
    /// 初始化 <c>UserEntityTypeConfiguration</c> 类的新实例。
    /// </summary>
    public class UserEntityTypeConfiguration : EntityTypeConfiguration<User>
    {
        /// <summary>
        /// 初始化 <c>UserEntityTypeConfiguration</c> 类的新实例。
        /// </summary>
        public UserEntityTypeConfiguration()
        {
            base.Property(m => m.Account)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();
            base.Property(m => m.Identification)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);
            base.Property(M => M.Password)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
