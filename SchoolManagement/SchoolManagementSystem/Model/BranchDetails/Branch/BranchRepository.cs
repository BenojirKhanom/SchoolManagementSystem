using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public class BranchRepository : IBranchRepository
    {
        ApplicationDbContext _context;
        public BranchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Branch>> GetAllBranchs()
        {
            if (_context != null)
            {
                return await _context.Branch.ToListAsync();
            }
            return null;
        }

        public async Task<Branch> GetBranch(int id)
        {
            if (BranchExists(id))
            {
                var Branch = await _context.Branch.FindAsync(id);
                return Branch;
            }
            return null;

        }

        public async Task<Branch> SaveBranch(Branch Branch)
        {
            if (Branch.Id == 0)
            {
                // Add new Branch
                _context.Branch.Add(Branch);
                //Commit the transaction
                await _context.SaveChangesAsync();
                return Branch;
            }
            else
            {
                // Find Branch is already exit in database?
                Branch dbEntry = _context.Branch.Find(Branch.Id);

                if (dbEntry != null)
                {
                    //Update that Branch
                    dbEntry.BranchName = Branch.BranchName;
                    dbEntry.Location = Branch.Location;
                    dbEntry.Authority = Branch.Authority;
                    dbEntry.PostOfficeId = Branch.PostOfficeId;
                    _context.Branch.Update(dbEntry);
                    //Commit the transaction
                    await _context.SaveChangesAsync();
                    return dbEntry;
                }
            }
            return null;
        }

        public async Task<Branch> DeleteBranch(int? id)
        {
            // Find Branch is already exit in database?
            Branch dbEntry = _context.Branch.Find(id);

            if (dbEntry != null)
            {
                //Delete that Branch
                _context.Branch.Remove(dbEntry);

            }
            //Commit the transaction
            await _context.SaveChangesAsync();

            return dbEntry;
        }

        private bool BranchExists(int id)
        {
            return _context.Branch.Any(e => e.Id == id);
        }

        public IEnumerable<SchoolClass> GetBranchWiseClass(int BranchId)
        {
            List<SchoolClass> classList = new List<SchoolClass>();
            var BranchClass = _context.BranchClass.Where(a => a.BranchId == BranchId);
            foreach (var bc in BranchClass)
            {
                var schoolClass = _context.SchoolClass.Where(e => e.Id == bc.SchoolClassId).FirstOrDefault();
                classList.Add(schoolClass);
            }
            return classList.ToList();
        }

        public IEnumerable<Subject> GetAllSubjectForBranch(int BranchId)
        {
            List<Subject> subjectList = new List<Subject>();
            var classList = this.GetBranchWiseClass(BranchId);
            foreach (var a in classList)
            {
                var subject = _context.Subject.Where(sb => sb.SchoolClassId == a.Id);
                foreach (Subject sb in subject)
                {
                    subjectList.Add(sb);
                }
            }
            return subjectList;
        }
    }
}
