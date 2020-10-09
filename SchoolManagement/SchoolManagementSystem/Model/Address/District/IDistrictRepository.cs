using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public interface IDistrictRepository
    {
        IEnumerable<District> GetAllDistrict();
        District getDistrict(int id);
        int DeleteDistrict(int id);
        Task<int> AddNewDistrict(District district);
    }
}
