using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceOfStudentRepository _studentAttendanceRepo;
        public AttendanceController(IAttendanceOfStudentRepository studentAttendanceRepo)
        {
            _studentAttendanceRepo = studentAttendanceRepo;

        }


        [HttpGet]
        public IEnumerable<object> GetStudentInfo()
        {
            return _studentAttendanceRepo.GetStudentByNumber();
        }

        [HttpPost("{id}")]
        public void SaveAttendance(int id)
        {
            if (id != 0)
            {
                _studentAttendanceRepo.SaveAttendance(id);                
            }
        }

        [HttpGet("{id}")]
        public int GetStudentStatus(int id)
        {
            return _studentAttendanceRepo.GetStudentStatus(id);
        }

        [HttpPut("{id}")]
        public void UpdateLeaveTime(int id)
        {
            _studentAttendanceRepo.UpdateForOutTime(id);        
        }

        [HttpPut("{id}")]
        public ActionResult saveFinger(int id, string finger)
        {
            var response = _studentAttendanceRepo.registerStudentFinger(id, finger);

            if (response == 1)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return Content("Finger Data Successfully saved.", System.Net.Mime.MediaTypeNames.Text.Plain);
            }
            Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            return Content("The attached file is not supported", System.Net.Mime.MediaTypeNames.Text.Plain);
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetStudentFingerData(int id)
        {
            var fingerData = _studentAttendanceRepo.GetStudentFingerData(id);

            if (fingerData != null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return Content(fingerData, System.Net.Mime.MediaTypeNames.Text.Plain);
            }
            Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
            return Content("Scerching Data is null", System.Net.Mime.MediaTypeNames.Text.Plain);
        }

    }
}
