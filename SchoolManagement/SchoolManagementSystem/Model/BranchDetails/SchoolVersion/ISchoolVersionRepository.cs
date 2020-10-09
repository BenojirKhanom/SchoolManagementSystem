using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public interface ISchoolVersionRepository
    {
        IEnumerable<SchoolVersion> GetAllSchoolVersion();

        SchoolVersion GetSchoolVersion(int id);

         SchoolVersion SaveSchoolVersion(SchoolVersion schoolVersion);

        SchoolVersion DeleteSchoolVersion(int id);


        bool SchoolVersionExists(int id);
    }
}
