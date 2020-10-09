using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public interface IClassRoutineRepository
    {
        public Task<IEnumerable<ClassRoutine>> GetClassRoutines();
        public Task<ClassRoutine> GetClassRoutine(int id);
        public Task<ClassRoutine> UpdateClassRoutine(int id, ClassRoutine classRoutine);
        public Task<ClassRoutine> CreateClassRoutine(ClassRoutine classRoutine);
        public Task<ClassRoutine> DeleteClassRoutine(int id);
    }
}
