using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BasicService.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace BasicService.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class BasicServiceController : ControllerBase
    {
        private readonly BasicServiceDbContext _context;

        public BasicServiceController (BasicServiceDbContext context)
        {
            _context = context;

            if (_context.BasicServiceEntries.Count() == 0)
            {
                _context.BasicServiceEntries.Add(new BasicServiceEntryModel{
                    UserId = System.Guid.NewGuid().ToString(),
                    StartTime = System.DateTime.Now,
                    Modified = System.DateTime.Now,
                    Planned = "Sample activity",
                    Actual = "Sample activity",
                    Elapsed = 25 * 60,
                    Tags = "",
                    State = BasicServiceState.NotStarted
                });

                _context.SaveChanges();
            }
        }    

        [HttpGet]
        public List<BasicServiceEntryModel> GetAll()
        {
            // return Enumerable
            //     .Empty<BasicServiceEntryModel>()
            //     .ToList();// _context.BasicServiceEntries.ToList();
            return _context.BasicServiceEntries.ToList();
        }

        [HttpGet("{id}", Name = "GetBasicService")]
        public  async Task<ActionResult>  GetByIdAsync(long id)
        {
            var item = await _context.BasicServiceEntries.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }   


        [HttpPost]
        
        public IActionResult Create([FromBody]BasicServiceEntryDto model)
        {                  
            var entry = new BasicServiceEntryModel{
                UserId = model.UserId,
                StartTime = DateTime.Parse(model.StartTime),
                Modified = DateTime.Now,
                Planned = model.Planned,
                Actual = model.Actual,
                Elapsed = model.Elapsed,
                Tags = model.Tags,
                State = (BasicServiceState)model.State
            };
            try{      
                _context.BasicServiceEntries.Add(entry);
                _context.SaveChanges();
                return CreatedAtRoute("GetBasicService", new { id = entry.Id }, entry);
            } catch {
                Console.WriteLine("error");
                throw;
            }
        }
    }
    public class BasicServiceEntryDto {
        public string UserId { get; set; }
        public string StartTime { get; set; }        
        public string Planned { get; set; }
        public string Actual {get; set;}
        public int Elapsed { get; set; }
        public string Tags { get; set; }
        public long State { get; set; }
    }

}