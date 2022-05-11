using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOAChairmanAssistant.Model
{
    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Name { get; set; }

        public string Patronymic { get; set; }

        public string AdditionalInfo { get; set; }

        public int CurrentDebt { get; set; }

        [ForeignKey("PhoneNumberId")]
        public PhoneNumber PhoneNumberId { get; set; }

        [Required]
        public OwnerStatus OwnerStatusId { get; set; }

        [ForeignKey("FlatId")]
        public Flat FlatId { get; set; }
    }
}
