using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonApi.Models
{
    public class ProductOrders
    {
        [Key]
        public int Id { get; set; }


        //Foreign Key
        public int ProductId { get; set; }
        //Navigation Property
        public Products Products { get; set; }


        //Foreign Key
        public int OrderId { get; set; }

        //Navigation Property
        public Orders Orders { get; set; }

    }
}