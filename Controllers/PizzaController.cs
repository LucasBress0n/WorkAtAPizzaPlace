



using Microsoft.AspNetCore.Mvc;
using WorkAtAPizzaPlace.Data;
using WorkAtAPizzaPlace.Models;
using WorkAtAPizzaPlace.Models.DTOs;

[ApiController]
[Route("/api/[controller]")]
public class PizzaController : ControllerBase
{
    private WorkAtAPizzaPlaceDbContext db;

    public PizzaController(WorkAtAPizzaPlaceDbContext context)
    {
        db = context;
    }

    [HttpPost]
    public IActionResult AddPizza(Pizza newPizza)
    {
        db.Pizzas.Add(newPizza);
        db.SaveChanges();

        return Ok(db.Pizzas.Select(p => new PizzaDTO
        {
            Id = p.Id,
            OrderId = p.OrderId,
            SauceId = p.SauceId,
            SizeId = p.SizeId,
            CheeseId = p.CheeseId
        }).FirstOrDefault(pizObj => pizObj.Id == newPizza.Id));
    }

}