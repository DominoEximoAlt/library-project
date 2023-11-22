using Library2.Server.Services;
using Library2.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Library2.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class RentalController : ControllerBase
{
    private readonly IRentalService _rentalService;

    public RentalController(IRentalService rentalService)
    {
        _rentalService = rentalService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Rental rental)
    {
        var existingRental = await _rentalService.Get(rental.RentalId);

        if (existingRental is not null)
        {
            return Conflict();
        }

        await _rentalService.Add(rental);

        return Ok();
    }
    
    [HttpGet("{rentalId}")]
    public async Task<ActionResult<Reader>> Get(int rentalId)
    {
        var existingRental = await _rentalService.Get(rentalId);

        if (existingRental is not null)
        {
            return NotFound();
        }

        return Ok(existingRental);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Reader>>> GetAll()
    {
        var readers = await _rentalService.Get();
        return Ok(readers.ToList());
    }

    
    
    
}