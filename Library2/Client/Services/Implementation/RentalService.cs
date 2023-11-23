using System.Net.Http.Json;
using Library2.Shared;

namespace Library2.Client.Services;

public class RentalService : IRentalService
{
    
    private readonly HttpClient _httpClient;

    public RentalService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<IEnumerable<Rental>?> GetRentalsAsync() =>
        _httpClient.GetFromJsonAsync<IEnumerable<Rental>>("Rental");  
    

    public Task<Rental?> GetRentalByIdAsync(int rentalId)=>
        _httpClient.GetFromJsonAsync<Rental>($"Rental/{rentalId}");  
    

    public Task<IEnumerable<Rental>?> GetByReaderAsync(int reader_number) =>
        _httpClient.GetFromJsonAsync<IEnumerable<Rental>>($"Rental/{reader_number}"); 
    
  
    public Task DeleteRentalAsync(int rentalId) =>
        _httpClient.DeleteAsync($"Rental/{rentalId}");  
    
  
    public Task AddRentalAsync(Rental rental) =>
        _httpClient.PostAsJsonAsync("Rental",rental);  
    
}