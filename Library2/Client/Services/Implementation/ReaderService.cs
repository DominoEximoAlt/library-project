using System.Net.Http.Json;
using Library2.Shared;

namespace Library2.Client.Services;

public class ReaderService : IReaderService
{
    private readonly HttpClient _httpClient;

    public ReaderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public Task<IEnumerable<Reader>?> GetReadersAsync() =>
        _httpClient.GetFromJsonAsync<IEnumerable<Reader>>("Reader");  
  
    public Task<Reader?> GetReaderByIdAsync(int reader_number) =>
        _httpClient.GetFromJsonAsync<Reader>($"Reader/{reader_number}");  
  
    public Task UpdateReaderAsync(int reader_number, Reader reader) =>
        _httpClient.PutAsJsonAsync($"Reader/{reader_number}",reader);  
  
    public Task DeleteReaderAsync(int reader_number) =>
        _httpClient.DeleteAsync($"Reader/{reader_number}");  
  
    public Task AddReaderAsync(Reader reader) =>
        _httpClient.PostAsJsonAsync("Reader",reader);  
    
    public Task AddRental( Rental rental) =>
        _httpClient.PutAsJsonAsync($"Reader/{rental.ReaderNumber}",rental);  
}