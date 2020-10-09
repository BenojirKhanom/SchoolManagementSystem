using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class DistrictRepository : IDistrictRepository
    {
        private readonly ApplicationDbContext _context;
        public DistrictRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<int> AddNewDistrict(District district)
        {
            if (district.Id == 0)
            {
                _context.District.Add(district);
            }
            else
            {
                District dis = _context.District.Find(district.Id);

                if (dis != null)
                {

                    dis.DistrictName = district.DistrictName;
                    dis.DivisionId = district.DivisionId;



                    _context.District.Update(dis);
                }
            }
            try
            {
                var result = _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteDistrict(int id)
        {
            District dis = _context.District.Find(id);
            if (dis != null)
            {
                _context.District.Remove(dis);
            }
            try
            {
                var res = _context.SaveChanges();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<District> GetAllDistrict()
        {
            return _context.District.ToList();
        }

        public District getDistrict(int id)
        {
            if (DistrictExists(id))
            {
                return this.GetAllDistrict().Where(dis => dis.Id == id).FirstOrDefault();
            }
            return null;
        }
        private bool DistrictExists(int id)
        {
            return _context.District.Any(d => d.Id == id);
        }
    }
}
