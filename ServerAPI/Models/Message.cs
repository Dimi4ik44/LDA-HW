using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAPI.Models
{
    public class Message
    {
       [Key] public int MessageId { get; set; }
        public string Data { get; set; }
        public DateTime SendDate { get; set; }
        public int UserId { get; set; }
        public int ChatId { get; set; }
    }
}
