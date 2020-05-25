using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.Models
{
    public interface IAccountServedRepository
    {
        List<AccountServed> GetAccountServedByEmployeeId(int employeeId);
        AccountServed GetAccountServedById(int accountServedId);
        AccountServed UpdateAccountServed(AccountServed updatedAccountServed);
    }
}
