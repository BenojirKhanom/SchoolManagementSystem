using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public interface IDesignationRepository
    {
        public Task<IEnumerable<Designation>> GetAllDesignations();
        public Task<Designation> GetDesignation(int id);
        Task<int> SaveDesignation(Designation designation);
        Task<Designation> DeleteDesignation(int? id);
    }
}
