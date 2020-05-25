using Practitioner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.ViewModel
{
    public class AccountServedViewModel
    {
        public List<AccountServed> AccountsServed { get; set; }
        public Employee Employee { get; set; }
        public CategoryNavViewModel CategoryNav { get; set; }
    }
}
