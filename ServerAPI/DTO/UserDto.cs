using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ServerAPI.Models;

namespace ServerAPI.DTO
{
    public class UserDto
    {
        [Required] public string Name { get; set; }
    }
}
