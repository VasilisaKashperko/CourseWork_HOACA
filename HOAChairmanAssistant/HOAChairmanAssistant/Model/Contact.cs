using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOAChairmanAssistant.Model
{
    public class Contact
    {
        public int ContactId { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public string Position { get; set; }

        public PhoneNumber PhoneNumberId { get; set; }

        public PhoneBook PhoneBookId { get; set; }
    }
}
