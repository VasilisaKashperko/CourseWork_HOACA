using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOAChairmanAssistant.Model
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        public string District { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public int HouseNumber { get; set; }

        public string HousingNumber { get; set; }

        public Address(string country, string city, string district, string street, int houseNumber, string housingNumber)
        {
            Country = country;
            City = city;
            District = district;
            Street = street;
            HouseNumber = houseNumber;
            HousingNumber = housingNumber;
        }
    }
}
