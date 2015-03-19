using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using SNRTVU.EMS.TransferObjects;

namespace SNRTVU.EMS.IApplication
{
    /// <summary>
    /// 提供 <c>User</c> 的服务契约接口。
    /// </summary>
    [ServiceContract]
    public interface IUserService : IApplicationService
    {
        [OperationContract]
        void Login(LoginTransferObject dataObject);

        [OperationContract]
        void ChangePassword(Guid id, string oldPassword, string newPassword);

        void ModifyProfile(Guid id, string account);

        [OperationContract]
        void ModifyContact(ContactTransferObject dataObject);

        [OperationContract]
        AccountTransferObject FindByAccount(string account);
    }
}
