using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class ExamResultRepository : IExamResultRepository
    {
        private readonly ApplicationDbContext _context;
        public ExamResultRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ExamResult> GetExamResultOfStudent(int examId, int studentId)
        {
            var result = await _context.ExamResult.Where(w => w.ExamId == examId && w.StudentId == studentId).FirstOrDefaultAsync();
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<ExamResult>> GetAllExamResultOfSection(int examId, int sectionId)
        {
            var result = await _context.ExamResult.Where(w => w.ExamId == examId && w.SectionId == sectionId).ToListAsync();
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<ExamResult>> GetAllExamResultOfClass(int examId, int schoolClassId)
        {
            List<ExamResult> examResults = new List<ExamResult>();
            var exam = _context.Exam.Where(e => e.Id == examId).FirstOrDefault();
            if (exam == null)
            {
                return null;
            }
            var branchClass = _context.BranchClass.Where(bc => bc.BranchId == exam.BranchId && bc.SchoolClassId == schoolClassId).FirstOrDefault();
            if (branchClass == null)
            {
                return null;
            }
            var sectionList = _context.Section.Where(s => s.BranchClassId == branchClass.Id).ToList();
            if (sectionList.Count() > 0)
            {
                foreach (Section section in sectionList)
                {
                    var resultList = await _context.ExamResult.Where(e => e.ExamId == examId && e.SectionId == section.Id).ToListAsync();
                    if (resultList != null)
                    {
                        examResults.AddRange(resultList);
                    }
                }
                return examResults;
            }
            return null;
        }



        public async Task<ExamResult> DeleteExamResult(int id)
        {
            ExamResult er = _context.ExamResult.Find(id);
            if (er != null)
            {
                _context.ExamResult.Remove(er);
            }
            try
            {
                await _context.SaveChangesAsync();
                return er;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExamResultExists(int id)
        {
            return _context.ExamResult.Any(e => e.Id == id);
        }
        public ExamResultPoint getGradePoint(int branchId, double point)
        {
            List<ExamResultPoint> pointList = _context.ExamResultPoint.Where(p => p.BranchId == branchId
                                                        && p.Point <= point).ToList();
            if (pointList != null)
            {
                pointList.Sort((a, b) => a.Point.CompareTo(b.Point));
                pointList.Reverse();
                return pointList[0];
            }
            return null;
        }

        public string GenerateExamResult(ResultGenerate resultGenerate)
        {
            var exam = _context.Exam.Where(e => e.Id == resultGenerate.ExamId).FirstOrDefault();
            List<ExamMark> examMarksList = new List<ExamMark>();


            Section section = _context.Section.Where(s => s.Id == resultGenerate.SectionId).FirstOrDefault();
            if (section != null)
            {
                List<Student> studentListInSession = _context.Student.Where(st => st.SectionId == section.Id).ToList();
                if (studentListInSession.Count() > 0)
                {
                    string isUpdateOrInsert = "";
                    foreach (Student studentInSection in studentListInSession)
                    {
                        List<ExamMark> examMarkListForStudent = _context.ExamMark.Where(em => em.ExamId == resultGenerate.ExamId
                                                                && em.StudentId == studentInSection.Id).ToList();

                        ExamResult examResult = new ExamResult();
                        int totalMark = 0;
                        float obtainMark = 0;
                        bool isPassed = true;
                        double greadPoint = 0.00;

                        foreach (ExamMark mark in examMarkListForStudent)
                        {
                            var rotine = _context.ExamRoutine.Where(r => r.Id == mark.ExamRoutineId).FirstOrDefault();
                            totalMark += rotine.TotalNumber;
                            obtainMark += mark.ObtainMark;
                            if (isPassed)
                            {
                                isPassed = mark.ResultStatus;
                            }
                            greadPoint += mark.Point;
                        }
                        examResult.ResultPublishDate = DateTime.Now;
                        examResult.TotalMark = totalMark;
                        examResult.TotalObtainMark = obtainMark;
                        examResult.ResultStatus = isPassed;
                        examResult.Point = Math.Round(greadPoint / examMarkListForStudent.Count(), 2);

                        ExamResultPoint resultPoint = getGradePoint(exam.BranchId, examResult.Point);

                        if (resultPoint != null)
                        {
                            if (examResult.ResultStatus)
                            {
                                examResult.Grade = resultPoint.Grade;
                            }
                            else
                            {
                                examResult.Grade = "F";
                            }
                            examResult.Note = resultPoint.Note;
                        }
                        else
                        {
                            examResult.Grade = "##";
                            examResult.Note = "Point Setting Invalid";
                        }


                        examResult.TotalPresent = examMarkListForStudent.Count();

                        examResult.ExamId = resultGenerate.ExamId;
                        examResult.SectionId = resultGenerate.SectionId;
                        examResult.StudentId = examMarkListForStudent[0].StudentId;


                        ExamResult existExamResult = _context.ExamResult.Where(ee => ee.ExamId == resultGenerate.ExamId
                                                      && ee.SectionId == resultGenerate.SectionId
                                                      && ee.StudentId == examMarkListForStudent[0].StudentId).FirstOrDefault();

                        if (existExamResult == null)
                        {
                            _context.ExamResult.Add(examResult);
                            _context.SaveChanges();
                            isUpdateOrInsert = "Inserted ";
                        }
                        else
                        {


                            existExamResult.TotalMark = examResult.TotalMark;
                            existExamResult.TotalObtainMark = examResult.TotalObtainMark;
                            existExamResult.ResultStatus = examResult.ResultStatus;
                            existExamResult.Point = examResult.Point;
                            existExamResult.Grade = examResult.Grade;
                            existExamResult.Note = examResult.Note;
                            existExamResult.TotalPresent = examResult.TotalPresent;

                            _context.ExamResult.Update(existExamResult);
                            _context.SaveChanges();

                            isUpdateOrInsert = "Updated ";
                        }

                    }

                    var resultList = _context.ExamResult.Where(er => er.ExamId == resultGenerate.ExamId
                                                        && er.SectionId == resultGenerate.SectionId).ToList();

                    if (resultList.Count() > 0)
                    {
                        resultList.Sort((a, b) => a.TotalObtainMark.CompareTo(b.TotalObtainMark));
                        resultList.Reverse();
                        var highestscore = resultList[0].TotalObtainMark;
                        var position = 0;
                        foreach (ExamResult er in resultList)
                        {
                            er.HighestMark = highestscore;
                            er.Position = position + 1;
                            position = (int)er.Position;
                        }
                        _context.ExamResult.UpdateRange(resultList);
                        _context.SaveChanges();

                        return "Successfully " + isUpdateOrInsert + resultList.Count() + " Result for Section :" + section.SectionName;
                    }
                    return " Total " + studentListInSession.Count() + " student result " + isUpdateOrInsert + " but failed to Set height and position for students.";
                }

            }
            return "This Session not exist in branch.";
        }


    }

}