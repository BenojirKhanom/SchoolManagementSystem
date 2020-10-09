using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{

    public interface IShiftRepository
    {
        IEnumerable<Shift> GetAllShift();
        Shift GetShift(int id);
        Shift DeleteShift(int id);
        Shift SaveShift(Shift shift);
    }

}
