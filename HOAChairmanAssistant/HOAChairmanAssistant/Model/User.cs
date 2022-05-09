using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HOAChairmanAssistant.Model
{
    public class User
    {
        public int UserId { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

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
