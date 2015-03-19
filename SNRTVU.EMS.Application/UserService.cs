using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SNRTVU.EMS.Domain.Repositories;
using SNRTVU.EMS.IApplication;
using SNRTVU.EMS.Infrastructure.Authentication;
using SNRTVU.EMS.Infrastructure.Exceptions;
using SNRTVU.EMS.TransferObjects;

namespace SNRTVU.EMS.Application
{
    public class UserService : ApplicationService, IUserService
    {
        private IUserRepository repository;

        public UserService(IRepositoryContext context,
            IUserRepository repository)
            : base(context)
        {
            this.repository = repository;
        }

        public void Login(LoginTransferObject dataObject)
        {
            if (dataObject == null)
                throw new ValidationException("dataObject为空。");
            if (string.IsNullOrEmpty(dataObject.Account))
                throw new ValidationException("登录账号不能为空。");
            if (string.IsNullOrEmpty(dataObject.Password))
                throw new ValidationException("登录密码不能为空。");

            var ar = this.repository.FindAll().FirstOrDefault(m => m.Account == dataObject.Account || m.Identification == dataObject.Account);
            if (ar == null)
                throw new ValidationException("登录账号不存在。");
            var password = HashEncrypt.MD5EncryptText(dataObject.Password);
            ar.Login(dataObject.Account, password);
            this.repository.Modify(ar);
            base.Context.Commit();
        }


        public void ChangePassword(Guid id, string oldPassword, string newPassword)
        {
            var ar = this.repository.Find(id);
            if (ar == null)
                throw new ValidationException("用户信息不存在");
            oldPassword = HashEncrypt.MD5EncryptText(oldPassword);
            newPassword = HashEncrypt.MD5EncryptText(newPassword);
            ar.ChangePassword(oldPassword, newPassword);
            this.repository.Modify(ar);
            base.Context.Commit();
        }


        public void ModifyProfile(Guid id, string account)
        {
            var ar = this.repository.Find(id);
            if (ar == null)
                throw new ValidationException("用户信息不存在");
            var list = from m in this.repository.FindAll()
                       where m.ID != id && m.Account == account
                       select m;
            if (list.Any())
                throw new ValidationException("账号已经存在");
            ar.ModifyProfile(account);
            this.repository.Modify(ar);
            base.Context.Commit();
        }


        public void ModifyContact(ContactTransferObject dataObject)
        {
            if (dataObject == null)
                throw new ValidationException("dataObject为空");
            var ar = this.repository.Find(dataObject.ID);
            if (ar == null)
                throw new ValidationException("用户信息不存在");
            ar.ModifyContact(dataObject.Phone, dataObject.Province, dataObject.City, dataObject.District, dataObject.Address, dataObject.IsByPost);
            this.repository.Modify(ar);
            base.Context.Commit();
        }

        public AccountTransferObject FindByAccount(string account)
        {
            var list = from m in this.repository.FindAll()
                       where m.Account == account || m.Identification == account
                       orderby m.CreateDate descending
                       select new AccountTransferObject
                       {
                           ID = m.ID,
                           Account = m.Account,
                           Password = m.Password,
                           Identification = m.Identification,
                           Name = m.Name,
                           Phone = m.Phone,
                           Province = m.Province,
                           City = m.City,
                           District = m.District,
                           Address = m.Address,
                           IsByPost = m.IsByPost,
                           CreateDate = m.CreateDate
                       };
            var dataObject = list.FirstOrDefault();
            return dataObject;
        }
    }
}
