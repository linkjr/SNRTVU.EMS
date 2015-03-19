﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SNRTVU.EMS.Domain.Models;
using SNRTVU.EMS.Domain.Repositories;
using SNRTVU.EMS.Infrastructure.Repositories.EntityFramework;

namespace SNRTVU.EMS.Repository.Security.EntityFramework
{
    public class AccountLogRepository : EntityFrameworkRepository<AccountLog>, IAccountLogRepository
    {
        public AccountLogRepository(IRepositoryContext context)
            : base(context) { }
    }
}
