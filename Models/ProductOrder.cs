//Author: StormyHares
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonApi.Models
{
    public class ProductOrder
    {
        [Key]
        public int Id { get; set; }


        //Foreign Key
        public int ProductId { get; set; }
        //Navigation Property
        public Product Product { get; set; }


        //Foreign Key
        public int OrdersId { get; set; }

        //Navigation Property
        public Orders Orders { get; set; }

    }
}