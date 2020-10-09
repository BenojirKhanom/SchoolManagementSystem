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
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepository _context;
        private readonly IStaffTaskRepository _staffTaskRepo;
        private readonly ITaskRoutineRepository _taskRoutineRepo;

        public StaffController(IStaffRepository context, IStaffTaskRepository staffTaskRepo, ITaskRoutineRepository taskRoutineRepo)
        {
            _context = context;
            _staffTaskRepo = staffTaskRepo;
            _taskRoutineRepo = taskRoutineRepo;
        }
        /*-----------------------------------Task Routine----------------------------*/

        // GET All TasK Routine
        [HttpGet]
        public ActionResult<IEnumerable<TaskRoutine>> GetAllTaskRoutine()
        {
            var taskRList = _taskRoutineRepo.GetAllTaskRoutine();
            if (taskRList.Count() != 0)
            {
                return taskRList.ToList();
            }
            return NotFound("Scerching Data is null");
        }


        // GET Task Routine By Id
        [HttpGet("{id}")]
        public ActionResult<TaskRoutine> GetTaskRoutine(int id)
        {
            var taskRoutine = _taskRoutineRepo.GetTaskRoutine(id);

            if (taskRoutine == null)
            {
                return NotFound();
            }

            return taskRoutine;
        }

        //POST Task Routine
        [HttpPost]
        public async Task<ActionResult<TaskRoutine>> PostTaskRoutine(TaskRoutine taskRoutine)
        {
            if (ModelState.IsValid)
            {
                await _taskRoutineRepo.SaveTaskRoutine(taskRoutine);
                return CreatedAtAction("GetTaskRoutine", new { id = taskRoutine.Id }, taskRoutine);
            }
            return BadRequest("Model is not valid");


        }


        // PUT Task Routine
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskRoutine(int id, TaskRoutine taskRoutine)
        {
            if (id != taskRoutine.Id)
            {
                return BadRequest();
            }
            try
            {
                await _taskRoutineRepo.SaveTaskRoutine(taskRoutine);
                return CreatedAtAction("GetTaskRoutine", new { id = taskRoutine.Id }, taskRoutine);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        // DELETE Task Routine
        [HttpDelete("{id}")]
        public ActionResult<TaskRoutine> DeleteTaskRoutine(int id)
        {
            try
            {
                _taskRoutineRepo.DeleteTaskRoutine(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }




        /*-------------------------------------Staff Task-------------------------------------*/

        // GET All Staff Task
        [HttpGet]
        public ActionResult<IEnumerable<StaffTask>> GetAllStaffTask()
        {
            var taskList = _staffTaskRepo.GetAllStaffTask();
            if (taskList.Count() != 0)
            {
                return taskList.ToList();
            }
            return NotFound("Scerching Data is null");
        }

        // GET Staff Task By Id
        [HttpGet("{id}")]
        //public async Task<ActionResult<StaffTask>> GetStaffTask(int id)
        public ActionResult<StaffTask> GetStaffTask(int id)
        {
            var staffTask = _staffTaskRepo.GetStaffTask(id);

            if (staffTask == null)
            {
                return NotFound();
            }

            return staffTask;
        }

        //POST StaffTask
        [HttpPost]
        public async Task<ActionResult<StaffTask>> PostStaffTask(StaffTask staffTask)
        {
            if (ModelState.IsValid)
            {
                await _staffTaskRepo.SaveStaffTask(staffTask);
                return CreatedAtAction("GetStaffTask", new { id = staffTask.Id }, staffTask);
            }
            return BadRequest("Model is not valid");


        }

        // PUT StaffTask 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaffTask(int id, StaffTask stTask)
        {
            if (id != stTask.Id)
            {
                return BadRequest();
            }
            try
            {
                await _staffTaskRepo.SaveStaffTask(stTask);
                return CreatedAtAction("GetStaffTask", new { id = stTask.Id }, stTask);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE StaffTask
        [HttpDelete("{id}")]
        public ActionResult<StaffTask> DeleteStaffTask(int id)
        {
            try
            {
                _staffTaskRepo.DeleteStaffTask(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        /*-------------------------------Staff--------------------------------------------*/

        //Post : Staff/AddStaff
        [HttpPost]
        public async Task<ActionResult<Staff>> CreateTeacher(Staff staff)
        {
            if (ModelState.IsValid)
            {
                var ET = await _context.AddStaff(staff);
                if (ET != null)
                {
                    return Ok(ET);
                }
            }
            return NotFound();
        }

        //Put : Staff/UpdateStaff/1
        [HttpPut("{id}")]
        public async Task<ActionResult<Staff>> EditTeacher(int id, Staff staff)
        {
            if (ModelState.IsValid)
            {
                var ET = await _context.UpdateStaff(id, staff);
                if (ET != null)
                {
                    return Ok(ET);
                }
            }
            return NotFound();
        }

        //Delete : Staff/DeleteStaff/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Staff>> DeleteStaff(int id)
        {
            var ET = await _context.DeleteStaff(id);
            if (ET != null)
            {
                return Ok(ET);
            }
            return NotFound();
        }

        //Get: Staff/GetStaff/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetTeacher(int id)
        {
            var staff = await _context.GetStaff(id);
            if (staff != null)
            {
                return staff;
            }
            return NotFound("Scerching Data is null");
        }

        //Get: Staff/GetAllStaffByBranch/1
        [HttpGet("{branchId}")]
        public async Task<ActionResult<IEnumerable<Staff>>> GetAllStaffByBranch(int branchId)
        {
            var Staff = await _context.GetAllStaffByBranch(branchId);
            if (Staff.Count() > 0)
            {
                return Staff.ToList();
            }
            return NotFound("Searching data is null");
        }

        //Get: Staff/GetAllStaffByDesignation/1/1
        [HttpGet("{branchId}/{designatonId}")]
        public ActionResult<IEnumerable<Staff>> GetAllStaffByDesignation(int branchId, int designatonId)
        {
            var StaffList = _context.GetAllStaffByDesignation(branchId, designatonId);
            if (StaffList.Count() > 0)
            {
                return StaffList.ToList();
            }
            return NotFound("Scerching Data is null");
        }



        //Put : Staff/EditStaffProfile/1
        [HttpPut("{id}")]
        public async Task<ActionResult<Staff>> EditStaffProfile(int id, Staff staff)
        {
            if (id != staff.Id)
            {
                return BadRequest();
            }
            else
            {
                await _context.EditStaffProfile(id, staff);
            }

            return Ok();
        }

        //Get: Staff/GetBranchWiseActiveStaff/1
        [HttpGet("{branchId}")]
        public ActionResult<IEnumerable<Staff>> GetBranchWiseActiveStaff(int branchId)
        {
            var staffList = _context.GetBranchWiseActiveStaff(branchId);
            if (staffList.Count() != 0)
            {
                return staffList.ToList();
            }
            return NotFound("Scerching Data is null");
        }
        //Get: Staff/GetAllStaffCheckResign/1
        [HttpGet("{branchId}")]
        public ActionResult<IEnumerable<Staff>> GetAllStaffCheckResign(int branchId)
        {
            var staffList = _context.GetAllStaffCheckResign(branchId);
            if (staffList.Count() != 0)
            {
                return staffList.ToList();
            }
            return NotFound("Scerching Data is null");
        }

    }
}
