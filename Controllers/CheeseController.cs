



using Microsoft.AspNetCore.Mvc;
using WorkAtAPizzaPlace.Data;
using WorkAtAPizzaPlace.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class CheeseController : ControllerBase
{
    private WorkAtAPizzaPlaceDbContext db;

    public CheeseController(WorkAtAPizzaPlaceDbContext context)
    {
        db = context;
    }

    [HttpGet]
    public IActionResult GetAllCheeses()
    {
        return Ok(db.Cheeses.Select(c => new CheeseDTO {
            Id = c.Id,
            Name = c.Name
        }));
    }

}