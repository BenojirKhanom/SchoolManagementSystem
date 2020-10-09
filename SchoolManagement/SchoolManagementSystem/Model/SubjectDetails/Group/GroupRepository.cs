using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _context;
        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Group> GetGroup(int id)
        {
            if (GroupExists(id))
            {
                return await _context.Group.FindAsync(id);
            }
            return null;
        }

        public async Task<IEnumerable<Group>> GetAllGroups()
        {
            return await _context.Group.ToListAsync();
        }

        public async Task<Group> DeleteGroup(int id)
        {
            Group g =  _context.Group.Find(id);
            if (g != null)
            {
                 _context.Group.Remove(g);
            }
            try
            {
                await _context.SaveChangesAsync();
                return g;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<int> SaveGroup(Group model)
        {
            if (model.Id == 0)
            {

                _context.Group.Add(model);
            }
            else
            {
                Group g = _context.Group.Find(model.Id);

                if (g != null)
                {
                    //Update that SubjectGroup
                    g.GroupName = model.GroupName;

                    _context.Group.Update(g);
                }
            }
            try
            {
                var result = _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool GroupExists(int id)
        {
            return _context.Group.Any(e => e.Id == id);
        }
    }
}
