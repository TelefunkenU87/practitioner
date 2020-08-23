using Practitioner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractitionerDTO;

namespace Practitioner.ViewModel
{
    public class CareerInterestViewModel
    {
        public List<CareerInterestDTO> CareerInterests { get; set; }
        public EmployeeDTO Employee { get; set; }
        public CategoryNavViewModel CategoryNav { get; set; }
        public InterestTabNavViewModel InterestTabNav { get; set; }
        public CareerInterestDTO NewCareerInterest { get; set; }
    }
}
