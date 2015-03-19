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
    public class PasswordChangedEventHandler : IDomainEventHandler<PasswordChangedEvent>
    {
        private readonly IAccountLogRepository accountLogRepository;

        public PasswordChangedEventHandler(IAccountLogRepository accountLogRepository)
        {
            this.accountLogRepository = accountLogRepository;
        }

        public void Handle(PasswordChangedEvent evnt)
        {
            var description = string.Format("{0} 修改密码", (evnt.Source as User).Account);
            var entity = new AccountLog(evnt.Source.ID, description, AccountOpertionTypeOptions.Login);
            this.accountLogRepository.Create(entity);
        }
    }
}
