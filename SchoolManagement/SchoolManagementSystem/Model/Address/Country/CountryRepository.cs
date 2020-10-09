using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public class CountryRepository : ICountryRepository
    {
        ApplicationDbContext _context;
        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> GetAllCountries()
        {
            if (_context != null)
            {
                return await _context.Country.ToListAsync();
            }

            return null;
        }

        public async Task<Country> GetCountry(int? id)
        {
            var country = await _context.Country.FindAsync(id);
            return country;
        }

        public async Task<int> AddCountry(Country country)
        {
            if (_context != null)
            {
                await _context.Country.AddAsync(country);
                await _context.SaveChangesAsync();

                return country.Id;
            }

            return 0;
        }

        public async Task UpdateCountry(Country country)
        {
            if (_context != null)
            {

                _context.Country.Update(country);


                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> DeleteCountry(int? id)
        {
            int result = 0;

            if (_context != null)
            {

                var country = await _context.Country.FindAsync(id);

                if (country != null)
                {

                    _context.Country.Remove(country);


                    result = await _context.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }
    }
}
