using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public class QuotaRepository : IQuotaRepository
    {
        private readonly ApplicationDbContext _context;
        public QuotaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Find Id in Database
        private bool QuotaExists(int id)
        {
            return _context.Quota.Any(e => e.Id == id);
        }



        // 1. Get All Quota
        public async Task<IEnumerable<Quota>> GetAllQuota()
        {
            if (_context != null)
            {
                return await _context.Quota.ToListAsync();
            }
            return null;
        }



        // 2. Get Quota By Id
        public async Task<Quota> GetQuota(int id)
        {
            if (QuotaExists(id))
            {
                var quota = await _context.Quota.FindAsync(id);
                return quota;
            }
            return null;

        }



        // 3. Save or Edit Quota
        public async Task<int> SaveQuota(Quota quota)
        {
            if (quota.Id == 0)
            {
                // Add new Quota
                _context.Quota.Add(quota);
            }
            else
            {
                // Find Quota is already exit in database?
                Quota dbEntry = _context.Quota.Find(quota.Id);
                if (dbEntry != null)
                {
                    //Update that Quota
                    dbEntry.QuotaName = quota.QuotaName;
                    _context.Quota.Update(dbEntry);
                }
            }
            try
            {
                //Commit the transaction
                var result = await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        // 4. Delete Quota
        public async Task<Quota> DeleteQuota(int id)
        {
            Quota dbEntry = _context.Quota.Find(id);

            if (dbEntry != null)
            {
                //Delete that Designation
                _context.Quota.Remove(dbEntry);
            }
            try
            {
                //Commit the transaction
                await _context.SaveChangesAsync();
                return dbEntry;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        // 5. Quota Wise StudentList Current Year
        public async Task<IEnumerable<Student>> QuotaWiseStudentList(int quotaId)
        {
            try
            {
                if (_context != null)
                {
                    var studentList = await _context.Student.Where(q => q.QuotaId == quotaId && q.AdmissionDate.Year == DateTime.Now.Year).ToListAsync();
                    return studentList;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        //6 Current Year Quota Wise Branch Student List
        public async Task<IEnumerable<Student>> QuotaWiseBranchStudentList(int branchId, int quotaId)
        {
            try
            {
                if (_context != null)
                {
                    List<Student> studentList = new List<Student>();

                    var branchClassList = await _context.BranchClass.Where(b => b.BranchId == branchId).ToListAsync();
                    if (branchClassList.Count() > 0)
                    {
                        foreach (var bcl in branchClassList)
                        {
                            var sectionExists = _context.Section.Where(s => s.BranchClassId == bcl.Id).FirstOrDefault();
                            if (sectionExists != null)
                            {
                                var student = _context.Student.Where(s => s.SectionId == sectionExists.Id && s.QuotaId == quotaId).FirstOrDefault();
                                if (student != null)
                                {
                                    studentList.Add(student);
                                }
                            }
                        }
                        return studentList;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //7 Current Year  Quota Wise Branch Class Student List
        public async Task<IEnumerable<Student>> QuotaWiseBranchClassStudentList(int branchId, int classId, int quotaId)
        {
            try
            {
                if (_context != null)
                {
                    List<Student> studentList = new List<Student>();

                    var branchClassList = await _context.BranchClass.Where(b => b.BranchId == branchId && b.SchoolClassId == classId).ToListAsync();
                    if (branchClassList.Count() > 0)
                    {
                        foreach (var bcl in branchClassList)
                        {
                            var sectionExists = _context.Section.Where(s => s.BranchClassId == bcl.Id).FirstOrDefault();
                            if (sectionExists != null)
                            {
                                var student = _context.Student.Where(s => s.SectionId == sectionExists.Id && s.QuotaId == quotaId).FirstOrDefault();
                                if (student != null)
                                {
                                    studentList.Add(student);
                                }
                            }
                        }
                        return studentList;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
