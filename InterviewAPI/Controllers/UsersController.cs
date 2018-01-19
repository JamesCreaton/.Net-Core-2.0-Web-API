using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InterviewAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

//Includes for Authentication
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace InterviewAPI.Controllers
{
    [Route("api/Users")]
    public class UsersController : Controller
    {
        [Authorize(Policy = "Authorized")]
        [HttpGet]
        //GET api/Users
        public IEnumerable<User> Get()
        {
            using (InterviewAPIDb db = new InterviewAPIDb())
            {

                return db.Users.ToList();
            }
        }

        // GET api/Users/5
        [Authorize(Policy = "Authorized")]
        [HttpGet("{id}")]
        public User Get(int id)
        {
            using (InterviewAPIDb db = new InterviewAPIDb())
            {
                return db.Users.First(t => t.Id == id);
            }
        }

        // POST api/Users
        [HttpPost]
        public void Post([FromBody]JObject value)
        {
            User posted = value.ToObject<User>();
            using (InterviewAPIDb db = new InterviewAPIDb())
            {
                db.Users.Add(posted);
                db.SaveChanges();
            }
        }

        // PUT api/Users
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]JObject value)
        {
            User posted = value.ToObject<User>();
            posted.Id = id; //Ensure an id is attached
            using (InterviewAPIDb db = new InterviewAPIDb())
            {
                db.Users.Update(posted);
                db.SaveChanges();
            }
        }

        // DELETE api/Users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (InterviewAPIDb db = new InterviewAPIDb())
            {
                if (db.Users.Where(t => t.Id == id).Count() > 0)
                {
                    //Check if the element exists
                    db.Users.Remove(db.Users.First(t => t.Id == id));
                    db.SaveChanges();
                }
            }
        }

    }
}
