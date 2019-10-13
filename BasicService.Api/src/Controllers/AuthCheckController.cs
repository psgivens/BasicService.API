﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasicService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthCheckController : ControllerBase
    {
        public AuthCheckController(){
            TlsHack.Hack();
        }

        private bool IsAuthorized() {
            var headers = this.Request.Headers;            
            var userIdString = headers["user_id"];
            var transactionIdString = headers["transaction_id"];
            Guid userId, transactionId;

            Console.WriteLine($"User Id: {userIdString}");
            Console.WriteLine($"Transaction Id: {transactionIdString}");
            if (string.IsNullOrWhiteSpace(userIdString) 
                || string.IsNullOrWhiteSpace(transactionIdString) 
                || !Guid.TryParse(userIdString, out userId)
                || !Guid.TryParse(transactionIdString, out transactionId)
                ){
                return false;
            }
            return true;
        }
        
        // GET api/ping
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            if (!IsAuthorized()) return Unauthorized();
            return "Success from AuthCheck Controller!!!".Split(" ");            
        }

        // GET api/ping/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "Success: " + id;
        }

        // POST api/ping
        [HttpPost]
        public ActionResult<string> Post([FromForm] string value)
        {            
            return value;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}