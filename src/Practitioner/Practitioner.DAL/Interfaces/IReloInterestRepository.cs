using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractitionerDTO;

namespace PractitionerDAL.Interfaces
{
    public interface IReloInterestRepository
    {
        ReloInterestDTO AddReloInterest(ReloInterestDTO addReloInterest);
        int DeleteReloInterest(int reloInterestId);
        List<ReloInterestDTO> GetReloInterestByEmployeeId(int employeeId);
        ReloInterestDTO GetReloInterestById(int reloInterestId);
        ReloInterestDTO UpdateReloInterest(ReloInterestDTO updatedReloInterest);
    }
}
