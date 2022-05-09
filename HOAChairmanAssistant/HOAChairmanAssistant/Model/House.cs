using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOAChairmanAssistant.Model
{
    public class House
    {
        public int HouseId { get; set; }

        public int NumberOfFlats { get; set; }

        public int NumberOfPorches { get; set; }

        public Address AddressId { get; set; }

        public User UserId { get; set; }
    }
}
