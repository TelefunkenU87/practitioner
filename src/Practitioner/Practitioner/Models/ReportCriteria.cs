using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.Models
{
    public class ReportCriteria
    {
        public int ReportCriteriaId { get; set; }
        public string Field { get; set; }
        public string Operator { get; set; }
        public string FriendlyWhere { get; set; }
    }
}
