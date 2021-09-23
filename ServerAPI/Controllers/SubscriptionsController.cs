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
    public class SubscriptionsController : ControllerBase
    {
        private readonly _DbService Database;
        public SubscriptionsController(_DbService dbservice)
        {
            Database = dbservice;
        }
        [HttpGet]
        public IEnumerable<Subscriptions> GetSubs()
        {
            return Database.Subscriptions.ToList();
        }
        [HttpPost]
        [Route("subscribe")]
        public object Subscribe([FromBody]Subscriptions subs)
        {

                Database.Subscriptions.Add(subs);
                Database.SaveChanges();

            return new { Result = "Ok" };
        }
        [HttpDelete]
        [Route("remove/{chatId}/{userId}")]
        public object Subscribe(int chatId,int userId)
        {
            try
            {
                Database.Subscriptions.Remove(Database.Subscriptions.Where(x => x.ChatId == chatId && x.UserId == userId).FirstOrDefault());
                Database.SaveChanges();
            }
            catch(Exception e)
            {
                return new { Error = e.Message };
            }
            return new { Result = "Ok" };
        }
    }
}
