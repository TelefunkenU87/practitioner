using Practitioner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.ViewModel
{
    public class GeneralInterestViewModel
    {
        public List<GeneralInterest> GeneralInterests { get; set; }
        public Employee Employee { get; set; }
        public CategoryNavViewModel CategoryNav { get; set; }
        public InterestTabNavViewModel InterestTabNav { get; set; }
        public GeneralInterest NewGeneralInterest { get; set; }
    }
}
