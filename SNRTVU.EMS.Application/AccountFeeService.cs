using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SNRTVU.EMS.Domain.Repositories;
using SNRTVU.EMS.IApplication;
using SNRTVU.EMS.TransferObjects;

namespace SNRTVU.EMS.Application
{
    public class AccountFeeService : ApplicationService, IAccountFeeService
    {
        private readonly IAccountFeeRepository repository;

        public AccountFeeService(IRepositoryContext context,
            IAccountFeeRepository repository)
            : base(context)
        {
            this.repository = repository;
        }

        public IQueryable<AccountFeeTransferObject> GetList(string studentID)
        {
            var list = from m in this.repository.FindAll()
                       where m.StudentID == studentID
                       select new AccountFeeTransferObject
                       {
                           BillingAmount = m.BillingAmount,
                           StudentID = m.StudentID,
                           CreateDate = m.CreateDate
                       };
            return list;
        }
    }
}
