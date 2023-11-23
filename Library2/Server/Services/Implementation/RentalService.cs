using System.Collections;
using System.Runtime.InteropServices.JavaScript;
using Library2.Server.Context;
using Library2.Shared;
using Microsoft.EntityFrameworkCore;

namespace Library2.Server.Services.Implementation;

public class RentalService : IRentalService
{
    private readonly ILogger<RentalService> _logger;
    private readonly BookContext _bookContext;

    public RentalService(ILogger<RentalService> logger, BookContext bookContext)
    {
        _logger = logger;
        _bookContext = bookContext;
    }

    public async Task Add(Rental rental)
    {
        
        _bookContext.Rents.Add(rental);

        await _bookContext.SaveChangesAsync();
        _logger.LogInformation("Book rented. Rent: {@Rental}",rental);
    }



    public async Task Delete(Rental rental)
    {
        _bookContext.Rents.Remove(rental);

        await _bookContext.SaveChangesAsync();
        _logger.LogInformation("Rent deleted. Rent: {@Rental}",rental);
    }

    public async Task<Rental> Get(int rentalId)
    {
        
        var rental = await _bookContext.Rents.FindAsync(rentalId);
        
        _logger.LogInformation("Rent retrived. Rent: {@Rental}",rental);
        return rental;
    }

    public async Task<IEnumerable<Rental>> Get()
    {
        _logger.LogInformation("Rents retrived.");

        var rental = await _bookContext.Rents.ToListAsync();
        return rental;
    }

    public async Task<IEnumerable<Rental>> GetByReader(int reader_number)
    {
        
        _logger.LogInformation("Currently rented books by {@Reader_number} retrived.",reader_number);
        
        var rentals = await _bookContext.Rents.ToListAsync();

        var currentlyRented = rentals.Where(o => o.ReaderNumber.Equals(reader_number));

        return currentlyRented;
    }


}