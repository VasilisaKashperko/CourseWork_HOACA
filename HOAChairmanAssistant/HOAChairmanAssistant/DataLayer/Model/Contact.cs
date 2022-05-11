using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOAChairmanAssistant.Model
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        [Required]
        public string Position { get; set; }

        [ForeignKey("PhoneNumberId")]
        public PhoneNumber PhoneNumberId { get; set; }

        [ForeignKey("PhoneBookId")]
        public PhoneBook PhoneBookId { get; set; }
    }
}
