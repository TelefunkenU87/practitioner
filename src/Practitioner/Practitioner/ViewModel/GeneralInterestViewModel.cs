using Practitioner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractitionerDTO;

namespace Practitioner.ViewModel
{
    public class GeneralInterestViewModel
    {
        public List<GeneralInterestDTO> GeneralInterests { get; set; }
        public EmployeeDTO Employee { get; set; }
        public CategoryNavViewModel CategoryNav { get; set; }
        public InterestTabNavViewModel InterestTabNav { get; set; }
        public GeneralInterestDTO NewGeneralInterest { get; set; }
    }
}
