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
    public class BranchController : ControllerBase
    {
        private readonly IBranchClassRepository _branchClassRepository;
        private readonly INoticeBoardRepository _noticeBoardRepository;
        private readonly IRulesRegulationRepository _RulesRegulationRepository;
        private readonly IHolidayRepository _holidayRepository;
        private readonly ISubjectRepository _subjectRepository;
        public BranchController(IBranchClassRepository branchClassRepository, INoticeBoardRepository noticeBoardRepository, IRulesRegulationRepository RulesRegulationRepository,IHolidayRepository holidayRepository, ISubjectRepository subjectRepository)
        {

            _branchClassRepository = branchClassRepository; ;
            _noticeBoardRepository = noticeBoardRepository;
            _RulesRegulationRepository = RulesRegulationRepository;
            _holidayRepository = holidayRepository;
            _subjectRepository = subjectRepository;
        }




        [HttpGet("{branchId}/{shiftId}")]
        public async Task<ActionResult<IEnumerable<BranchClass>>> GetBranchClassByBranch(int branchId, int shiftId)
        {

            var branchClasses = await _branchClassRepository.GetBranchClassByBranch(branchId, shiftId);

            if (branchClasses.Count() != 0)
            {
                return branchClasses.ToList();
            }
            return NotFound();
        }



        [HttpGet("{id}")]
        public async Task <ActionResult<IEnumerable<BranchClass>>> GetBranchClass(int id)
        {
            var branchClasses = await _branchClassRepository.GetBranchClass(id); 

            if (branchClasses != null)
            {
                return Ok(branchClasses);
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<ActionResult<BranchClass>> CreateNewBranchClass(BranchClass  branchClass)
        {
            if (ModelState.IsValid)
            {
                var branchCl = await _branchClassRepository.CreateBranchClass(branchClass);
                return Ok(branchCl);
            }
            return BadRequest("Model is not valid");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Event>> DeleteEvent(int id)
        {
            try
            {
                var branchCL = await _branchClassRepository.DeleteBranchClass(id);
                return Ok(branchCL);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }






        [HttpGet("{branchId}/{year}")]
        public ActionResult<IEnumerable<NoticeBoard>> GetAllbranchWiseNotice(int branchId ,int year)
        {
            try
            {
                var notices = _noticeBoardRepository.GetAllBranchWiseNotice(branchId, year);

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


        [HttpGet("{branchId}")]
        public ActionResult<IEnumerable<RulesRegulation>> GetAllbranchWiseRules( int branchId)
        {
            try
            {
                var notices = _RulesRegulationRepository.GetAllBranchWiseRules(branchId);

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

        //Kawsar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Holiday>>> GetDateWiseAllHoliday(/*int branchId, int year*/)
        {

            var notices = await _holidayRepository.GetDateWiseAllHoliday(2020, 1, 01);
            if (notices.Count() != 0)
            {
                return notices.ToList();
            }
            return NotFound();
        }



        //**********GetAllSubjectForBranch  *****************//

        [HttpGet("{branchId}")]
        public ActionResult<IEnumerable<Subject>> GetAllSubjectForbranch(int branchId)
        {
            var subjectlist = _subjectRepository.GetAllSubjectForBranch(branchId);
            if (subjectlist.Count() != 0)
            {
                return subjectlist.ToList();
            }
            return NotFound("Scerching Subject is Not found");
        }



    }
}
