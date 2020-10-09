using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class DivisionRepository : IDivisionRepository
    {
        private readonly ApplicationDbContext _context;
        public DivisionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<int> AddNewDivision(Division division)
        {
            if (division.Id == 0)
            {
                _context.Division.Add(division);
            }
            else
            {
                Division div = _context.Division.Find(division.Id);

                if (div != null)
                {

                    div.DivisionName = division.DivisionName;
                    div.CountryId = division.CountryId;



                    _context.Division.Update(div);
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

        public int DeleteDivision(int id)
        {
            Division div = _context.Division.Find(id);
            if (div != null)
            {
                _context.Division.Remove(div);
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

        public IEnumerable<Division> GetAllDivision()
        {
            return _context.Division.ToList();
        }

        public Division getDivision(int id)
        {
            if (DivisionExists(id))
            {
                return this.GetAllDivision().Where(div => div.Id == id).FirstOrDefault();
            }
            return null;
        }

        private bool DivisionExists(int id)
        {
            return _context.Division.Any(d => d.Id == id);
        }
    }

}
