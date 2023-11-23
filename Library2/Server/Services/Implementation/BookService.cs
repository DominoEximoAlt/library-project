using Library2.Server.Context;
using Library2.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Library2.Server.Services.Implementation;

public class BookService : IBookService
{
    private readonly ILogger<BookService> _logger;
    private readonly BookContext _bookContext;

    public BookService(ILogger<BookService> logger, BookContext bookContext)
    {
        _logger = logger;
        _bookContext = bookContext;
    }

    public async Task Add(Book book)
    {
        _bookContext.Books.Add(book);

        await _bookContext.SaveChangesAsync();
        _logger.LogInformation("Book added. Book: {@Book}",book);
    }

    public async Task Delete(Book book)
    {
        _bookContext.Books.Remove(book);

        await _bookContext.SaveChangesAsync();
        _logger.LogInformation("Book deleted. Book: {@Book}",book);
    }

    public async Task<Book> Get(int inventory_number)
    {
        
        var book = await _bookContext.Books.FindAsync(inventory_number);
        
        _logger.LogInformation("Book retrived. Book: {@Book}",book);
        return book;
    }

    public async Task<IEnumerable<Book>> Get()
    {
        _logger.LogInformation("Books retrived.");

        var books = await _bookContext.Books.ToListAsync();
        return books;
    }

    public async Task Update(Book newBook)
    {
        var existingBook = await _bookContext.Books.FindAsync(newBook.Inventory_number);
        existingBook.Author = newBook.Author;
        existingBook.Publisher = newBook.Publisher;
        existingBook.Title = newBook.Title;
        existingBook.PublisDate = newBook.PublisDate;
        existingBook.Rental = newBook.Rental;
        
        _logger.LogInformation("Book UpdateDataOperation. Book: {@Book}",existingBook);
        await _bookContext.SaveChangesAsync();
    }
}