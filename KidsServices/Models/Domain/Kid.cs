using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KidsServices.Models.Domain
{

    public class Kid
    {
        public Kid()
        {
            FirstName = null;
            LastName = null;
            SocialSecurityNumber = null;
            PhoneNumber = null;
        }
        public Kid(string firstname, string lastName, string socialSecurityNumber, string phoneNumber)
        {
            FirstName = firstname;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
            PhoneNumber = phoneNumber;
        }

        

        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        [Key]
        public string SocialSecurityNumber { get; protected set; }
        public string PhoneNumber { get; protected set; }
    }
}