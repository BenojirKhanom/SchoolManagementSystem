using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("[controller]/[action]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepo;

        public EventsController( IEventRepository eventRepository)
        {
            _eventRepo = eventRepository;
        }





        //public async Task<ActionResult<IEnumerable<Event>>> GetEvent()
        //{
        //    var eve = await _eventRepo.GetAllEvent() ;
        //    return Ok(eve);
        //}


       

        
        // GET: api/Event
        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetYearWiseAllEvent(/*int BranchId, int year*/)
        {

            try
            {
                var notices = _eventRepo.GetYearWiseAllEvent(1,2021);

                if (notices == null)
                {
                    return NotFound();
                }
                return Ok(notices);


            }
            catch (Exception)
            {
                return BadRequest();
            }





        }

        //[HttpGet]
        public ActionResult<IEnumerable<Event>> GetMonthWiseAllEvent(/* int BranchId ,int month*/)
        {

            try
            {
                var notices = _eventRepo.GetMonthWiseAllEvent(1, 2021, 01);

                if (notices == null)
                {
                    return NotFound();
                }
                return Ok(notices);


            }
            catch (Exception)
            {
                return BadRequest();
            }

        }



        //[HttpGet]
        public ActionResult<IEnumerable<Event>> GetDateWiseAllEvent(/* int BranchId ,int Date*/)
        {

            try
            {
                var notices = _eventRepo.GetDateWiseAllEvent(1, 2021, 01, 01);

                if (notices == null)
                {
                    return NotFound();
                }
                return Ok(notices);


            }
            catch (Exception)
            {
                return BadRequest();
            }

        }




        // GET: api/Event/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var eve = await _eventRepo.GetEvent(id);

            if (eve == null)
            {
                return NotFound();
            }

            return eve;
        }


        // PUT: api/Events/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event eve)
        {
            if (id != eve.Id)
            {
                return BadRequest();
            }
            try
            {
                await _eventRepo.AddNewEvent(eve);
                return CreatedAtAction("GetEvent", new { id = eve.Id }, eve);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        // POST: api/Event
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event eve)
        {
            if (ModelState.IsValid)
            {
                await _eventRepo.AddNewEvent(eve);
                return CreatedAtAction("GetEvent", new { id = eve.Id }, eve);
            }
            return BadRequest("Model is not valid");
        }


        // DELETE: api/Event/5
        [HttpDelete("{id}")]
        public  async Task<ActionResult<Event>> DeleteEvent(int id)
        {
            try
            {
               await _eventRepo.DeleteEvent(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        

    }
}
