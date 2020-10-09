using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public class RoomRepository : IRoomRepository
    {
        ApplicationDbContext _context;
        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Room> GetAllRoom(int branchId)
        {
            var roomList = _context.Room.Where(r => r.BranchId == branchId).ToList();
            if (roomList.Count() >0 )
            {
                return roomList;
            }
            return null;
        }

        public Room GetRoom(int id)
        {
            var room =  _context.Room.Find(id);
            if (room != null)
            {
                return room;
            }
            return null;
        }
       public IEnumerable<Room> GetAllAssignRoom(int branchId, int shiftId)
        {
            List<Room> roomList = new List<Room>();
            var branchClassList = _context.BranchClass.Where(b => b.BranchId == branchId && b.ShiftId == shiftId).ToList();
            if (branchClassList.Count() > 0)
            {
                foreach (BranchClass brc in branchClassList)
                {
                    var SectionList = _context.Section.Where(b => b.BranchClassId == brc.Id).ToList();
                    if (SectionList.Count() > 0)
                    {
                        foreach (Section cr in SectionList)
                        {
                            Room room = _context.Room.Where(r => r.Id == cr.RoomId).FirstOrDefault();
                            roomList.Add(room);
                        }
                    }
                }
                return roomList;
            }
            return null;
        }

        public IEnumerable<Room> GetAllUnAssignRoom(int branchId, int shiftId)
        {
            List<Room> unAssignRoomList = new List<Room>();
            List<Room> assignRoomList = GetAllAssignRoom(branchId, shiftId).ToList();
            List<Room> allRoomList = _context.Room.Where(w => w.BranchId == branchId).ToList();
            var result = allRoomList.Where(p => !assignRoomList.Any(p2 => p2.Id == p.Id));
            if(result.Count() > 0)
            {
                return result;
            }           
            return null;
        }



        public Room DeleteRoom(int id)
        {
            Room dbEntry = _context.Room.Find(id);

            if (dbEntry != null)
            {
                _context.Room.Remove(dbEntry);
                _context.SaveChangesAsync();
                return dbEntry;
            }
            return null;

        }




        public async Task<Room> AddNewRoom(Room room)
        {
            var roomExist = _context.Room.Where(r => r.BranchId == room.BranchId && r.RoomName == room.RoomName).FirstOrDefault();
            if (roomExist == null)
            {
                _context.Room.Add(room);
                await _context.SaveChangesAsync();
                return room;
            }
            else
            {
                roomExist.RoomName = room.RoomName;
                roomExist.SitCapacity = room.SitCapacity;               
                _context.Room.Update(roomExist);
                await _context.SaveChangesAsync();
                return roomExist;
            }     
        }
        public bool RoomExists(int id)
        {
            return _context.Room.Any(e => e.Id == id);
        }
    }
}
