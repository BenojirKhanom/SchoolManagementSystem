using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public interface IDivisionRepository
    {
        IEnumerable<Division> GetAllDivision();
        Division getDivision(int id);
        int DeleteDivision(int id);
        Task<int> AddNewDivision(Division division);
    }
}
