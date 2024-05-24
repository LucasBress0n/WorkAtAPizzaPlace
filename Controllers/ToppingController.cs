



using Microsoft.AspNetCore.Mvc;
using WorkAtAPizzaPlace.Data;
using WorkAtAPizzaPlace.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class ToppingsController : ControllerBase
{
    private WorkAtAPizzaPlaceDbContext db;

    public ToppingsController(WorkAtAPizzaPlaceDbContext context)
    {
        db = context;
    }

    [HttpGet]
    public IActionResult GetAllToppings()
    {
        return Ok(db.Toppings.Select(t => new ToppingDTO {
            Id = t.Id,
            Name = t.Name,
            Price = t.Price
        }));
    }

}