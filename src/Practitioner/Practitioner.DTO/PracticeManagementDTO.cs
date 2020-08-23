using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractitionerDTO
{
    public class PracticeManagementDTO
    {
        public int PracticeManagementId { get; set; }
        public int EmployeeId { get; set; }
        public string Role { get; set; }
        public string Other { get; set; }
        public string Office { get; set; }
        public string Industry { get; set; }
        public string Sector { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comments { get; set; }
    }
}
