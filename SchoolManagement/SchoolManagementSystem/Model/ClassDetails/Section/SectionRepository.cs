using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class SectionRepository : ISectionRepository
    {
        private readonly ApplicationDbContext _context;
        public SectionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Section> GetAllSection(int branchId)
        {
            List<Section> sectionList = new List<Section>();
            var branchClassList = _context.BranchClass.Where(b => b.BranchId == branchId).ToList();
            if(branchClassList.Count() >0)
            {
                foreach(BranchClass branchClass in branchClassList)
                {
                    var sections = _context.Section.Where(s => s.BranchClassId == branchClass.Id).ToList();
                    sectionList.AddRange(sections);
                }
                return sectionList;
            }
            return null;
        }
        public IEnumerable<Section> GetAllSectionByClass(int branchId, int classId)
        {
            
            var branchClass = _context.BranchClass.Where(b => b.BranchId == branchId && b.SchoolClassId == classId).FirstOrDefault();
            if (branchClass != null)
            {
                List<Section> sectionList = _context.Section.Where(s => s.BranchClassId == branchClass.Id).ToList();
                return sectionList;
            }
            return null;
        }


        public Section GetSection(int id)
        {
            if (SectionExists(id))
            {
                return _context.Section.Where(s => s.Id == id).FirstOrDefault();
            }
            return null;
        }
        public async Task<Section> SaveSection(Section section)
        {
            if (section.Id == 0)
            {
                _context.Section.Add(section);
                await _context.SaveChangesAsync();
                return section;
            }
            else
            {
                Section sec = _context.Section.Find(section.Id);

                if (sec != null)
                {
                    sec.SectionName = section.SectionName;
                    sec.GroupId = section.GroupId;   
                    
                    _context.Section.Update(sec);

                    await _context.SaveChangesAsync();
                    return sec;
                }
            }
            return null;
        }
        public Section DeleteSection(int id)
        {
            Section s = _context.Section.Find(id);
            if (s != null)
            {
                _context.Section.Remove(s);
                _context.SaveChanges();
                return s;
            }
            return null;
        }

        public bool SectionExists(int id)
        {
            return _context.Section.Any(e => e.Id == id);
        }
    }
}
