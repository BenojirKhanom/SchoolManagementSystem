using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public interface IGroupRepository
    {
        public Task<IEnumerable<Group>> GetAllGroups();

        public Task<Group> GetGroup(int id);
        public Task<int> SaveGroup(Group model);
        public Task<Group> DeleteGroup(int id);
    }
}
