using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SNRTVU.EMS.Domain.Events;
using SNRTVU.EMS.Domain.Models;
using SNRTVU.EMS.Domain.Repositories;

namespace SNRTVU.EMS.Domain.EventHandlers
{
    public class UserLoggedLogEventHandler : IDomainEventHandler<UserLoggedEvent>
    {
        private readonly IAccountLogRepository accountLogRepository;

        /// <summary>
        /// 初始化 <c>UserLoggedLogEventHandler</c> 类型的新实例。
        /// </summary>
        /// <param name="accountLogRepository"></param>
        public UserLoggedLogEventHandler(IAccountLogRepository accountLogRepository)
        {
            this.accountLogRepository = accountLogRepository;
        }

        public void Handle(UserLoggedEvent evnt)
        {
            var description = string.Format("{0} 登录系统", evnt.Account);
            var entity = new AccountLog(evnt.Source.ID, description, AccountOpertionTypeOptions.Login);
            this.accountLogRepository.Create(entity);
        }
    }
}
