using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public interface IRulesRegulationRepository
    {
        Task<IEnumerable<RulesRegulation>> GetAllRulesRegulation();

        Task<RulesRegulation> GetRulesRegulation(int id);

        Task<RulesRegulation> SaveRulesRegulation(RulesRegulation RulesRegulation);

        Task<RulesRegulation> DeleteRulesRegulation(int id);
        public IEnumerable<RulesRegulation> GetAllBranchWiseRules(int BranchId);


        bool RulesRegulationExists(int id);
    }
}
