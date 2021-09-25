using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAPI.DTO
{
    public class SubscriptionDto
    {
        [Required] public int ChatId { get; set; }
        [Required ]public int UserId { get; set; }
    }
}
