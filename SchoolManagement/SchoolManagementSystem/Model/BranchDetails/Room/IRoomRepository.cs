using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public interface IRoomRepository
    {
        public IEnumerable<Room> GetAllRoom(int branchId);
        public Room GetRoom(int id);
        public IEnumerable<Room> GetAllAssignRoom(int branchId, int shiftId);
        public IEnumerable<Room> GetAllUnAssignRoom(int branchId, int shiftId);
        public Room DeleteRoom(int id);
        public Task<Room> AddNewRoom(Room room);

        public bool RoomExists(int id);
    }
}
