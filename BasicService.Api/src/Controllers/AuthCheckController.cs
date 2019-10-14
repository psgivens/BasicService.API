using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasicService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ContextHeaderCheck]
    public class AuthCheckController : MicroServiceControllerBase
    {
        public AuthCheckController(){
            TlsHack.Hack();
        }

        
        // GET api/ping
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return $"Success from AuthCheck Controller for user {this.UserId}!!!".Split(" ");            
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
