using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonApi.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Time { get; set; }

        //Defining these foreign key explicitly allows the one-to-many relationship in the customer
        //and productType models with the ICollection definined there in addition to their many-to-many relationship.

        //Foreign Key
        public int CustomerId { get ; set; }
        //Navigation Property
        public Customer Customer { get ; set; }


        //Foreign Key
        public int PaymentTypeId { get ; set; }

        //Navigation Property
        public PaymentType PaymentType { get ; set; }

        //Defining One-to-Many relationship using convention 4 definied at
        //http://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx
        public virtual ICollection<ProductOrder> ProductOrder { get; set; }

    }
}