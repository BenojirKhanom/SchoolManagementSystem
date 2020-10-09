using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllCountries();

        Task<Country> GetCountry(int? id);

        Task<int> AddCountry(Country country);

        Task<int> DeleteCountry(int? id);

        Task UpdateCountry(Country country);
    }
}
