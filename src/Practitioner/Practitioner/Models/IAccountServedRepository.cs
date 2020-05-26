﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.Models
{
    public interface IAccountServedRepository
    {
        AccountServed AddAccountServed(AccountServed addAccountServed);
        int DeleteAccountServed(int accountServedId);
        List<AccountServed> GetAccountServedByEmployeeId(int employeeId);
        AccountServed GetAccountServedById(int accountServedId);
        AccountServed UpdateAccountServed(AccountServed updatedAccountServed);
    }
}
