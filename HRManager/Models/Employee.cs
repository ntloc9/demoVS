using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRManager.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(30)]
        public string EmployeeName { get; set; }
        [Required]
        [MaxLength(30)]
        public string Address { get; set; }
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }
    }
}