using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public interface INoticeBoardRepository
    {
        public Task<List<NoticeBoard>> GetAllNoticeBoards();

        public Task<NoticeBoard> GetNoticeBoard(int id);

        public Task<int> AddNoticeBoard(NoticeBoard noticeBoard);

        public Task UpdateNoticeBoard(NoticeBoard noticeBoard);
        public Task<int> DeleteNoticeBoard(int? id);
        public IEnumerable<NoticeBoard> GetAllNoticeByEarlierDateTime();
        public IEnumerable<NoticeBoard> GetAllBranchWiseNotice(int BranchId, int year);
    }

}
