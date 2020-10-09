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
    public class ClassController : ControllerBase
    {
        private readonly IShiftRepository _shiftRepo;
        private readonly ISchoolVersionRepository _schoolVersionRepository;
        private readonly ISchoolClassRepository _schoolClassRepo;
        private readonly IRoomRepository _roomRepo;
        private readonly ISectionRepository _sectionRepo;

        public ClassController( IShiftRepository shiftRepo,
                                ISchoolClassRepository schoolClassRepo,
                                ISchoolVersionRepository schoolVersionRepository ,
                                IRoomRepository roomRepo,
                                ISectionRepository sectionRepo)
        {
            _shiftRepo = shiftRepo;
            _schoolVersionRepository = schoolVersionRepository;
            _schoolClassRepo = schoolClassRepo;
            _roomRepo = roomRepo;
            _sectionRepo = sectionRepo;
        }

           // Shift Related Controller***********//
        [HttpGet]
        public ActionResult<IEnumerable<Shift>> GetAllShift()
        {
            var shift = _shiftRepo.GetAllShift().ToList();
            if (shift == null)
            {
                return NotFound();
            }
            return Ok(shift);
        }
        [HttpGet("{id}")]
        public ActionResult<Shift> GetShift(int id)
        {
            var shift = _shiftRepo.GetShift(id);
            if (shift == null)
            {
                return NotFound();
            }
            return shift;
        }
        [HttpPost]
        public ActionResult<Shift> SaveShift(Shift shift)
        {
            var sh = _shiftRepo.SaveShift(shift);
            if (sh == null)
            {
                return NotFound();
            }
            return sh;
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Shift> DeleteShift(int id)
        {
            var shift = _shiftRepo.DeleteShift(id);
            if (shift == null)
            {
                return NotFound();
            }
            return shift;
        }


        // School Version Controller//


        [HttpGet]
        public ActionResult<IEnumerable<SchoolVersion>> GetAllSChoolVersion()
        {
            var schoolVersion = _schoolVersionRepository.GetAllSchoolVersion().ToList();
            if (schoolVersion == null)
            {
                return NotFound();
            }
            return Ok(schoolVersion);
        }
        [HttpGet("{id}")]
        public ActionResult<SchoolVersion> GetSchoolVersion(int id)
        {
            var SchV = _schoolVersionRepository.GetSchoolVersion(id);
            if (SchV == null)
            {
                return NotFound();
            }
            return SchV;
        }
        [HttpPost]
        public ActionResult<SchoolVersion> SaveShoolVersion(SchoolVersion schoolVersion)
        {
            var shv = _schoolVersionRepository.SaveSchoolVersion(schoolVersion);
            if (shv == null)
            {
                return NotFound();
            }
            return shv;
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<SchoolVersion> DeleteSchoolVersion(int id)
        {
            var schv = _schoolVersionRepository.DeleteSchoolVersion(id);
            if (schv == null)
            {
                return NotFound();
            }
            return schv;
        }


        // SchoolClass Controller ****************//


        [HttpGet]
        public ActionResult<IEnumerable<SchoolClass>> GetAllSchoolClass()
        {
            var schoolClass = _schoolClassRepo.GetAllSchoolClass().ToList() ;
            if (schoolClass == null)
            {
                return NotFound();
            }
            return Ok(schoolClass);
        }
        [HttpGet("{id}")]
        public ActionResult<SchoolClass> GetSchoolClass(int id)
        {
            var sc = _schoolClassRepo.GetSchoolClass(id);
            if (sc == null)
            {
                return NotFound();
            }
            return sc;
        }
        [HttpPost]
        public ActionResult<SchoolClass> SaveShoolClass(SchoolClass schoolClass)
        {
            var sc = _schoolClassRepo.SaveSchoolClass(schoolClass);
            if (sc == null)
            {
                return NotFound();
            }
            return sc;
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<SchoolClass> DeleteSchoolClass(int id)
        {
            var sc = _schoolClassRepo.DeleteSchoolClass(id);
            if (sc == null)
            {
                return NotFound();
            }
            return sc;
        }

        // Room Controller ****************//

        [HttpGet]
        [Route("{branchId}")]
        public ActionResult<IEnumerable<Room>> GetAllRoomByBranch(int branchId)
        {
            var rrr = _roomRepo.GetAllRoom(branchId).ToList();
            if (rrr == null)
            {
                return NotFound();
            }
            return Ok(rrr);
        }

        [HttpGet]
        [Route("{branchId}/{shiftId}")]
        public ActionResult<IEnumerable<Room>> GetAllAssignRoom(int branchId, int shiftId)
        {
            var rrr = _roomRepo.GetAllAssignRoom(branchId, shiftId).ToList();
            if (rrr == null)
            {
                return NotFound();
            }
            return Ok(rrr);
        }
        [HttpGet]
        [Route("{branchId}/{shiftId}")]
        public ActionResult<IEnumerable<Room>> GetAllUnAssignRoom(int branchId, int shiftId)
        {
            var rrr = _roomRepo.GetAllUnAssignRoom(branchId, shiftId).ToList();
            if (rrr == null)
            {
                return NotFound();
            }
            return Ok(rrr);
        }
        [HttpGet("{id}")]
        public ActionResult<Room> GetRoom(int id)
        {
            var room = _roomRepo.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }
            return room;
        }

        [HttpPost]
        public async Task< ActionResult<Room>> SaveRoom(Room room)
        {
            var sc =  await _roomRepo.AddNewRoom(room);
            if (sc == null)
            {
                return NotFound();
            }
            return sc;
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Room> DeleteRoom(int id)
        {
            var sc = _roomRepo.DeleteRoom(id);
            if (sc == null)
            {
                return NotFound();
            }
            return sc;
        }


        // Section Controller ****************//

        [HttpGet]
        [Route("{branchId}")]
        public ActionResult<IEnumerable<Section>> GetAllSection(int branchId)
        {
            var rrr = _sectionRepo.GetAllSection(branchId).ToList();
            if (rrr == null)
            {
                return NotFound();
            }
            return Ok(rrr);
        }

        [HttpGet]
        [Route("{branchId}/{classId}")]
        public ActionResult<IEnumerable<Section>> GetAllSectionByClass(int branchId, int classId)
        {
            var rrr = _sectionRepo.GetAllSectionByClass(branchId, classId).ToList();
            if (rrr == null)
            {
                return NotFound();
            }
            return Ok(rrr);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Section> GetAllSectionById(int id)
        {
            var rrr = _sectionRepo.GetSection(id); 
            if (rrr == null)
            {
                return NotFound();
            }
            return Ok(rrr);
        }

        [HttpPost]
        public async Task<ActionResult<Section>> SaveSection(Section section)
        {
            var sc = await _sectionRepo.SaveSection(section);
            if (sc == null)
            {
                return NotFound();
            }
            return sc;
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Section> DeleteSection(int id)
        {
            var sc = _sectionRepo.DeleteSection(id);
            if (sc == null)
            {
                return NotFound();
            }
            return sc;
        }
    }
}
