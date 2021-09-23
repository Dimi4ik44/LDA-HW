using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        public static List<Chat> Chats { get; set; } = new List<Chat>() { new Chat("asdawd"), new Chat("sdwad") };
        public static List<Chat> AliveChhats { get => Chats.Where(x => x.Delete == false).ToList(); }

        [HttpGet]
        public List<Chat> GetChats()
        {
            return AliveChhats;
        }

        [HttpGet]
        [Route("{id}")]
        public List<Chat> GetChat(int id)
        {
            for (int i = 0; i < Chats.Count; i++)
            {
                if (Chats[i].Id == id) return new List<Chat> { Chats[i] };
            }
            return AliveChhats;
        }
        [HttpPost]
        [Route("create")]
        public List<Chat> CreateChat([FromBody]Chat chat)
        {
            bool reWrite = false;
            if (ModelState.IsValid)
            {
                Chats.ForEach(x => 
                { 
                    if (x.Delete && !reWrite)
                    {
                        x = chat;
                        reWrite = true;                       
                    }
                });
                if(!reWrite) Chats.Add(chat);
                return AliveChhats;
            }
                return new List<Chat>();          
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public List<Chat> DeleteChat(int id)
        {
            for (int i = 0; i < Chats.Count; i++)
            {
                if (!Chats[i].Delete && Chats[i].Id == id) Chats[i].Delete = true;
            }
            return AliveChhats;
        }
    }
}
