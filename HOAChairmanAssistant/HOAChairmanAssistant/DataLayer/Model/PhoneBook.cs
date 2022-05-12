﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOAChairmanAssistant.Model
{
    public class PhoneBook
    {
        [Key]
        public int PhoneBookId { get; set; }
        
        [ForeignKey("UserId")]
        public User UserId { get; set; }
    }
}