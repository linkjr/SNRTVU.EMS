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
    public class StudentEntityTypeConfiguration : EntityTypeConfiguration<Student>
    {
        /// <summary>
        /// 初始化 <c>StudentEntityTypeConfiguration</c> 类的新实例。
        /// </summary>
        public StudentEntityTypeConfiguration()
        {
            base.ToTable("Student");

            base.Property(m => m.StuID)
                .HasColumnType("VARCHAR")
                .HasMaxLength(32)
                .IsRequired();
            base.Property(m => m.StuName)
                .HasMaxLength(10)
                .IsRequired();
            base.Property(m => m.ClassID)
                .HasColumnType("VARCHAR")
                .HasMaxLength(32)
                .IsRequired();
            base.Property(m => m.IDNumber)
                .HasColumnType("VARCHAR")
                .HasMaxLength(18)
                .IsRequired();
        }
    }
}
