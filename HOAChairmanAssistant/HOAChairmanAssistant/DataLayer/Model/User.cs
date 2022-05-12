﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HOAChairmanAssistant.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Name { get; set; }

        public string Patronymic { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public UserRole Role { get; set; }

        public User() { }

        public User(string surname, string name, string patronymic, string login, string password)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Login = login;
            Password = password;
            Role = UserRole.Chairman;
        }
    }
}