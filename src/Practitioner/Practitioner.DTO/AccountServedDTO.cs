using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractitionerDTO
{
    public class AccountServedDTO
    {
        public int AccountServedId { get; set; }
        public int EmployeeId { get; set; }

        public string Account { get; set; }

        public string ClientService { get; set; }

        public string Industry { get; set; }

        public string Sector { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
