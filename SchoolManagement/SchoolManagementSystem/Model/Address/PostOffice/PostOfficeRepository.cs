using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class PostOfficeRepository : IPostOfficeRepository
    {

        private readonly ApplicationDbContext _context;
        public PostOfficeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PostOffice>> GetAllPostOffice()
        {
            return await _context.PostOffice.ToListAsync();
        }

        public async Task<PostOffice> GetPostOffice(int id)
        {
            if (PostOfficeExists(id))
            {
                return await _context.PostOffice.FindAsync(id);
            }
            return null;
        }
        public async Task<PostOffice> SavePostOffice(PostOffice postOffice)
        {
            if (postOffice.Id == 0)
            {
                _context.PostOffice.Add(postOffice);
            }
            else
            {
                PostOffice pos = _context.PostOffice.Find(postOffice.Id);

                if (pos != null)
                {
                    //Update that PostOffice
                    pos.PostOfficeName = postOffice.PostOfficeName;
                    pos.PoliceStationId = postOffice.PoliceStationId;
                    _context.PostOffice.Update(pos);
                }
            }
            try
            {
                await _context.SaveChangesAsync();
                return postOffice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<PostOffice> DeletePostOffice(int id)
        {
            PostOffice pos = _context.PostOffice.Find(id);
            if (pos != null)
            {
                _context.PostOffice.Remove(pos);
            }
            try
            {
                await _context.SaveChangesAsync();
                return pos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool PostOfficeExists(int id)
        {
            return _context.PostOffice.Any(e => e.Id == id);
        }


    }
}
