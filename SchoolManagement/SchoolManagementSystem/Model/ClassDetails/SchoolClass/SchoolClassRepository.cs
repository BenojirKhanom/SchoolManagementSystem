using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class SchoolClassRepository : ISchoolClassRepository
    {
        private readonly ApplicationDbContext _context;
        public SchoolClassRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        // Get SchoolClass ///
        public IEnumerable<SchoolClass> GetAllSchoolClass()
        {
            return _context.SchoolClass.ToList();
        }


        //Get SchoolClass By Id //
        public SchoolClass GetSchoolClass(int id)
        {
            if (SchoolClassExists(id))
            {
                return _context.SchoolClass.Where(sc => sc.Id == id).FirstOrDefault();
            }
            return null;
        }

        // Save and Update ****
        public SchoolClass SaveSchoolClass(SchoolClass schoolClass)
        {

            
            if(schoolClass.Id == 0)
            {
                _context.SchoolClass.Add(schoolClass);
                _context.SaveChanges();
                return schoolClass;
            }
            else
            {
                SchoolClass sc = _context.SchoolClass.Find(schoolClass.Id);
                if(sc != null)
                {
                    sc.ClassName = schoolClass.ClassName;
                    _context.SchoolClass.Update(sc);
                    _context.SaveChanges();
                    return sc;
                }

            }
            return null;
        }
        
        // Delete 
        public SchoolClass DeleteSchoolClass(int id)
        {
            SchoolClass sc = _context.SchoolClass.Find(id);
            if (sc != null)
            {
                _context.SchoolClass.Remove(sc);
                _context.SaveChanges();
                return sc;
            }
            return null;
        }

        public bool SchoolClassExists(int id)
        {
            return _context.SchoolClass.Any(e => e.Id == id);
        }
    }
}
