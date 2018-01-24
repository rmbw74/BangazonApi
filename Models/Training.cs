using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonApi.Models
{
    public class Training
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime End { get; set; }

        //Defining One-to-Many relationship using convention 4 definied at
        //http://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx
        public ICollection<EmployeeTraining> EmployeeTraining { get; set; }
    }
}