using Hotels.Contracts;
using Hotels.Data;
using Microsoft.EntityFrameworkCore;

namespace Hotels.Repository
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly HotelDbContext _context;
        public CountriesRepository(HotelDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Country> GetDetails(int id)
        {
            return await _context.Countries.Include(q => q.Hotels)
                .FirstOrDefaultAsync(q => q.Id == id); 
        }
    }
}
