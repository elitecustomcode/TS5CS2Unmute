using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS5CS2Unmute.Models
{
    public class AuthResponse
    {
        public PayloadResponse payload { get; set; }
        public Status status { get; set; }
        public string type { get; set; }
    }

    public class Status
    {
        public int code { get; set; }
        public string message { get; set; }
    }
    public class PayloadResponse
    {
        public string apiKey { get; set; }
        public List<object> connections { get; set; }
        public int currentConnectionId { get; set; }
        public int connectionId { get; set; }
        public string flag { get; set; }
        public bool? newValue { get; set; }
        public bool? oldValue { get; set; }
    }
}
