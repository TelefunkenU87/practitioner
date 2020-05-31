using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.Models
{
    public interface IReloInterestRepository
    {
        ReloInterest AddReloInterest(ReloInterest addReloInterest);
        int DeleteReloInterest(int reloInterestId);
        List<ReloInterest> GetReloInterestByEmployeeId(int employeeId);
        ReloInterest GetReloInterestById(int reloInterestId);
        ReloInterest UpdateReloInterest(ReloInterest updatedReloInterest);
    }
}
