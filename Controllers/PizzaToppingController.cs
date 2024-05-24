



using Microsoft.AspNetCore.Mvc;
using WorkAtAPizzaPlace.Data;
using WorkAtAPizzaPlace.Models;
using WorkAtAPizzaPlace.Models.DTOs;

[ApiController]
[Route("/api/[controller]")]
public class PizzaToppingController : ControllerBase
{
    private WorkAtAPizzaPlaceDbContext db;

    public PizzaToppingController(WorkAtAPizzaPlaceDbContext context)
    {
        db = context;
    }

    [HttpPost]
    public IActionResult AddPizzaTopping(PizzaTopping newPizzaTopping)
    {
        db.PizzaToppings.Add(newPizzaTopping);
        db.SaveChanges();
        return Created();
    }

}