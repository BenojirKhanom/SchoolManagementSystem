using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class RulesRegulationRepository : IRulesRegulationRepository
    {
        private readonly ApplicationDbContext _context;
        public RulesRegulationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RulesRegulation>> GetAllRulesRegulation()
        {
            return await _context.RulesRegulation.ToListAsync();
        }

        public async Task<RulesRegulation> GetRulesRegulation(int id)
        {
            if (RulesRegulationExists(id))
            {
                return await _context.RulesRegulation.FindAsync(id);
            }
            return null;
        }

        public async Task<RulesRegulation> SaveRulesRegulation(RulesRegulation RulesRegulation)
        {
            if (RulesRegulation.Id == 0)
            {
                _context.RulesRegulation.Add(RulesRegulation);
            }
            else
            {
                RulesRegulation rr = _context.RulesRegulation.Find(RulesRegulation.Id);

                if (rr != null)
                {
                    //Update that PoliceStation
                    rr.RuleDetails = RulesRegulation.RuleDetails;
                    rr.BranchId = RulesRegulation.BranchId;
                    _context.RulesRegulation.Update(rr);
                }
            }
            try
            {
                await _context.SaveChangesAsync();
                return RulesRegulation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RulesRegulation> DeleteRulesRegulation(int id)
        {
            RulesRegulation rr = _context.RulesRegulation.Find(id);
            if (rr != null)
            {
                _context.RulesRegulation.Remove(rr);
            }
            try
            {
                await _context.SaveChangesAsync();
                return rr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool RulesRegulationExists(int id)
        {
            return _context.RulesRegulation.Any(e => e.Id == id);
        }


        public IEnumerable<RulesRegulation> GetAllBranchWiseRules(int BranchId)
        {
            var BranchRules = _context.RulesRegulation.Where(w => w.Id == BranchId);

            return BranchRules.ToList();
        }








    }
}
