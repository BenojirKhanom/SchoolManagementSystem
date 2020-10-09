using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public interface IPostOfficeRepository
    {
        Task<IEnumerable<PostOffice>> GetAllPostOffice();

        Task<PostOffice> GetPostOffice(int id);

        Task<PostOffice> SavePostOffice(PostOffice postOffice);

        Task<PostOffice> DeletePostOffice(int id);


        bool PostOfficeExists(int id);
    }
}
