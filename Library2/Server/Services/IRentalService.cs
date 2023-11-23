using Library2.Shared;

namespace Library2.Server.Services;

public interface IRentalService
{
    Task Add(Rental rental);

    Task Delete(Rental rental);
    
    Task<Rental> Get(int rentalId);

    Task<IEnumerable<Rental>> Get();
    
    Task<IEnumerable<Rental>> GetByReader(int reader_number);

  
}