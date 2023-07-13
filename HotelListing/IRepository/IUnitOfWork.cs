using HotelListing.data;
using HotelListing.IGenericRepository;

namespace HotelListing.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<country> Countries { get; }  
        IGenericRepository<hotel> Hotels { get; }

        Task save();
        
    }
}
