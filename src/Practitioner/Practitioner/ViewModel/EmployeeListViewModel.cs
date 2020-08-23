using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractitionerDTO;

namespace Practitioner.Models
{
    public class EmployeeListViewModel
    {
        public IEnumerable<EmployeeDTO> Employees { get; set; }
        public int EmployeePerPage { get; set; }
        public int CurrentPage { get; set; }

        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(Employees.Count() / (double)EmployeePerPage));
        }
        public IEnumerable<EmployeeDTO> PaginatedEmployees()
        {
            int start = (CurrentPage - 1) * EmployeePerPage;
            return Employees.OrderBy(e => e.EmployeeId).Skip(start).Take(EmployeePerPage);
        }
    }
}
