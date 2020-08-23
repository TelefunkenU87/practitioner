using Practitioner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractitionerDTO;

namespace Practitioner.ViewModel
{
    public class ReloInterestViewModel
    {
        public List<ReloInterestDTO> ReloInterests { get; set; }
        public EmployeeDTO Employee { get; set; }
        public CategoryNavViewModel CategoryNav { get; set; }
        public InterestTabNavViewModel InterestTabNav { get; set; }
        public ReloInterestDTO NewReloInterest { get; set; }
    }
}
