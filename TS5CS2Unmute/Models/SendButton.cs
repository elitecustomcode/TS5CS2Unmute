using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS5CS2Unmute.Models
{
    public class SendButton
    {
        public string type { get; set; }
        public PayloadSend payload { get; set; }
    }
    public class PayloadSend
    {
        public string button { get; set; }
        public bool state { get; set; }
    }
}
