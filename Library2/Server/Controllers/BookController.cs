using Library2.Server.Services;
using Library2.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Library2.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController: ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Book book)
    {
        var existingBook = await _bookService.Get(book.Inventory_number);

        if (existingBook is not null)
        {
            return Conflict();
        }

        await _bookService.Add(book);

        return Ok();
    }
    
    [HttpGet("{inventory_number}")]
    public async Task<ActionResult<Book>> Get(int inventory_number)
    {
        var existingBook = await _bookService.Get(inventory_number);

        if (existingBook is null)
        {
            return NotFound();
        }

        return Ok(existingBook);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetAll()
    {
        var books = await _bookService.Get();
        return Ok(books.ToList());
    }

    [HttpPut("{inventory_number}")]
    public async Task<IActionResult> Update(int inventory_number, [FromBody] Book book)
    {
        if (inventory_number != book.Inventory_number)
        {
            return BadRequest();
        }

        var existingBook = await _bookService.Get(inventory_number);

        if (existingBook is null)
        {
            return NotFound();
        }

        await _bookService.Update(book);

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existingBook = await _bookService.Get(id);

        if (existingBook is null)
        {
            return NotFound();
        }

        await _bookService.Delete(existingBook);

        return Ok();
    }
}   