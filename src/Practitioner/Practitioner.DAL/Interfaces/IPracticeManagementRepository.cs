using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractitionerDTO;

namespace PractitionerDAL.Interfaces
{
    public interface IPracticeManagementRepository
    {
        PracticeManagementDTO AddPracticeManagement(PracticeManagementDTO addPracticeManagement);
        int DeletePracticeManagement(int practiceManagementId);
        List<PracticeManagementDTO> GetPracticeManagementByEmployeeId(int employeeId);
        PracticeManagementDTO GetPracticeManagementById(int practiceManagementId);
        PracticeManagementDTO UpdatePracticeManagement(PracticeManagementDTO updatedPracticeManagement);
    }
}
