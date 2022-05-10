using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOAChairmanAssistant.Model
{
    public class MyHouse
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }

        public MyHouse(string country, string city, string district, string street, int house_number)
        {
            Country = country;
            City = city;
            District = district;
            Street = street;
            HouseNumber = house_number;
        }

        public MyHouse()
        {

        }
    }
}
