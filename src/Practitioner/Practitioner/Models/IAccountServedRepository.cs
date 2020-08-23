using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractitionerDTO;

namespace Practitioner.Models
{
    public interface IAccountServedRepository
    {
        AccountServedDTO AddAccountServed(AccountServedDTO addAccountServed);
        int DeleteAccountServed(int accountServedId);
        List<AccountServedDTO> GetAccountServedByEmployeeId(int employeeId);
        AccountServedDTO GetAccountServedById(int accountServedId);
        AccountServedDTO UpdateAccountServed(AccountServedDTO updatedAccountServed);
    }
}
