using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.Models
{
    public class RptInterestInRelo
    {
        public int RptReloInterestId { get; set; }
        public int EmployeeId { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string InterestLevel { get; set; }
        public string Timing { get; set; }
        public string Comments { get; set; }
    }
}
