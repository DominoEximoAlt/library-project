using Library2.Shared;

namespace Library2.Server.Services;

public interface IReaderService
{
    Task Add(Reader reader);

    Task Delete(Reader reader);
    
    Task<Reader> Get(int reader_number);

    Task<IEnumerable<Reader>> Get();

    Task Update(Reader reader);

    Task SetRental(Rental rental);
}