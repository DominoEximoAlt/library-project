using Library2.Server.Context;
using Library2.Shared;
using Microsoft.EntityFrameworkCore;

namespace Library2.Server.Services.Implementation;

public class ReaderService : IReaderService
{
    private readonly ILogger<ReaderService> _logger;
    private readonly BookContext _bookContext;

    public ReaderService(ILogger<ReaderService> logger, BookContext bookContext)
    {
        _logger = logger;
        _bookContext = bookContext;
    }

    public async Task Add(Reader reader)
    {
        _bookContext.Readers.Add(reader);

        await _bookContext.SaveChangesAsync();
        _logger.LogInformation("Reader added. Reader: {@Reader}",reader);
    }

    public async Task Delete(Reader reader)
    {
        _bookContext.Readers.Remove(reader);

        await _bookContext.SaveChangesAsync();
        _logger.LogInformation("Reader deleted. Reader: {@Reader}",reader);
    }

    public async Task<Reader> Get(int reader_number)
    {
        
        var reader = await _bookContext.Readers.FindAsync(reader_number);
        
        _logger.LogInformation("Reader retrived. Reader: {@Reader}",reader);
        return reader;
    }

    public async Task<IEnumerable<Reader>> Get()
    {
        _logger.LogInformation("Readers retrived.");

        var reader = await _bookContext.Readers.ToListAsync();
        return reader;
    }

    public async Task Update(Reader newReader)
    {
        var existingReader = await _bookContext.Readers.FindAsync(newReader.Reader_number);
        existingReader.Name = newReader.Name;
        existingReader.Address = newReader.Address;
        existingReader.BirthDate = newReader.BirthDate;
        
        _logger.LogInformation("Reader UpdateDataOperation. Reader: {@Reader}",existingReader);
        await _bookContext.SaveChangesAsync();
    }
}