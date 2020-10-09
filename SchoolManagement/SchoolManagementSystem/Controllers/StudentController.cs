using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IQuotaRepository _quotaRepo;
        private readonly IApplicationFormRepository _applicationFormRepo;
        private readonly IStudentRepository _studentRepo;


        public StudentController(ApplicationDbContext context, IQuotaRepository quotaRepo, IApplicationFormRepository applicationFormRepo, IStudentRepository studentRepo)
        {
            _context = context;
            _quotaRepo = quotaRepo;
            _applicationFormRepo = applicationFormRepo;
            _studentRepo = studentRepo;
        }


        // ------------Start Student Table ------------------



        // 1. Get Student By Id
        [HttpGet]
        [Route("GetStudent/{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            try
            {
                var student = await _studentRepo.GetStudent(id);

                if (student == null)
                {
                    return NotFound("Student does not exist!");
                }
                return student;
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }



        // 2. Get Student Informatoin  By StudentIdNo From Student Table
        [HttpGet]
        [Route("GetStudentInfo/{studentId}")]
        public async Task<ActionResult<Student>> GetStudentInfoByStudentIdNo(string studentId)
        {
            try
            {
                var student = await _studentRepo.GetStudentInfo(studentId);

                if (student == null)
                {
                    return NotFound("Student does not exist!");
                }
                return student;
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }




        // 3. Insert Data Into Student Table From ApplicationFrom Table By ApplicantId
        [HttpPost]
        [Route("PostStudent/{applicantId}")]
        public async Task<IActionResult> PostStudent(string applicantId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var studentId = await _studentRepo.SaveStudent(applicantId);

                    if (studentId != null)
                    {
                        return Ok(studentId);
                    }
                    else
                    {
                        return NotFound("Student already Exist!");
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }
            return BadRequest("Model State is not valid");
        }




        // 4. Update Student
        [HttpPut]
        [Route("PutStudent")]
        public async Task<IActionResult> PutStudent([FromBody] Student model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _studentRepo.UpdateStudent(model);
                    return Ok(model.StudentIdNo);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }
                    return BadRequest();
                }
            }
            return BadRequest();
        }




        // 5. Delete Student
        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var student = await _studentRepo.DeleteStudent(id);
                if (student == null)
                {
                    return NotFound("Student does not exist!");
                }
                return Ok(student.StudentIdNo);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }




        // 6. Get Class Wise Student List
        [HttpGet]
        [Route("GetClassWiseStudentList/{branchId}/{classId}")]
        public ActionResult<IEnumerable<Student>> GetClassWiseStudentList(int branchId, int classId)
        {
            try
            {
                var studentList = _studentRepo.GetClassWiseStudentList(branchId, classId);

                if (studentList == null)
                {
                    return NotFound();
                }

                return Ok(studentList.Count());
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }



        //-------------End Student Table ---------------------------



        //-------------Start ApplicationFrom Table ---------------------------


        // 1. Apply for admission  ApplicationFrom
        [HttpPost]
        [Route("PostApplicationForm")]
        public async Task<IActionResult> PostApplicationForm([FromBody] ApplicationForm model)
        {
            if (ModelState.IsValid)
            {
                ApplicationForm applicantExists = _context.ApplicationForm.Where(a => a.BirthRegistrationNo == model.BirthRegistrationNo && a.ApplingDate.Year == model.ApplingDate.Year).FirstOrDefault();
                if (applicantExists != null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "You are already apply!" });
                }
                try
                {
                    var applicant = await _applicationFormRepo.SaveApplication(model);

                    if (applicant != null)
                    {
                        return Ok(applicant);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return BadRequest("Model State is not valid");
        }




        // 2. Get Applicant Information By ApplicantId
        [HttpGet]
        [Route("GetApplicantInfo/{applicantId}")]
        public async Task<ActionResult<ApplicationForm>> GetApplicantInfo(string applicantId)
        {
            try
            {
                var applicant = await _applicationFormRepo.GetApplicantInfo(applicantId);

                if (applicant == null)
                {
                    return NotFound();
                }
                return applicant;
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }



        // 3. Get Applicant Information By ApplicantId
        [HttpGet]
        [Route("GetApplicant/{id}")]
        public async Task<ActionResult<ApplicationForm>> GetApplicant(int id)
        {
            try
            {
                var applicant = await _applicationFormRepo.GetApplicant(id);

                if (applicant == null)
                {
                    return NotFound();
                }
                return applicant;
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }



        // 4. Get All Applicant List Current Year
        [HttpGet]
        [Route("GetCurrentYearApplicantList")]
        public ActionResult<IEnumerable<ApplicationForm>> GetCurrentYearApplicantList()
        {
            try
            {
                var applicantList = _applicationFormRepo.GetCurrentYearApplicantList();
                if (applicantList != null)
                {
                    return Ok(applicantList.Count());
                }
                return NotFound("There is no applicant in this year!");
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }



        // 5. Get All Applicant List Current Year Branch Wise
        [HttpGet]
        [Route("GetCurrentYearApplicantListBranchWise/{branchId}")]
        public ActionResult<IEnumerable<ApplicationForm>> GetCurrentYearApplicantListBranchWise(int branchId)
        {
            try
            {
                var applicantList = _applicationFormRepo.GetCurrentYearApplicantListBranchWise(branchId);
                if (applicantList != null)
                {
                    return Ok(applicantList.Count());
                }
                return NotFound("There is no applicant in this branch!");
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }



        // 6. Get All Application List Current Year Branch Class Wise
        [HttpGet]
        [Route("GetCurrentYearApplicantListBranchClassWise/{branchId}/{classId}")]
        public ActionResult<IEnumerable<ApplicationForm>> GetCurrentYearApplicantListBranchClassWise(int branchId, int classId)
        {
            try
            {
                var applicantList = _applicationFormRepo.GetCurrentYearApplicantListBranchClassWise(branchId, classId);
                if (applicantList == null)
                {
                    return NotFound("There are no applicants in this category!");
                }
                return Ok(applicantList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        // 7. Delete admission  ApplicationFrom
        [HttpPost]
        [Route("DeleteApplicationFrom/{id}")]
        public async Task<IActionResult> DeleteApplicationFrom(int id)
        {
            try
            {
                var applicant = await _applicationFormRepo.DeleteApplication(id);
                if (applicant == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        //-------------End ApplicationFrom Table ---------------------------



        //---------Start Quota Table ---------------------------

        // 1. Get All Quota
        [HttpGet]
        [Route("GetAllQuota")]
        public async Task<IActionResult> GetAllQuota()
        {
            try
            {
                var quota = await _quotaRepo.GetAllQuota();
                if (quota == null)
                {
                    return NotFound();
                }

                return Ok(quota);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        // 2. Get Quota By Id
        [HttpGet]
        [Route("GetQuota/{quotaId}")]
        public async Task<IActionResult> GetQuota(int quotaId)
        {
            try
            {
                var quota = await _quotaRepo.GetQuota(quotaId);

                if (quota == null)
                {
                    return NotFound();
                }

                return Ok(quota);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        // 3. Save Quota
        [HttpPost]
        [Route("PostQuota")]
        public async Task<IActionResult> PostQuota([FromBody] Quota model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Quota quotaExists = _context.Quota.Where(q => q.QuotaName == model.QuotaName).FirstOrDefault();
                    if (quotaExists != null)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Quota already Exists!" });
                    }

                    var quotaId = await _quotaRepo.SaveQuota(model);
                    if (quotaId > 0)
                    {
                        return CreatedAtAction("GetQuota", new { id = model.Id }, model);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }



        // 3. Edit Quota
        [HttpPut]
        [Route("PutQuota")]
        public async Task<IActionResult> PutQuota([FromBody] Quota model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _quotaRepo.SaveQuota(model);
                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }
                    return BadRequest();
                }
            }
            return BadRequest();
        }



        // 4. Delete Quota
        [Route("DeleteQuota/{id}")]
        public async Task<IActionResult> DeleteQuota(int id)
        {
            try
            {
                var result = await _quotaRepo.DeleteQuota(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        // 5  Quota Wise Student List Current Year
        [HttpGet]
        [Route("QuotaWiseStudentList/{quotaId}")]
        public async Task<IActionResult> QuotaWiseStudentList(int quotaId)
        {
            try
            {
                var studentList = await _quotaRepo.QuotaWiseStudentList(quotaId);

                if (studentList == null)
                {
                    return NotFound();
                }

                return Ok(studentList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        // 6 Current Year Quota Wise Branch StudentList
        [HttpGet]
        [Route("QuotaWiseBranchStudentList/{branchId}/{quotaId}")]
        public async Task<IActionResult> QuotaWiseBranchStudentList(int branchId, int quotaId)
        {
            try
            {
                var studentList = await _quotaRepo.QuotaWiseBranchStudentList(branchId, quotaId);

                if (studentList == null)
                {
                    return NotFound();
                }

                return Ok(studentList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }




        //7 Current Year  Quota Wise Branch Class Student List
        [HttpGet]
        [Route("QuotaWiseBranchClassStudentList/{branchId}/{classId}/{quotaId}")]
        public async Task<IActionResult> QuotaWiseBranchClassStudentList(int branchId, int classId, int quotaId)
        {
            try
            {
                var studentList = await _quotaRepo.QuotaWiseBranchClassStudentList(branchId, classId, quotaId);

                if (studentList == null)
                {
                    return NotFound();
                }

                return Ok(studentList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        //-------------End Quota Table ---------------------------



        //---------Start Bkash Model ---------------------------

        // POST: savePayment
        [HttpPost]
        [Route("savePayment")]
        public async Task<object> savePayment([FromBody] object model)
        {
            object result = null; object resdata = null;
            try
            {
                BkashModel _bkModel = JsonConvert.DeserializeObject<BkashModel>(model.ToString());
                if (_bkModel != null)
                {
                    //Save To database
                    _context.BkashModel.Add(_bkModel);
                    await _context.SaveChangesAsync();
                    resdata = "Transaction Saved!";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result = new
            {
                resdata
            };

        }


        //-------------End Bkash Model ---------------------------

    }
}
