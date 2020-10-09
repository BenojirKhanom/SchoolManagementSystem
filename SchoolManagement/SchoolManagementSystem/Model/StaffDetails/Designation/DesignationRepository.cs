using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public class DesignationRepository : IDesignationRepository
    {
        ApplicationDbContext _context;
        public DesignationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Designation>> GetAllDesignations()
        {
            if (_context != null)
            {
                return await _context.Designation.ToListAsync();
            }
            return null;
        }

        public async Task<Designation> GetDesignation(int id)
        {
            if (DesignationExists(id))
            {
                var designation = await _context.Designation.FindAsync(id);
                return designation;
            }
            return null;

        }

        public async Task<int> SaveDesignation(Designation designation)
        {
            if (designation.Id == 0)
            {
                // Add new Designation
                _context.Designation.Add(designation);

            }
            else
            {
                // Find designation is already exit in database?
                Designation dbEntry = _context.Designation.Find(designation.Id);

                if (dbEntry != null)
                {
                    //Update that Designation
                    dbEntry.DesignationName = designation.DesignationName;
                    _context.Designation.Update(dbEntry);

                }
            }
            //Commit the transaction
            await _context.SaveChangesAsync();

            return designation.Id;

        }


        public async Task<Designation> DeleteDesignation(int? id)
        {
            Designation dbEntry = _context.Designation.Find(id);

            if (dbEntry != null)
            {
                //Delete that Designation
                _context.Designation.Remove(dbEntry);

            }
            //Commit the transaction
            await _context.SaveChangesAsync();

            return dbEntry;
        }

        private bool DesignationExists(int id)
        {
            return _context.Designation.Any(e => e.Id == id);
        }

    }
}
