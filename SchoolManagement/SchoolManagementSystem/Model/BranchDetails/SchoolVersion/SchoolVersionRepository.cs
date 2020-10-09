using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class SchoolVersionRepository : ISchoolVersionRepository
    {
        private readonly ApplicationDbContext _context;
        public SchoolVersionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        // Get All *************//
        public IEnumerable<SchoolVersion> GetAllSchoolVersion()
        {
            return _context.SchoolVersion.ToList();
        }
        //********GetAll BY Id
        public SchoolVersion GetSchoolVersion(int id)
        {
            if (SchoolVersionExists(id))
            {
                return _context.SchoolVersion.Where(sv => sv.Id == id).FirstOrDefault();
            }
            return null;
        }

        
        // Save And Update **************
        public SchoolVersion  SaveSchoolVersion(SchoolVersion schoolVersion)
        {
            
            if(schoolVersion.Id == 0)
            {
                _context.SchoolVersion.Add(schoolVersion);
                _context.SaveChanges();
                return schoolVersion;
            }

            else
            {
                SchoolVersion schv = _context.SchoolVersion.Find(schoolVersion.Id);
                if(schv != null)
                {
                    schv.SchoolVersionName = schoolVersion.SchoolVersionName;
                    _context.SchoolVersion.Update(schv);
                    _context.SaveChanges();
                    return schv;
                }
            }
            return null;
        }
        // Delete SchoolVersion
        public SchoolVersion DeleteSchoolVersion(int id)
        {
            SchoolVersion sv = _context.SchoolVersion.Find(id);
            if (sv != null)
            {
                _context.SchoolVersion.Remove(sv);
                _context.SaveChanges();
                return sv;
            }
            return null;
          
        }

        public bool SchoolVersionExists(int id)
        {
            return _context.SchoolVersion.Any(e => e.Id == id);
        }
    }
}
