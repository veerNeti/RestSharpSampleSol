using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharp_Demo.Model
{
    public class UserResponse
    {
        public string name { get; set; }
        public string job { get; set; }
        public int id { get; set; }

        public DateTime createdAt { get; set; }

        public override string ToString()
        {
            return "name:\t" + name.ToString() + " "
                    + "\njob:\t" + job.ToString()
                    + "\nID:\t" + id.ToString()
                    + "\ncreatedAt:\t" + createdAt;
        }
    }


}
