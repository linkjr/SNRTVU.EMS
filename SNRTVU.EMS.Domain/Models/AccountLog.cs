using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRTVU.EMS.Domain.Models
{
    /// <summary>
    /// 表示账户日志的领域模型。
    /// </summary>
    public class AccountLog : AggregateRoot
    {
        #region Properties

        /// <summary>
        /// 获取或设置操作的账户编号。
        /// </summary>
        public Guid AccountID { get; private set; }

        /// <summary>
        /// 获取或设置日志描述。
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 获取或设置账户的操作类型。
        /// </summary>
        public AccountOpertionTypeOptions OpertionType { get; private set; }

        /// <summary>
        /// 获取或设置账户操作的IP地址。
        /// </summary>
        public string IpAddress { get; private set; }

        /// <summary>
        /// 获取或设置创建日期。
        /// </summary>
        public DateTime CreateDate { get; private set; }

        #endregion


        #region ctor

        protected AccountLog() { }

        public AccountLog(Guid accountID, string description, AccountOpertionTypeOptions opertionType)
        {
            this.AccountID = accountID;
            this.Description = description;
            this.OpertionType = opertionType;
            this.IpAddress = string.Empty;//GetIpAddress();
            this.CreateDate = DateTime.Now;
        }

        #endregion
    }

    /// <summary>
    /// 指定 <c>AccountLog</c> 的操作类型的选项。
    /// </summary>
    public enum AccountOpertionTypeOptions
    {
        /// <summary>
        /// 表示注册操作。
        /// </summary>
        Register = 1,
        /// <summary>
        /// 表示登录操作
        /// </summary>
        Login,
    }
}
