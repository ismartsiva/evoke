using HotelListing.data;
using HotelListing.IGenericRepository;
using HotelListing.IRepository;

namespace HotelListing.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly databaseContext _context;
        private IGenericRepository<country> _countries;
        private IGenericRepository<hotel> _hotels;
        public UnitOfWork(databaseContext context)
        {
            _context = context;
        }
        public IGenericRepository<country> Countries => _countries ??= new GenericRepository<country>(_context);

        public IGenericRepository<hotel> Hotels => _hotels ??= new GenericRepository<hotel>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
