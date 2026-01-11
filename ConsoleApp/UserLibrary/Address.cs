using System;
using System.Collections.Generic;
using System.Text;

namespace UserLibrary
{
    public struct Address
    {
        public string City { get; }
        public string Street { get; }
        public string HouseNumber { get; }
        public int? ApartmentNumber { get; }

        public Address(string city, string street, string house, int? apt = null)
        {
            City = city;
            Street = street;
            HouseNumber = house;
            ApartmentNumber = apt;
        }

        public override string ToString()
        {

            if (ApartmentNumber.HasValue)
            {
                return $"{City}, {Street} {HouseNumber}, Apt {ApartmentNumber.Value}";
            }
            else
            {
                return $"{City}, {Street} {HouseNumber} (Private House)";
            }
        }

    }
}
