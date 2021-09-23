using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Models;
using ServerAPI.DbService;
using ServerAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly _DbService Database;
        public ChatController(_DbService dbservice)
        {
            Database = dbservice;
        }
        [HttpGet]
        public IEnumerable<Chat> GetChats()
        {
            List<Chat> chats = new List<Chat>();
            chats = Database.Chats.ToList();
            return chats;
        }
        [HttpGet]
        [Route("{id}")]
        public Chat GetChatById(int id)
        {
            Chat chat = new Chat();
            chat = Database.Chats.Find(id);
            return chat;
        }
        [HttpPost]
        [Route("add")]
        public object AddChat([FromBody] ChatDto data)
        {
            Chat chat = new Chat();
            chat.Name = data.Name;
            chat.CreatorId = data.CreatorId;
            try
            {
                Database.Chats.Add(chat);
                Database.SaveChanges();
            }
            catch (Exception e)
            {
                return new { Result = "Error" };
            }
            return new { Result = "Ok" };
        }
    }
}
