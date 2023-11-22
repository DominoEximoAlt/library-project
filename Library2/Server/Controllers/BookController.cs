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
}