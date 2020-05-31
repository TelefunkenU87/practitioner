using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.Models
{
    public class CareerInterest
    {
        public int CareerInterestId { get; set; }
        public int EmployeeId { get; set; }
        public string Role { get; set; }
        public string Other { get; set; }
        public string Office { get; set; }
        public string Industry { get; set; }
        public string Sector { get; set; }
        public string Comment { get; set; }
    }
}
