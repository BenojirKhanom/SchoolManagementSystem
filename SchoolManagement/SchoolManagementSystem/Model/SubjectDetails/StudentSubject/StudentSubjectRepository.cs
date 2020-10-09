using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public class StudentSubjectRepository : IStudentSubjectRepository
    {
        ApplicationDbContext _context;
        public StudentSubjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<StudentSubject> AddStudentSubject(StudentSubject model)
        {
           throw new NotImplementedException();
        }

        public async Task<StudentSubject> DeleteStudentSubjectt(int id)
        {
            if(StudentSubjectExists(id))
            {
                var clr = await _context.StudentSubject.FindAsync(id);
                if(clr != null)
                {
                    _context.StudentSubject.Remove(clr);
                }
                try
                {
                    await _context.SaveChangesAsync();
                    return clr;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                
            }
            return null;
        }

        public async Task<IEnumerable<StudentSubject>> GetAllStudentSubjects()
        {
            if(_context != null)
            {
                return await _context.StudentSubject.ToListAsync();
            }
            return null;
        }

        public async Task<StudentSubject> GetStudentSubject(int id)
        {
            if(StudentSubjectExists(id))
            {
                var studentSubject = await _context.StudentSubject.FindAsync(id);
                return studentSubject;
            }
            return null;
        }

        public bool StudentSubjectExists(int id)
        {
            return _context.StudentSubject.Any(s => s.Id == id);
        }
    }
}
