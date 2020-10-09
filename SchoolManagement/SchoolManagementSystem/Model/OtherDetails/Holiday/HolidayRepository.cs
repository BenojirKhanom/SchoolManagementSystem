using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public class HolidayRepository : IHolidayRepository
    {
        ApplicationDbContext _context;
        public HolidayRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Holiday> DeleteHoliday(int id)
        {
            Holiday dbEntry = _context.Holiday.Find(id);

            if (dbEntry != null)
            {
                //Delete that Holiday
                _context.Holiday.Remove(dbEntry);

            }
            //Commit the transaction
            await _context.SaveChangesAsync();

            return dbEntry;

        }

        public async Task<IEnumerable<Holiday>> GetAllHolidays()
        {
            if (_context != null)
            {
                return await _context.Holiday.ToListAsync();
            }
            return null;
        }

        public async Task<Holiday> GetHoliday(int id)
        {
            var holiday = await _context.Holiday.FindAsync(id);
            return holiday;
        }

        public async Task<int> AddNewHoliday(Holiday holiday)
        {

            if (holiday.Id == 0)
            {
                // Add new Holiday
                _context.Holiday.Add(holiday);

            }
            else
            {
                // Find Holiday is already exit in database?
                Holiday dbEntry = _context.Holiday.Find(holiday.Id);

                if (dbEntry != null)
                {
                    //Update that Holiday
                    dbEntry.HolidayName = holiday.HolidayName;
                    dbEntry.EndDate = holiday.EndDate;
                    dbEntry.NumberOfDay = holiday.NumberOfDay;
                    dbEntry.StartDate = holiday.StartDate;
                   
                    _context.Holiday.Update(dbEntry);

                }
            }
            //Commit the transaction
            await _context.SaveChangesAsync();

            return holiday.Id;

        }


        private bool HolidayExists(int id)
        {
            return _context.Holiday.Any(e => e.Id == id);
        }
       
        public async Task<IEnumerable<Holiday>> GetDateWiseAllHoliday(int year, int? month, int? day)
        {
            List<Holiday> holidays = await _context.Holiday.Where(te => (te.StartDate.Year == year && te.StartDate.Month == month && te.StartDate.Day == day) || (te.StartDate.Year == year && te.StartDate.Month == month) || te.StartDate.Year == year).ToListAsync();
            return holidays;
        }
    }
}
