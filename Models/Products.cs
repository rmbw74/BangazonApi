using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonApi.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(55)]
        public string Name { get ; set; }

        [Required]
        [StringLength(255)]
        public string Description { get ; set; }

        [Required]
        public int Price { get ; set; }
        public int Quantity { get ; set; }

        //Defining these foreign key explicitly allows the one-to-many relationship in the customer
        //and productType models with the ICollection definined there in addition to their many-to-many relationship.

        //Foreign Key
        public int ProductTypeId { get ; set; }
        //Navigation Property
        public ProductType ProductType { get ; set; }


        //Foreign Key
        public int SellerId { get ; set; }

        //Navigation Property
        public Customer Customer { get ; set; }

        //Defining One-to-Many relationship using convention 4 definied at
        //http://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx
        public ICollection<ProductOrders> ProductOrders { get; set; }

    }
}