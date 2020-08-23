using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace PractitionerDTO
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Office { get; set; }
        public string PrimaryIndustry { get; set; }
        public string Sector { get; set; }
        public DateTime MandatoryRetirement { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public SqlBoolean DirectAdmit { get; set; }
        public DateTime LastReview { get; set; }
        public SqlBoolean Status { get; set; }
        public DateTime OriginalHireDate { get; set; }
        public int ExperienceCredit { get; set; }

        public string GetFullName()
        {
            return $"{LastName}, {FirstName}";
        }
    }
}
