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
        #region ctor

        protected User() { }

        public User(string account, string password, string identification, string phone, string address)
        {
            this.Account = account;
            this.Password = password;
            this.Identification = identification;
            this.Phone = phone;
            this.Address = address;
            this.Disabled = true;
        }

        #endregion

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
        /// 获取或设置姓名。
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 获取或设置联系电话。
        /// </summary>
        public string Phone { get; private set; }

        /// <summary>
        /// 获取或设置QQ号码。
        /// </summary>
        public string QQ { get; private set; }

        /// <summary>
        /// 获取或设置微信账号。
        /// </summary>
        public string Weixin { get; private set; }

        /// <summary>
        /// 获取或设置邮箱账号。
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// 获取或设置所在省份。
        /// </summary>
        public string Province { get; private set; }

        /// <summary>
        /// 获取或设置所在城市。
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// 获取或设置所在区县。
        /// </summary>
        public string District { get; private set; }

        /// <summary>
        /// 获取或设置详细地址。
        /// </summary>
        public string Address { get; private set; }

        /// <summary>
        /// 获取或设置是教材否通过邮寄。
        /// </summary>
        public bool? IsByPost { get; private set; }

        /// <summary>
        /// 获取或设置是否禁用。
        /// </summary>
        public bool Disabled { get; private set; }

        /// <summary>
        /// 获取登录次数。
        /// </summary>
        public int LoginCount { get; private set; }

        /// <summary>
        /// 获取最后一次登录日期。
        /// </summary>
        public DateTime? LastLoginDate { get; private set; }

        /// <summary>
        /// 获取或设置创建日期。
        /// </summary>
        public DateTime CreateDate { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// 登录。
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        public void Login(string account, string password)
        {
            if (this.Account != account && this.Identification != account)
                throw new ValidationException("登录账号不存在。");
            if (this.Password != password)
                throw new ValidationException("登录密码不正确。");
            this.LoginCount += 1;
            this.LastLoginDate = DateTime.Now;

            DomainEvent.Publish(new UserLoggedEvent(this)
            {
                Account = account,
                Password = password
            });
        }

        /// <summary>
        /// 修改密码。
        /// </summary>
        /// <param name="oldPassword">原始密码。</param>
        /// <param name="newPassword">新密码。</param>
        public void ChangePassword(string oldPassword, string newPassword)
        {
            if (oldPassword != this.Password)
            {
                throw new ValidationException("原始密码不正确。");
            }
            this.Password = newPassword;

            DomainEvent.Publish(new PasswordChangedEvent(this)
            {
                OldPassword = oldPassword,
                NewPassword = newPassword
            });
        }

        /// <summary>
        /// 修改个人基本信息。
        /// </summary>
        public void ModifyProfile(string account)
        {
            if (string.IsNullOrEmpty(account))
            {
                throw new ArgumentNullException("account");
            }
            this.Account = account;

            //DomainEvent.Publish(new PasswordChangedEvent(this)
            //{
            //    OldPassword = oldPassword,
            //    NewPassword = newPassword
            //});
        }

        /// <summary>
        /// 修改联系方式。
        /// </summary>
        public void ModifyContact(string phone, string province, string city, string district, string address, bool? isByPost)
        {
            this.Phone = phone;
            this.Province = province;
            this.City = city;
            this.District = district;
            this.Address = address;
            this.IsByPost = isByPost;

            DomainEvent.Publish(new ContactModifiedEvent(this)
            {
                Phone = phone,
                Province = province,
                City = city,
                District = district,
                Address = address,
                IsByPost = isByPost
            });
        }

        /// <summary>
        /// 启用。
        /// </summary>
        public void Enable()
        {
            this.Disabled = false;
        }

        /// <summary>
        /// 禁用。
        /// </summary>
        public void Disable()
        {
            this.Disabled = true;
        }

        #endregion
    }
}
