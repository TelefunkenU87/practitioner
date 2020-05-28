using Practitioner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.ViewModel
{
    public class PracticeManagementViewModel
    {
        public List<PracticeManagement> PracticeManagements { get; set; }
        public Employee Employee { get; set; }
        public CategoryNavViewModel CategoryNav { get; set; }
        public ExperienceTabNavViewModel ExperienceTabNav { get; set; }
        public PracticeManagement NewPracticeManagement { get; set; }
    }
}
