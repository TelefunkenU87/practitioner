using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.Models
{
    public interface IPracticeManagementRepository
    {
        PracticeManagement AddPracticeManagement(PracticeManagement addPracticeManagement);
        int DeletePracticeManagement(int practiceManagementId);
        List<PracticeManagement> GetPracticeManagementByEmployeeId(int employeeId);
        PracticeManagement GetPracticeManagementById(int practiceManagementId);
        PracticeManagement UpdatePracticeManagement(PracticeManagement updatedPracticeManagement);
    }
}
