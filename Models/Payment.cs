//Author : Chris Miller

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonApi.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AccountNumber { get; set; }

        //foreign key
        public int CustomerId { get; set; }
        //navigation property
        public Customer Customer { get; set; }

        //foreign key
        public int PaymentTypeId { get; set; }
        //navigation property
        public PaymentType PaymentType { get; set; }

        //reference to relationship
        public ICollection<Order> Order { get; set; }

    }
}