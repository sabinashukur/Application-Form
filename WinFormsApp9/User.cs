using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp9
{
    public class User
    {
       
        public User()
        {

        }

        public User(string? name, string? surname, string? fName, string? country, string? city, string? phoneNumber, string birthdate, string? gender)
        {
            Name = name;
            Surname = surname;
            FName = fName;
            Country = country;
            City = city;
            PhoneNumber = phoneNumber;
            Birthdate = birthdate;
            Gender = gender;
        }

        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? FName { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }

        public string? PhoneNumber { get; set; }
        public string Birthdate { get; set; }
        public string? Gender { get; set; }

    }
}
