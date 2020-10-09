using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class ClassRoutineRepository : IClassRoutineRepository
    {
        private readonly ApplicationDbContext _context;
        public ClassRoutineRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClassRoutine>> GetClassRoutines()
        {
            if (_context != null)
            {
                return await _context.ClassRoutine.ToListAsync();
            }
            return null;
        }
        public async Task<ClassRoutine> GetClassRoutine(int id)
        {
            if (ClassRoutineExists(id))
            {
                var classRoom = await _context.ClassRoutine.FindAsync(id);
                return classRoom;
            }
            return null;
        }
        public async Task<ClassRoutine> CreateClassRoutine(ClassRoutine classRoutine)
        {
            if (classRoutine.Id == 0)
            {
                _context.ClassRoutine.Add(classRoutine);
            }
            try
            {
                await _context.SaveChangesAsync();
                return classRoutine;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ClassRoutine> UpdateClassRoutine(int id, ClassRoutine classRoutine)
        {
            ClassRoutine clr = _context.ClassRoutine.Find(classRoutine.Id);

            if (clr != null)
            {
                //Update that educationSystem
                clr.DayOfWeek = classRoutine.DayOfWeek;
                clr.StartTime = classRoutine.StartTime;
                clr.EndTime = classRoutine.EndTime;
                clr.PeriodNumber = classRoutine.PeriodNumber;
                clr.ClassDuration = classRoutine.ClassDuration;
                clr.SubjectId = classRoutine.SubjectId;
                clr.TeacherId = classRoutine.TeacherId;

                _context.ClassRoutine.Update(clr);
            }
            try
            {
                var result = await _context.SaveChangesAsync();
                return classRoutine;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ClassRoutine> DeleteClassRoutine(int id)
        {
            var clr = await _context.ClassRoutine.FindAsync(id);
            if (clr != null)
            {
                _context.ClassRoutine.Remove(clr);
            }
            try
            {
                var res = await _context.SaveChangesAsync();
                return clr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool ClassRoutineExists(int id)
        {
            return _context.ClassRoutine.Any(e => e.Id == id);
        }
    }
}
