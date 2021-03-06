//Author: StormyHares
//Purpose: This model defines the Customer resource in the database
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonApi.Models
{
    public class Customer
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
        [DataType(DataType.Date)]
        public DateTime LastActive { get; set; }

        //Defining One-to-Many relationship using convention 4 definied at
        //http://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx
        public ICollection<Product> Product { get; set; }
    }
}