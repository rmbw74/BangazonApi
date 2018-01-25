//Author: Chase Steely

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonApi.Models
{
    public class ComputerEmployee
    {
        [Key]
        public int Id { get; set; }


        //Foreign Key
        public int ComputerId { get; set; }
        //Navigation Property
        public Computer Computer { get; set; }


        //Foreign Key
        public int EmployeeId { get; set; }

        //Navigation Property
        public Employee Employee { get; set; }

    }
}