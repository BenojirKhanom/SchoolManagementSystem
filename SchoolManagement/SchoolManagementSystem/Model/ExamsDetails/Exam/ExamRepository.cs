using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class ExamRepository : IExamRepository
    {

        private readonly ApplicationDbContext _context;
        public ExamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Exam> GetAllExam(int branchId, int year)
        {
            var examList = _context.Exam.Where(e => e.BranchId == branchId
                                               && e.StartDate.Year == year).ToList();
            if (examList.Count() > 0)
            {
                return examList;
            }
            return null;
        }

        public Exam getExam(int id)
        {
            if (ExamExists(id))
            {
                return _context.Exam.Find(id);
            }
            return null;
        }

        public async Task<Exam> AddNewExam(Exam exam)
        {
            var existExam = _context.Exam.Where(d => d.BranchId == exam.BranchId
                                                && d.IsActive == true).FirstOrDefault();
            if(existExam != null)
            {
                return null;
            }            
            if (exam.Id == 0)
            {
                _context.Exam.Add(exam);
                var result = await _context.SaveChangesAsync();
                return exam;

            }
            else
            {
                Exam exa = _context.Exam.Find(exam.Id);

                if (exa != null)
                {

                    exa.ExamType = exam.ExamType;
                    exa.ExamDiscription = exam.ExamDiscription;
                    exa.StartDate = exam.StartDate;
                    exa.EndDate = exam.EndDate;
                    exa.PassingRate = exam.PassingRate;
                    exa.IsActive = exam.IsActive;
                    exa.BranchId = exam.BranchId;
                    _context.Exam.Update(exa);
                    var result =await  _context.SaveChangesAsync();
                    return exa;
                }
            }
            return null;
        }

        public async Task<Exam> DeleteExam(int id)
        {
            Exam exa = _context.Exam.Find(id);
            if (exa != null)
            {
                try
                {
                    _context.Exam.Remove(exa);
                    var res = await _context.SaveChangesAsync();
                    return exa;
                }
                catch (Exception ex)
                {
                    throw ex;
                }              
            }
            return null;
        }



        private bool ExamExists(int id)
        {
            return _context.Exam.Any(e => e.Id == id);
        }
    }
}
