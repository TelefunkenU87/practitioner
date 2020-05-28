using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.Models
{
    public class AccountServed
    {
        public int AccountServedId { get; set; }
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter Account Name")]
        [Display(Name = "Account")]
        [StringLength(50)]
        public string Account { get; set; }

        [Required(ErrorMessage = "Please enter Client Service")]
        [Display(Name = "Client Service")]
        [StringLength(50)]
        public string ClientService { get; set; }

        [Required(ErrorMessage = "Please enter Industry")]
        [Display(Name = "Industry")]
        [StringLength(50)]
        public string Industry { get; set; }

        [Required(ErrorMessage = "Please enter Sector")]
        [Display(Name = "Sector")]
        [StringLength(50)]
        public string Sector { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
    }
}
