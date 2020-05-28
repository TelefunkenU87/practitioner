using Practitioner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.ViewModel
{
    public class EmployeeDetailViewModel
    {
        public Employee Employee { get; set; }
        public CategoryNavViewModel CategoryNav { get; set; }
    }
}
