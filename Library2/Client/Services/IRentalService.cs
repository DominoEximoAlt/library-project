using Library2.Shared;

namespace Library2.Client.Services;

public interface IRentalService
{
    
    
    Task<IEnumerable<Rental>?> GetRentalsAsync();  
  
    Task<Rental?> GetRentalByIdAsync(int rentalId);

    Task<IEnumerable<Rental>?> GetByReaderAsync(int reader_number);
  
    Task DeleteRentalAsync(int rentalId);  
  
    Task AddRentalAsync(Rental rental);  
    
    
}