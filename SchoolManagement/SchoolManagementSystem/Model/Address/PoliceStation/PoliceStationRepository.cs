using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class PoliceStationRepository : IPoliceStationRepository
    {
        private readonly ApplicationDbContext _context;
        public PoliceStationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PoliceStation>> GetAllPoliceStation()
        {
            return await _context.PoliceStation.ToListAsync();
        }

        public async Task<PoliceStation> GetPoliceStation(int id)
        {
            if (PoliceStationExists(id))
            {
                return await _context.PoliceStation.FindAsync(id);
            }
            return null;
        }

        public async Task<PoliceStation> SavePoliceStation(PoliceStation policeStation)
        {
            if (policeStation.Id == 0)
            {
                _context.PoliceStation.Add(policeStation);
            }
            else
            {
                PoliceStation pol = _context.PoliceStation.Find(policeStation.Id);

                if (pol != null)
                {
                    //Update that PoliceStation
                    pol.PoliceStationName = policeStation.PoliceStationName;
                    pol.DistrictId = policeStation.DistrictId;
                    _context.PoliceStation.Update(pol);
                }
            }
            try
            {
                await _context.SaveChangesAsync();
                return policeStation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<PoliceStation> DeletePoliceStation(int id)
        {
            PoliceStation pol = _context.PoliceStation.Find(id);
            if (pol != null)
            {
                _context.PoliceStation.Remove(pol);
            }
            try
            {
                await _context.SaveChangesAsync();
                return pol;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool PoliceStationExists(int id)
        {
            return _context.PoliceStation.Any(e => e.Id == id);
        }
    }
}
