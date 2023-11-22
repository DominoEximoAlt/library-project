using Library2.Shared;

namespace Library2.Server.Services;

public interface IBookService
{
    Task Add(Book book);

    Task Delete(Book book);
    
    Task<Book> Get(int inventory_number);

    Task<IEnumerable<Book>> Get();

    Task Update(Book book);
}