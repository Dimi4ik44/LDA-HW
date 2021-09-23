using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebServer.Controllers;
using System.Text.Json.Serialization;
using WebServer.DTO;

namespace WebServer
{
    public class Chat
    {
        private static int counter = 0;
        [JsonIgnore]
        public bool Delete { get; set; }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int MembersCount { get => Members.Count; }
        public List<INameble> Members { get; set; }
        [JsonIgnore]
        public List<string> Messages { get; set; }
        public Chat()
        {
            Id = counter;
            counter++;
            Members = new List<INameble>();
        }
        public Chat(string name) : this()
        {
            Name = name;
        }
    }
}
