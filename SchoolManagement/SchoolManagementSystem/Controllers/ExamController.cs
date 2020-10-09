using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Model;
using SchoolManagementSystem.Data;

namespace SchoolManagementSystem.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamRepository _examRepo;
        private readonly IExamMarkRepository _examMarkRepo;
        private readonly IExamResultRepository _examResutlRepo;
       
        public ExamController(IExamRepository examRepo,IExamMarkRepository examMarkRepo, IExamResultRepository examResutlRepo)
        {
            _examRepo = examRepo;
            _examMarkRepo = examMarkRepo;
            _examResutlRepo = examResutlRepo;
           
        }

        [HttpGet("{branchId,year}")]
        public ActionResult<IEnumerable<Exam>> GetExamList(int branchId, int year)
        {
            try
            {
                var Result = _examRepo.GetAllExam(branchId, year);

                if (Result == null)
                {
                    return NotFound();
                }
                return Ok(Result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Exam> GetExam(int id)
        {
            try
            {
                var Result = _examRepo.getExam(id);

                if (Result == null)
                {
                    return NotFound();
                }
                return Ok(Result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //Post : 
        [HttpPost]
        public async Task<ActionResult<Exam>> CreateExam(Exam exam)
        {
            if (ModelState.IsValid)
            {
                var ET = await _examRepo.AddNewExam(exam);
                if (ET != null)
                {
                    return Ok(ET);
                }
            }
            return NotFound();
        }

        //Put : 
        [HttpPut]
        public async Task<ActionResult<Exam>> EditExam( Exam exam)
        {
            if (ModelState.IsValid)
            {
                var ET = await _examRepo.AddNewExam(exam);
                if (ET != null)
                {
                    return Ok(ET);
                }
            }
            return NotFound();
        }

        //Delete : Teacher/DeleteTeacher/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Exam>> DeleteExam(int id)
        {
            var ET = await _examRepo.DeleteExam(id);
            if (ET != null)
            {
                return Ok(ET);
            }
            return NotFound();
        }


        /// <summary>
        /// Exam marks 
        /// </summary>
        /// <param name="examId"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{examId,studentId}")]
        public ActionResult<IEnumerable<ExamMark>> GetMarks(int examId, int studentId)
        {
            try
            {
                var Result = _examMarkRepo.GetAllExamMarkOfStudent(examId, studentId);

                if (Result == null)
                {
                    return NotFound();
                }

                return Ok(Result);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public ActionResult<ExamMark> saveMark(ExamMark examMarks)
        {
            try
            {
                var examMrk = _examMarkRepo.AddExamMark(examMarks);

                if (examMrk == null)
                {
                    return NotFound();
                }

                return Ok(examMrk);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        /// <summary>
        /// Exam Result 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult<ExamResult> saveResult(ResultGenerate result)
        {
            try
            {
                var examMrk = _examResutlRepo.GenerateExamResult(result);

                if (examMrk == null)
                {
                    return NotFound();
                }

                return Ok(examMrk);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

    }
}
