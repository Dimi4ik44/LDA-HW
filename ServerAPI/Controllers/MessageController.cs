using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerAPI.Models;
using ServerAPI.DbService;
using ServerAPI.DTO;

namespace ServerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly _DbService Database;
        public MessageController(_DbService dbservice)
        {
            Database = dbservice;
        }
        [HttpGet]
        public IEnumerable<Message> GetChatMessages()
        {
            return Database.Messages;
        }
        [HttpGet]
        [Route("chat/{id}")]
        public IEnumerable<Message> GetChatMessages(int chatId)
        {
            return Database.Messages.Where(x=>x.ChatId==chatId);
        }
        [HttpGet]
        [Route("user/{id}")]
        public IEnumerable<Message> GetUserMessages(int userId)
        {
            return Database.Messages.Where(x => x.UserId == userId);
        }
        [HttpPost]
        [Route("send")]
        public object SendMessage([FromBody] MessageDto data)
        {
            Message mes = new Message();
            mes.ChatId = data.ChatId;
            mes.Data = data.Data;
            mes.SendDate = DateTime.Now;
            mes.UserId = data.UserId;
            try
            {
                Database.Messages.Add(mes);
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
