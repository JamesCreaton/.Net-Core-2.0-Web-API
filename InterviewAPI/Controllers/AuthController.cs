using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

//Includes for authorization
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

//Helpers classes
using InterviewAPI.Helpers;
using InterviewAPI.Models.Token;

namespace InterviewAPI.Controllers
{
    [Route("api/Token")]
    public class AuthController : Controller
    {
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Create([FromBody]Token token)
        {
            //TODO: Create another acccount database so there can be accounts stored for logging in and out
            //if (token.Username != "james" && token.Password != "baph")
            //    return Unauthorized();

            var newToken = new JwtTokenBuilder()
                .AddSecurityKey(JwtSecurityKey.Create("thisisasecretkey"))
                .AddSubject("james baph")
                .AddIssuer("James.API.Authentication")
                .AddAudience("James.API.Authentication")
                .AddClaim("UserID", "001")
                .AddExpiry(1)
                .Build();

            return Ok(newToken.Value);
        }
    }
}