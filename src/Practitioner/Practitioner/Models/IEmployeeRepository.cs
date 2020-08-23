using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractitionerDTO;

namespace Practitioner.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeDTO> GetEmployees();
        EmployeeDTO GetEmployeeById(int employeeId);
    }
}
