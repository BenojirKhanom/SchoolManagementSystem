using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IEventRepository _eventRepo;
        private readonly INoticeBoardRepository _noticeRepo;

        public HomeController(IEventRepository eventRepo, INoticeBoardRepository noticeRepo)
        {
            _eventRepo = eventRepo;
            _noticeRepo = noticeRepo;
        }

        public ActionResult<string> Index()
        {
            return "Application Runing...";
        }

        [Authorize]
        //Mohammad Alauddin
        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetAllEventByEarlierDateTime()
        {
            var ev = await _eventRepo.GetAllEventByEarlierDateTime();
            if (ev.Count() != 0)
            {
                return ev.ToList();
            }
            return NotFound("Search reasult not found");
        }

        // Imran (19)
        // Get Home/GetAllNoticeByEarlierDateTime
        [HttpGet]
        public ActionResult<IEnumerable<NoticeBoard>> GetAllNoticeByEarlierDateTime()
        {
            var notice = _noticeRepo.GetAllNoticeByEarlierDateTime();
            if (notice.Count() != 0)
            {
                return notice.ToList();
            }
            return NotFound("Request is not found.");
        }
    }
}
