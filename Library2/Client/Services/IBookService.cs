using Library2.Shared;

namespace Library2.Client.Services;

public interface IBookService
{
    Task<IEnumerable<Book>?> GetBooksAsync();  
  
    Task<Book?> GetBookByIdAsync(int inventory_number);  
  
    Task UpdateBookAsync(int inventory_number, Book book);  
  
    Task DeleteBookAsync(int inventory_number);  
  
    Task AddBookAsync(Book book);  
}