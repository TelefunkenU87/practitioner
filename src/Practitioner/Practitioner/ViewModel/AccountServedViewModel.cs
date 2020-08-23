using Practitioner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractitionerDTO;

namespace Practitioner.ViewModel
{
    public class AccountServedViewModel
    {
        public List<AccountServedDTO> AccountsServed { get; set; }
        public EmployeeDTO Employee { get; set; }
        public CategoryNavViewModel CategoryNav { get; set; }
        public ExperienceTabNavViewModel ExperienceTabNav { get; set; }
        public AccountServedDTO NewAccountServed { get; set; }
    }
}
