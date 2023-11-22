using Library2.Server.Services;
using Library2.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Library2.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ReaderController : ControllerBase
{
    private readonly IReaderService _readerService;

    public ReaderController(IReaderService readerService)
    {
        _readerService = readerService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Reader reader)
    {
        var existingReader = await _readerService.Get(reader.Reader_number);

        if (existingReader is not null)
        {
            return Conflict();
        }

        await _readerService.Add(reader);

        return Ok();
    }
    
    [HttpGet("{reader_number}")]
    public async Task<ActionResult<Reader>> Get(int reader_number)
    {
        var existingReader = await _readerService.Get(reader_number);

        if (existingReader is null)
        {
            return NotFound();
        }

        return Ok(existingReader);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Reader>>> GetAll()
    {
        var readers = await _readerService.Get();
        return Ok(readers.ToList());
    }

    [HttpPut("{reader_number}")]
    public async Task<IActionResult> Update(int reader_number, [FromBody] Reader reader)
    {
        if (reader_number != reader.Reader_number)
        {
            return BadRequest();
        }

        var existingReader = await _readerService.Get(reader_number);

        if (existingReader is null)
        {
            return NotFound();
        }

        await _readerService.Update(reader);

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existingReader = await _readerService.Get(id);

        if (existingReader is null)
        {
            return NotFound();
        }

        await _readerService.Delete(existingReader);

        return Ok();
    }
}