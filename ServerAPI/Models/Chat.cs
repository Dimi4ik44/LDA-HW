using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAPI.Models
{
    public class Chat
    {
        [Key] public int ChatId { get; set; }
        public string Name { get; set; }
        public int CreatorId { get; set; }

    }
}
