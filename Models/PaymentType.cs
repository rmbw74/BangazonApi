//Author: Ray
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonApi.Models
{
    public class PaymentType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(55)]
        public string Description { get ; set; }

        //Defining One-to-Many relationship using convention 4 definied at
        //http://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx
        public ICollection<Payment> Payment { get; set; }

    }
}