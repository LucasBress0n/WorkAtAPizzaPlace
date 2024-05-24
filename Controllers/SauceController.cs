



using Microsoft.AspNetCore.Mvc;
using WorkAtAPizzaPlace.Data;
using WorkAtAPizzaPlace.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class SauceController : ControllerBase
{
    private WorkAtAPizzaPlaceDbContext db;

    public SauceController(WorkAtAPizzaPlaceDbContext context)
    {
        db = context;
    }

    [HttpGet]
    public IActionResult GetAllSauce()
    {
        return Ok(db.Sauces.Select(c => new SauceDTO {
            Id = c.Id,
            Name = c.Name
        }));
    }

}