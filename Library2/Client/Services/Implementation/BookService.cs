using System.Net.Http.Json;
using Library2.Shared;

namespace Library2.Client.Services;

public class BookService : IBookService
{
    private readonly HttpClient _httpClient;

    public BookService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public Task<IEnumerable<Book>?> GetBooksAsync() =>
        _httpClient.GetFromJsonAsync<IEnumerable<Book>>("Book");  
  
    public Task<Book?> GetBookByIdAsync(int inventory_number) =>
        _httpClient.GetFromJsonAsync<Book>($"Book/{inventory_number}");  
  
    public Task UpdateBookAsync(int inventory_number, Book book) =>
        _httpClient.PutAsJsonAsync($"Book/{inventory_number}",book);  
  
    public Task DeleteBookAsync(int inventory_number) =>
        _httpClient.DeleteAsync($"Book/{inventory_number}");  
  
    public Task AddBookAsync(Book book) =>
        _httpClient.PostAsJsonAsync("Book",book);  
}