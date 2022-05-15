﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOAChairmanAssistant.Model
{
    public class House
    {
        [Key]
        public int HouseId { get; set; }

        [Required]
        public int NumberOfFlats { get; set; }

        [Required]
        public int NumberOfPorches { get; set; }

        [Required]
        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }

        [Required]
        public User UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
