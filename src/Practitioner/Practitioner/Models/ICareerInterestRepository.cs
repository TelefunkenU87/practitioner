using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractitionerDTO;

namespace Practitioner.Models
{
    public interface ICareerInterestRepository
    {
        CareerInterestDTO AddCareerInterest(CareerInterestDTO addCareerInterest);
        int DeleteCareerInterest(int careerInterestId);
        List<CareerInterestDTO> GetCareerInterestByEmployeeId(int employeeId);
        CareerInterestDTO GetCareerInterestById(int careerInterestId);
        CareerInterestDTO UpdateCareerInterest(CareerInterestDTO updatedCareerInterest);
    }
}
