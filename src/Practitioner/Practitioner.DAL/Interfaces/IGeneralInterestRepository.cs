using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractitionerDTO;

namespace PractitionerDAL.Interfaces
{
    public interface IGeneralInterestRepository
    {
        GeneralInterestDTO AddGeneralInterest(GeneralInterestDTO addGeneralInterest);
        int DeleteGeneralInterest(int generalInterestId);
        List<GeneralInterestDTO> GetGeneralInterestByEmployeeId(int employeeId);
        GeneralInterestDTO GetGeneralInterestById(int generalInterestId);
        GeneralInterestDTO UpdateGeneralInterest(GeneralInterestDTO updatedGeneralInterest);
    }
}
