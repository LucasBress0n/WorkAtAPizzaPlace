



using Microsoft.AspNetCore.Mvc;
using WorkAtAPizzaPlace.Data;
using WorkAtAPizzaPlace.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class SizeController : ControllerBase
{
    private WorkAtAPizzaPlaceDbContext db;

    public SizeController(WorkAtAPizzaPlaceDbContext context)
    {
        db = context;
    }

    [HttpGet]
    public IActionResult GetAllSizes()
    {
        return Ok(db.Sizes.Select(s => new SizeDTO {
            Id = s.Id,
            Name = s.Name,
            PizzaSize = s.PizzaSize,
            Price = s.Price
        }));
    }

}