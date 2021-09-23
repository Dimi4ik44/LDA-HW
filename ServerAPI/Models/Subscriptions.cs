using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAPI.Models
{
    public class Subscriptions
    {
        [Key]
        public int SubId { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }
    }
}
