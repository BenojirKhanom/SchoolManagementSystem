using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public class NoticeBoardRepository : INoticeBoardRepository
    {
        ApplicationDbContext _context;
        public NoticeBoardRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<NoticeBoard>> GetAllNoticeBoards()
        {
            if (_context != null)
            {
                return await _context.NoticeBoard.ToListAsync();
            }

            return null;
        }

        public async Task<NoticeBoard> GetNoticeBoard(int id)
        {
            if (NoticeBoardExists(id))
            {
                var notice = await _context.NoticeBoard.FindAsync(id);
                return notice;
            }
            return null;
        }
        public async Task<int> AddNoticeBoard(NoticeBoard noticeBoard)
        {
            if (_context != null)
            {
                await _context.NoticeBoard.AddAsync(noticeBoard);
                await _context.SaveChangesAsync();

                return noticeBoard.Id;
            }

            return 0;
        }

        public async Task<int> DeleteNoticeBoard(int? id)
        {
            int result = 0;

            if (_context != null)
            {

                var notice = await _context.NoticeBoard.FindAsync(id);

                if (notice != null)
                {

                    _context.NoticeBoard.Remove(notice);


                    result = await _context.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }



        public async Task UpdateNoticeBoard(NoticeBoard noticeBoard)
        {
            if (_context != null)
            {

                _context.NoticeBoard.Update(noticeBoard);


                await _context.SaveChangesAsync();
            }
        }

        private bool NoticeBoardExists(int id)
        {
            return _context.NoticeBoard.Any(e => e.Id == id);
        }

       
        public IEnumerable<NoticeBoard> GetAllNoticeByEarlierDateTime()
        {
            var notice = _context.NoticeBoard.OrderByDescending(N => N.PublishDate);
            return notice;
        }


        public IEnumerable<NoticeBoard> GetAllBranchWiseNotice(int BranchId, int year)
        {

            var BranchNotice = _context.NoticeBoard.Where(w => w.BranchId == BranchId && w.PublishDate.Year == year);

            return BranchNotice.ToList();

        }
    }
}
