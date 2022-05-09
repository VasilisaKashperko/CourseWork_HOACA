using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOAChairmanAssistant.Model
{
    public class Owner
    {
        public int OwnerId { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public string AdditionalInfo { get; set; }

        public int CurrentDebt { get; set; }

        public PhoneNumber PhoneNumberId { get; set; }

        public OwnerStatus OwnerStatusId { get; set; }
        public Flat FlatStatusId { get; set; }
    }
}
