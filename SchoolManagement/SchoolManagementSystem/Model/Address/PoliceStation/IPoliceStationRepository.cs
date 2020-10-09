using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public interface IPoliceStationRepository
    {
        Task<IEnumerable<PoliceStation>> GetAllPoliceStation();

        Task<PoliceStation> GetPoliceStation(int id);

        Task<PoliceStation> SavePoliceStation(PoliceStation policeStation);

        Task<PoliceStation> DeletePoliceStation(int id);


        bool PoliceStationExists(int id);
    }
}
