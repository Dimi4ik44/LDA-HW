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
    public class UserController : ControllerBase
    {
        private readonly _DbService Database;
        public UserController(_DbService dbservice)
        {
            Database = dbservice;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            List<User> users = new List<User>();
            users = Database.Users.ToList();
            users.ForEach(xu=> 
            {
                var sub = Database.Subscriptions.Where(c => c.UserId == xu.UserId).ToList();               
                
            });
            return users;
        }

        [HttpGet]
        [Route("{id}")]
        public User GetUsers(int id)
        {
            try
            {
                User u = Database.Users.Find(id);
                var subs = from s in Database.Subscriptions
                           where s.UserId == u.UserId
                           select s;
                return u;
            }
            catch(Exception e)
            {
                return null;
            }

            
        }
        [HttpGet]
        [Route("byname/{name}")]
        public User GetUsers(string name)
        {
            try
            {
                User u = Database.Users.Where(x => x.Name == name).FirstOrDefault();
                var subs = from s in Database.Subscriptions
                           where s.UserId == u.UserId
                           select s;
                return u;
            }
            catch(Exception e)
            {
                return null;
            }                       
        }

        [HttpPost]
        [Route("add")]
        public Object AddUser([FromBody] UserDto u)
        {
            User user = new User();
            user.Name = u.Name;
            try
            {
                Database.Users.Add(user);
                Database.SaveChanges();
            }
            catch(Exception e)
            {
                return new { Result = "Error" };
            }
            return new { Result = "Ok" };
        }
    }
}
