﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.Models
{
    public class BoardsCommittees
    {
        public int BoardsCommitteesId { get; set; }
        public int EmployeeId { get; set; }
        public string BoardCommittee { get; set; }
        public string Other { get; set; }
        public string Role { get; set; }
        public string Comments { get; set; }

    }
}
