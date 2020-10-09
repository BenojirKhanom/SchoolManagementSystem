using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public class ExamRoutineRepository : IExamRoutineRepository
    {
        ApplicationDbContext _context;
        public ExamRoutineRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddExamRoutine(ExamRoutine examRoutine)
        {
            if (_context != null)
            {
                await _context.ExamRoutine.AddAsync(examRoutine);
                await _context.SaveChangesAsync();

                return examRoutine.Id;
            }

            return 0;
        }

        public async Task<int> DeleteExamRoutine(int? id)
        {
            int result = 0;

            if (_context != null)
            {

                var examRoutine = await _context.ExamRoutine.FindAsync(id);

                if (examRoutine != null)
                {

                    _context.ExamRoutine.Remove(examRoutine);


                    result = await _context.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<ExamRoutine>> GetAllExamRoutines()
        {
            if (_context != null)
            {
                return await _context.ExamRoutine.ToListAsync();
            }

            return null;
        }

        public async Task<ExamRoutine> GetExamRoutine(int id)
        {
            if (ExamRoutineExists(id))
            {
                var examRoutine = await _context.ExamRoutine.FindAsync(id);
                return examRoutine;
            }
            return null;
        }

        public async Task UpdateExamRoutine(ExamRoutine examRoutine)
        {
            if (_context != null)
            {

                _context.ExamRoutine.Update(examRoutine);


                await _context.SaveChangesAsync();
            }
        }
        private bool ExamRoutineExists(int id)
        {
            return _context.ExamRoutine.Any(e => e.Id == id);
        }
    }
}
