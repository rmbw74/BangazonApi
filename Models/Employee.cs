//Author : Chris Miller

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonApi.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required]
        public int IsSupervisor { get; set; }

        //foreign key
        public int DepartmentId { get; set; }
        //navigation property
        public Department Department { get; set; }

        public ICollection<EmployeeTraining> EmployeeTraining { get; set; }
        public ICollection<ComputerEmployee> ComputerEmployee { get; set; }

    }
}