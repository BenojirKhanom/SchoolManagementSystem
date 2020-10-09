using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly ApplicationDbContext _context;
        public ShiftRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get All Shift
        public IEnumerable<Shift> GetAllShift()
        {
            return _context.Shift.ToList();
        }

        //Get By Id
        public Shift GetShift(int id)
        {
            if (ShiftExists(id))
            {
                return _context.Shift.Where(s => s.Id == id).FirstOrDefault();
            }
            return null;
        }

        //Save or Edit Shift
        public  Shift SaveShift(Shift shift)
        {           
            if (shift.Id == 0)
            {
                _context.Shift.Add(shift);
                _context.SaveChanges();
                return shift;
            }
            else
            {
                Shift shi = _context.Shift.Find(shift.Id);
                if(shi != null)
                {
                    shi.ShiftName = shift.ShiftName;
                    _context.Shift.Update(shi);
                    _context.SaveChanges();
                    return shi;
                }               
            }
            return null;
        }

        //Delete Shift
        public Shift DeleteShift(int id)
        {
            Shift shi = _context.Shift.Find(id);

            if (shi != null)
            {
                _context.Shift.Remove(shi);
                _context.SaveChanges();
                return shi;
            }
            return null;
        }

        private bool ShiftExists(int id)
        {
            return _context.Shift.Any(s => s.Id == id);
        }
    }
}
