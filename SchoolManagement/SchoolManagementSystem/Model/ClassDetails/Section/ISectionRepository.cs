using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public interface ISectionRepository
    {
        IEnumerable<Section> GetAllSection(int branchId);

        public IEnumerable<Section> GetAllSectionByClass(int branchId, int classId);

        Section GetSection(int id);

        Task<Section> SaveSection(Section section);

        Section DeleteSection(int id);

        bool SectionExists(int id);
    }
}
