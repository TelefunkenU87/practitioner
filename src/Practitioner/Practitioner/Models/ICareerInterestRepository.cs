using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.Models
{
    public interface ICareerInterestRepository
    {
        CareerInterest AddCareerInterest(CareerInterest addCareerInterest);
        int DeleteCareerInterest(int careerInterestId);
        List<CareerInterest> GetCareerInterestByEmployeeId(int employeeId);
        CareerInterest GetCareerInterestById(int careerInterestId);
        CareerInterest UpdateCareerInterest(CareerInterest updatedCareerInterest);
    }
}
