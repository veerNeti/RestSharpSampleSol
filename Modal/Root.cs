using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RestSharp_Demo.Model
{
    public class Support
    {
        public string Url { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return "\nUrl: " + Url.ToString() + "\n Text:" + Text.ToString();
        }
    }
}
