using Microsoft.EntityFrameworkCore;

namespace Hotels.Data
{
	public class HotelDbContext : DbContext
	{
		public HotelDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Hotel> Hotels { get; set; }
		public DbSet<Country> Countries { get; set; }

	}
}