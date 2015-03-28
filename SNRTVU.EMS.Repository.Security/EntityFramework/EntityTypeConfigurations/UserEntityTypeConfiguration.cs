using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SNRTVU.EMS.Domain.Models;

namespace SNRTVU.EMS.Repository.Security.EntityFramework.EntityTypeConfigurations
{
    /// <summary>
    /// 表示对 <c>User</c> 领域模型的实体类型配置。
    /// </summary>
    public class UserEntityTypeConfiguration : EntityTypeConfiguration<User>
    {
        /// <summary>
        /// 初始化 <c>UserEntityTypeConfiguration</c> 类的新实例。
        /// </summary>
        public UserEntityTypeConfiguration()
        {
            base.ToTable("StuUser");

            base.Property(m => m.Account)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);
            base.Property(m => m.Password)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired();
            base.Property(m => m.Identification)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();
            base.Property(m => m.Name)
                .HasMaxLength(10)
                .IsRequired();
            base.Property(m => m.Phone)
                .HasColumnType("VARCHAR")
                .HasMaxLength(11)
                .IsRequired();
            base.Property(m => m.QQ)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);
            base.Property(m => m.Weixin)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);
            base.Property(m => m.Email)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);
            base.Property(m => m.Province)
                .HasMaxLength(20);
            base.Property(m => m.City)
                .HasMaxLength(20);
            base.Property(m => m.District)
                .HasMaxLength(20);
            base.Property(m => m.Address)
                .HasMaxLength(200);
        }
    }
}
