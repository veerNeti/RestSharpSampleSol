using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharp_Demo.Model
{
    public class Data
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }

        public override string ToString()
        {
            return "\nId:\t" + Id.ToString()
                + "\nEmail:\t" + Email.ToString() ;
        }
    }
}
