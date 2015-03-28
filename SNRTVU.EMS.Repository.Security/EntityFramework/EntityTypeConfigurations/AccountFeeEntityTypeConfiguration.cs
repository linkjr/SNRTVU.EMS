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
    /// 表示对 <c>AccountFee</c> 领域模型的实体类型配置。
    /// </summary>
    public class AccountFeeEntityTypeConfiguration : EntityTypeConfiguration<AccountFee>
    {
        /// <summary>
        /// 初始化 <c>AccountFeeEntityTypeConfiguration</c> 类的新实例。
        /// </summary>
        public AccountFeeEntityTypeConfiguration()
        {
            base.Property(m => m.StudentID)
                .HasColumnName("StuID");
            base.Property(m => m.CreateDate)
                .HasColumnName("FeeTime");
        }
    }
}
