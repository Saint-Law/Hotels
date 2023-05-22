using Hotels.Contracts;
using Hotels.Data;

namespace Hotels.Repository
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        public HotelsRepository(HotelDbContext context) : base(context)
        {
        }
    }
}
