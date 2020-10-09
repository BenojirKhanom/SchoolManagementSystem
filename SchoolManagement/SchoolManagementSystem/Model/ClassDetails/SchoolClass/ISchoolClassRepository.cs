using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public interface ISchoolClassRepository
    {
        IEnumerable<SchoolClass> GetAllSchoolClass();

        SchoolClass GetSchoolClass(int id);

        SchoolClass SaveSchoolClass(SchoolClass schoolClass);

        SchoolClass DeleteSchoolClass(int id);


        bool SchoolClassExists(int id);
    }
}
