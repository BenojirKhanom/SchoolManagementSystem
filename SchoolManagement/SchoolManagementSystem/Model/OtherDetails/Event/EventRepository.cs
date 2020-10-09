using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public class EventRepository : IEventRepository
    {
        ApplicationDbContext _context;
        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Event> DeleteEvent(int id)
        {
            Event dbEntry = _context.Event.Find(id);

            if (dbEntry != null)
            {
                //Delete that Event
                _context.Event.Remove(dbEntry);

            }
            //Commit the transaction
            await _context.SaveChangesAsync();

            return dbEntry;

        }

        public async Task<IEnumerable<Event>> GetAllEvent()
        {
            if (_context != null)
            {
                return await _context.Event.ToListAsync();
            }
            return null;
        }

        public async Task<Event> GetEvent(int id)
        {
            var eve = await _context.Event.FindAsync(id);
            return eve;
        }

        public async Task<int> AddNewEvent(Event eve)
        {

            if (eve.Id == 0)
            {
                // Add new Event
                _context.Event.Add(eve);

            }
            else
            {
                // Find Event is already exit in database?
                Event dbEntry = _context.Event.Find(eve.Id);

                if (dbEntry != null)
                {
                    //Update that Event
                    dbEntry.EventName = eve.EventName;
                    dbEntry.Branch = eve.Branch;
                    dbEntry.EndDate = eve.EndDate;
                    //dbEntry.EventController = eve.EventController;
                    dbEntry.ImageUrl = eve.ImageUrl;
                    dbEntry.StartDate = eve.StartDate;
                    dbEntry.Venue = eve.Venue;

                    _context.Event.Update(dbEntry);

                }
            }
            //Commit the transaction
            await _context.SaveChangesAsync();

            return eve.Id;

        }


        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.Id == id);
        }

        
        public async Task<List<Event>> GetAllEventByEarlierDateTime()
        {
            try
            {
                var ee = await _context.Event.OrderByDescending(e => e.StartDate).ToListAsync();
                return ee;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }



        
        public IEnumerable<Event> GetYearWiseAllEvent(int BranchId, int year)
        {
            var eventNotice = _context.Event.Where(w => w.BranchId == BranchId && w.StartDate.Year == year || w.EndDate.Year == year);


            return eventNotice.ToList();

        }

        public IEnumerable<Event> GetMonthWiseAllEvent(int BranchId, int year, int month)
        {
            var eventNotice = _context.Event.Where(w => w.BranchId == BranchId && w.StartDate.Year == year && w.StartDate.Month == month || w.EndDate.Month == month);


            return eventNotice.ToList();
        }

        public IEnumerable<Event> GetDateWiseAllEvent(int BranchId, int year, int month, int date)
        {
            var eventNotice = _context.Event.Where(w => w.BranchId == BranchId && w.StartDate.Year == year && w.StartDate.Month == month && w.StartDate.Day == date || w.EndDate.Day == date);


            return eventNotice.ToList();
        }
    }
}
