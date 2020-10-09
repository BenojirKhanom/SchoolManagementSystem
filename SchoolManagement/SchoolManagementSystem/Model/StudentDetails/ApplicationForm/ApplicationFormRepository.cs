using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public class ApplicationFormRepository : IApplicationFormRepository
    {
        private readonly ApplicationDbContext _context;
        public ApplicationFormRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        private bool ApplicationFormExists(int id)
        {
            return _context.ApplicationForm.Any(a => a.Id == id);
        }


        // Get All Applicant List
        public IEnumerable<ApplicationForm> GetAllApplicant()
        {
            if (_context != null)
            {
                return _context.ApplicationForm.ToList();
            }
            return null;
        }


        // 1. Save Application From
        public async Task<ApplicationForm> SaveApplication(ApplicationForm applicationForm)
        {
            if (_context != null)
            {
                await _context.ApplicationForm.AddAsync(applicationForm);
                try
                {
                    await _context.SaveChangesAsync();

                    ApplicationForm applicant = new ApplicationForm()
                    {
                        FullName = applicationForm.FullName,
                        FatherName = applicationForm.FatherName,
                        MotherName = applicationForm.MotherName,
                        ApplicantId = applicationForm.ApplicantId,
                        BirthRegistrationNo = applicationForm.BirthRegistrationNo,
                        BranchClassId = applicationForm.BranchClassId,
                        ImageUrl = applicationForm.ImageUrl
                    };
                    return applicant;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }



        // 2. Get Applicant Information By ApplicantId
        public async Task<ApplicationForm> GetApplicantInfo(string applicantId)
        {
            if (_context != null)
            {
                return await _context.ApplicationForm.Where(a => a.ApplicantId == applicantId).FirstOrDefaultAsync();
            }
            return null;
        }



        // 3. Get Applicant List By Id
        public async Task<ApplicationForm> GetApplicant(int id)
        {
            if (ApplicationFormExists(id))
            {
                return await _context.ApplicationForm.FirstOrDefaultAsync(s => s.Id == id);
            }
            return null;
        }




        // 4. Get All Applicant List Current Year
        public IEnumerable<ApplicationForm> GetCurrentYearApplicantList()
        {
            if (_context != null)
            {
                return _context.ApplicationForm.Where(a => a.ApplingDate.Year == DateTime.Now.Year).ToList();
            }
            return null;
        }



        // 5. Get All Applicant List Current Year Branch Wise
        public IEnumerable<ApplicationForm> GetCurrentYearApplicantListBranchWise(int branchId)
        {
            if (_context != null)
            {
                List<ApplicationForm> applicantList = new List<ApplicationForm>();
                var branchList = _context.BranchClass.Where(b => b.BranchId == branchId).ToList();
                if (branchList.Count() > 0)
                {
                    foreach (var br in branchList)
                    {
                        var applicant = this.GetCurrentYearApplicantList().Where(a => a.BranchClassId == br.Id).ToList();
                        if (applicant != null)
                        {
                            applicantList.AddRange(applicant);
                        }
                    }
                    return applicantList.ToList();
                }
                return null;
            }
            return null;
        }



        // 6. Get All Applicant List Current Year Branch Class Wise
        public IEnumerable<ApplicationForm> GetCurrentYearApplicantListBranchClassWise(int branchId, int classId)
        {
            if (_context != null)
            {
                List<ApplicationForm> applicantList = new List<ApplicationForm>();
                var branchClassList = _context.BranchClass.Where(b => b.BranchId == branchId && b.SchoolClassId == classId).ToList();
                if (branchClassList.Count() > 0)
                {
                    foreach (var bcl in branchClassList)
                    {
                        var applicant = this.GetCurrentYearApplicantList().Where(a => a.BranchClassId == bcl.Id).ToList();
                        if (applicant != null)
                        {
                            applicantList.AddRange(applicant);
                        }
                    }
                    return applicantList.ToList();
                }
                return null;
            }
            return null;
        }



        // 7. Delete ApplicationForm
        public async Task<int> DeleteApplication(int id)
        {
            int result = 0;

            if (_context != null)
            {
                try
                {
                    //Find the ApplicationForm for specific ApplicationForm id
                    var applicationForm = await _context.ApplicationForm.FindAsync(id);
                    if (applicationForm != null)
                    {
                        //Delete that ApplicationForm
                        _context.ApplicationForm.Remove(applicationForm);

                        //Commit the transaction
                        result = await _context.SaveChangesAsync();
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
            return 0;

        }



    }
}
