//author Ray Medrano
//purpose this model defines the properties on the department resource in the database
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonApi.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [Required]
        public int Budget { get; set; }

        //Defining One-to-Many relationship using convention 4 definied at
        //http://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx
        public ICollection<Employee> Employee { get; set; }
    }
}