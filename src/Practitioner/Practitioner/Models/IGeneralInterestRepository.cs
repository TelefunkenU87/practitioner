using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.Models
{
    public interface IGeneralInterestRepository
    {
        GeneralInterest AddGeneralInterest(GeneralInterest addGeneralInterest);
        int DeleteGeneralInterest(int generalInterestId);
        List<GeneralInterest> GetGeneralInterestByEmployeeId(int employeeId);
        GeneralInterest GetGeneralInterestById(int generalInterestId);
        GeneralInterest UpdateGeneralInterest(GeneralInterest updatedGeneralInterest);
    }
}
