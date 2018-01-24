//Author: Max Wolf
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonApi.Models
{
    public class EmployeeTraining
    {
        [Key]
        public int Id { get; set; }


        //Foreign Key
        public int EmployeeId { get; set; }
        //Navigation Property
        public Employee Employee { get; set; }


        //Foreign Key
        public int TrainingId { get; set; }

        //Navigation Property
        public Training Training { get; set; }

    }
}