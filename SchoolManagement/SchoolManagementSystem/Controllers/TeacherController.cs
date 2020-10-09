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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepo;
       
        public TeacherController(ITeacherRepository teacherR)
        {
            _teacherRepo = teacherR;           
        }




        //Post : Teacher/AddTeacher
        [HttpPost]
        public async Task<ActionResult<Teacher>> CreateTeacher(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                var ET = await _teacherRepo.AddTeacher(teacher);
                if (ET != null)
                {
                    return Ok(ET);
                }
            }
            return NotFound();
        }

        //Put : Teacher/EditTeacher/1
        [HttpPut("{id}")]
        public async Task<ActionResult<Teacher>> EditTeacher(int id, Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                var ET = await _teacherRepo.UpdateTeacher(id, teacher);
                if (ET != null)
                {
                    return Ok(ET);
                }
            }            
            return NotFound();
        }

        //Delete : Teacher/DeleteTeacher/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher>> DeleteTeacher(int id)
        {
            var ET = await _teacherRepo.DeleteTeacher(id);
            if (ET != null)
            {
                return Ok(ET);
            }
            return NotFound();
        }


        //Get: Teacher/GetTeacher/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var teacher = await _teacherRepo.GetTeacherByID(id);
            if (teacher != null)
            {
                return teacher;
            }
            return NotFound("Scerching Data is null");
        }
        [HttpGet("{branchId}")]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetAllTeacherForBranch(int branchId)
        {
            var teacher = await _teacherRepo.GetAllTeacherByBranch(branchId);
            if (teacher.Count() > 0)
            {
                return teacher.ToList();
            }
            return NotFound("Searching data is null");
        }

        [HttpGet("{branchId}/{subjectId}")]
        public ActionResult<IEnumerable<Teacher>> GetSubjectWiseTeacherForBranch(int branchId, int subjectId)
        {
            var teacherList = _teacherRepo.GetSubjectWiseTeacherForBranch(branchId, subjectId);
            if (teacherList.Count() > 0)
            {
                return teacherList.ToList();
            }
            return NotFound("Scerching Data is null");
        }
        [HttpGet("{branchId}")]
        public ActionResult<IEnumerable<Teacher>> GetAllActiveTeacher(int branchId)
        {
            var teacherList = _teacherRepo.GetBranchWiseActiveTeacher(branchId);
            if (teacherList.Count() != 0)
            {
                return teacherList.ToList();
            }
            return NotFound("Scerching Data is null");
        }

        [HttpGet("{branchId}")]
        public ActionResult<IEnumerable<Teacher>> GetAllTeacherCheckResign(int branchId)
        {
            var teacherList = _teacherRepo.GetAllTeacherCheckResign(branchId);
            if (teacherList.Count() != 0)
            {
                return teacherList.ToList();
            }
            return NotFound("Scerching Data is null");
        }
        //  Subject Teacher//////////////////////////////////////////////////////////
        //Post : Teacher/AddTeacher
        [HttpPost]
        public async Task<ActionResult<SubjectTeacher>> AddSubjectTeacher(SubjectTeacher subjectTeacher)
        {
            if (ModelState.IsValid)
            {
                var ET = await _teacherRepo.AddSubjectTeacher(subjectTeacher);
                if (ET != null)
                {
                    return Ok(ET);
                }
            }
            return NotFound();
        }

        //Delete : SubjectTeacher/DeleteSubjectTeacher/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubjectTeacher>> DeleteSubjectTeacher( int id)
        {
            var ET = await _teacherRepo.DeleteSubjectTeacher(id);
            if (ET != null)
            {
                return Ok(ET);
            }
            return NotFound();
        }



    }
}
