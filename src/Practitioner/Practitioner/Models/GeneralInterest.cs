using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.Models
{
    public class GeneralInterest
    {
        public int GeneralInterestId { get; set; }
        public int EmployeeId { get; set; }
        public string Department { get; set; }
        public string Comments { get; set; }
    }
}
