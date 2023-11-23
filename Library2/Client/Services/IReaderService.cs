using Library2.Shared;

namespace Library2.Client.Services;

public interface IReaderService
{
    Task<IEnumerable<Reader>?> GetReadersAsync();  
  
    Task<Reader?> GetReaderByIdAsync(int reader_number);  
  
    Task UpdateReaderAsync(int reader_number, Reader reader);  
  
    Task DeleteReaderAsync(int reader_number);  
  
    Task AddReaderAsync(Reader reader);
    Task AddRental(Rental rental);
}