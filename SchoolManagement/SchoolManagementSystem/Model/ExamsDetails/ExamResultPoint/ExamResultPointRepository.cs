using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class ExamResultPointRepository : IExamResultPointRepository
    {

        private readonly ApplicationDbContext _context;
        public ExamResultPointRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ExamResultPoint> GetAllExamResultPointByBranch(int branchId)
        {
            List<ExamResultPoint> examResultPoints = _context.ExamResultPoint.Where(p => p.BranchId == branchId).ToList();
            if(examResultPoints.Count() > 0)
            {
                return examResultPoints;
            }
            return null;
        }
        public ExamResultPoint GetExamMark(int id)
        {
            ExamResultPoint examResultPoint = _context.ExamResultPoint.Where(p => p.Id == id).FirstOrDefault();
            if (examResultPoint != null)
            {
                return examResultPoint;
            }
            return null;
        }


        public ExamResultPoint DeleteExamMark(int id)
        {
            ExamResultPoint edu = _context.ExamResultPoint.Find(id);
            if (edu != null)
            {
                _context.ExamResultPoint.Remove(edu);
                _context.SaveChanges();
                return edu;
            }
            return null;
        }

        public bool ExamMarkExists(int id)
        {
            return _context.ExamResultPoint.Any(e => e.Id == id);
        }

        public string SaveExamMark(ExamResultPoint resultPoint)
        {
            var pointExist = _context.ExamResultPoint.Where(p => p.BranchId == resultPoint.BranchId
                                       && p.Point == resultPoint.Point || p.Grade == resultPoint.Grade
                                       || p.MaximumMark == resultPoint.MaximumMark || p.MinimumMark == resultPoint.MinimumMark).FirstOrDefault();
            var isValid = resultPoint.MaximumMark > resultPoint.MinimumMark;
            if (!isValid)
            {
                return "Maximun number and Minimum number is not valid.";
            }

            if(resultPoint.Id == 0 && pointExist == null)
            {
                _context.ExamResultPoint.Add(resultPoint);
                _context.SaveChanges();

                return "Successfully Inserted new Row";
            }
            else
            {
                pointExist.MaximumMark = resultPoint.MaximumMark;
                pointExist.MinimumMark = resultPoint.MinimumMark;
                pointExist.Point = resultPoint.Point;
                pointExist.Grade = resultPoint.Grade;
                pointExist.Note = resultPoint.Note;

                _context.ExamResultPoint.Update(pointExist);
                _context.SaveChanges();

                return "Successfully Updated new Row";
            }
          
        }
    }
}
