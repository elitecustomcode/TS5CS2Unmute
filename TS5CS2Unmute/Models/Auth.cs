using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS5CS2Unmute.Models
{
    public class Auth
    {
        public string type { get; set; }
        public Payload payload { get; set; }
    }

    public class Content
    {
        public string apiKey { get; set; }
    }

    public class Payload
    {
        public string identifier { get; set; }
        public string version { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Content content { get; set; }
    }
}
