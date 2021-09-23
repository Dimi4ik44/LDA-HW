using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.DTO;

namespace WebServer
{
    public class Message
    {
        public INameble Sender { get; set; }
        public string Body { get; set; }
        public DateTime SendDate { get; set; }
    }
}
