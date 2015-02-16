using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SNRTVU.EMS.Domain.Events;
using SNRTVU.EMS.Infrastructure.Exceptions;

namespace SNRTVU.EMS.Domain.Models
{
    public class User : AggregateRoot
    {
        #region Properties

        /// <summary>
        /// 获取或设置登录账号。
        /// </summary>
        public string Account { get; private set; }

        /// <summary>
        /// 获取或设置登录密码。
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// 获取或设置身份证号码。
        /// </summary>
        public string Identification { get; private set; }

        /// <summary>
        /// 获取或设置登录次数。
        /// </summary>
        public int LoginCount { get; private set; }

        /// <summary>
        /// 获取或设置最后一次登录日期。
        /// </summary>
        public DateTime? LastLoginDate { get; private set; }

        /// <summary>
        /// 获取或设置创建日期。
        /// </summary>
        public DateTime CreateDate { get; private set; }

        #endregion

        #region Methods

        public void Login(string account, string password)
        {
            if (this.Account != account && this.Identification != account)
                throw new ValidationException("登录账号不正确。");
            if (this.Password != password)
                throw new ValidationException("登录密码不正确。");
            this.LoginCount += 1;
            this.LastLoginDate = DateTime.Now;

            DomainEvent.Publish<UserLoggedEvent>(new UserLoggedEvent(this)
            {
                Account = account,
                Password = password
            });
        }

        #endregion
    }
}
