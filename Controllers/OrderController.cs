



using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkAtAPizzaPlace.Data;
using WorkAtAPizzaPlace.Models;
using WorkAtAPizzaPlace.Models.DTOs;

[ApiController]
[Route("/api/[controller]")]
public class OrderController : ControllerBase
{
    private WorkAtAPizzaPlaceDbContext db;

    public OrderController(WorkAtAPizzaPlaceDbContext context)
    {
        db = context;
    }

    [HttpPost]
    public IActionResult AddOrder(Order newOrder)
    {

        newOrder.PlacedOn = DateTime.Now;

        db.Orders.Add(newOrder);
        db.SaveChanges();
        return Ok(db.Orders.Select(o => new OrderDTO
        {
            Id = o.Id,
            UserProfileId = o.UserProfileId,
            DelivererId = o.DelivererId,
            PlacedOn = o.PlacedOn
        }).FirstOrDefault(ord => ord.Id == newOrder.Id));
    }


    [HttpGet]
    public IActionResult GetAllOrders()
    {
        return Ok(db.Orders
        .Include(o => o.UserProfile)
        .Include(o => o.DelivererProfile)
        .Include(o => o.Pizzas)
        .ThenInclude(p => p.Size)
        .Include(o => o.Pizzas)
        .ThenInclude(p => p.Cheese)
        .Include(o => o.Pizzas)
        .ThenInclude(p => p.Sauce)
        .Include(o => o.Pizzas)
        .ThenInclude(p => p.PizzaToppings)
        .ThenInclude(pt => pt.Topping)
        .OrderByDescending(o => o.PlacedOn)
        .Select(o => new OrderDTO
        {
            Id = o.Id,
            UserProfileId = o.UserProfileId,
            UserProfile = new UserProfileDTO
            {
                Id = o.UserProfile.Id,
                FirstName = o.UserProfile.FirstName,
                LastName = o.UserProfile.LastName,
                Address = o.UserProfile.Address,
            },
            DelivererId = o.DelivererId,
            DelivererProfile = o.DelivererId != null ? new UserProfileDTO
            {
                Id = o.DelivererProfile.Id,
                FirstName = o.DelivererProfile.FirstName,
                LastName = o.DelivererProfile.LastName,
                Address = o.DelivererProfile.Address,
            } : null,
            PlacedOn = o.PlacedOn,
            Pizzas = o.Pizzas.Select(p => new PizzaDTO
            {
                Id = p.Id,
                OrderId = p.OrderId,
                SizeId = p.SizeId,
                CheeseId = p.CheeseId,
                SauceId = p.SauceId,
                Size = new SizeDTO
                {
                    Id = p.Size.Id,
                    Name = p.Size.Name,
                    PizzaSize = p.Size.PizzaSize,
                    Price = p.Size.Price
                },
                Cheese = new CheeseDTO
                {
                    Id = p.Cheese.Id,
                    Name = p.Cheese.Name
                },
                Sauce = new SauceDTO
                {
                    Id = p.Sauce.Id,
                    Name = p.Sauce.Name
                },
                PizzaToppings = p.PizzaToppings.Select(pt => new PizzaToppingDTO
                {
                    PizzaId = pt.PizzaId,
                    ToppingId = pt.ToppingId,
                    Topping = new ToppingDTO
                    {
                        Id = pt.Topping.Id,
                        Name = pt.Topping.Name,
                        Price = pt.Topping.Price
                    }
                }).ToList()
            }).ToList()
        }));
    }

    [HttpGet("{Id}")]
    public IActionResult GetSingleOrderById(int Id)
    {
                return Ok(db.Orders
        .Include(o => o.UserProfile)
        .Include(o => o.DelivererProfile)
        .Include(o => o.Pizzas)
        .ThenInclude(p => p.Size)
        .Include(o => o.Pizzas)
        .ThenInclude(p => p.Cheese)
        .Include(o => o.Pizzas)
        .ThenInclude(p => p.Sauce)
        .Include(o => o.Pizzas)
        .ThenInclude(p => p.PizzaToppings)
        .ThenInclude(pt => pt.Topping)
        .OrderByDescending(o => o.PlacedOn)
        .Select(o => new OrderDTO
        {
            Id = o.Id,
            UserProfileId = o.UserProfileId,
            UserProfile = new UserProfileDTO
            {
                Id = o.UserProfile.Id,
                FirstName = o.UserProfile.FirstName,
                LastName = o.UserProfile.LastName,
                Address = o.UserProfile.Address,
            },
            DelivererId = o.DelivererId,
            DelivererProfile = o.DelivererId != null ? new UserProfileDTO
            {
                Id = o.DelivererProfile.Id,
                FirstName = o.DelivererProfile.FirstName,
                LastName = o.DelivererProfile.LastName,
                Address = o.DelivererProfile.Address,
            } : null,
            PlacedOn = o.PlacedOn,
            Pizzas = o.Pizzas.Select(p => new PizzaDTO
            {
                Id = p.Id,
                OrderId = p.OrderId,
                SizeId = p.SizeId,
                CheeseId = p.CheeseId,
                SauceId = p.SauceId,
                Size = new SizeDTO
                {
                    Id = p.Size.Id,
                    Name = p.Size.Name,
                    PizzaSize = p.Size.PizzaSize,
                    Price = p.Size.Price
                },
                Cheese = new CheeseDTO
                {
                    Id = p.Cheese.Id,
                    Name = p.Cheese.Name
                },
                Sauce = new SauceDTO
                {
                    Id = p.Sauce.Id,
                    Name = p.Sauce.Name
                },
                PizzaToppings = p.PizzaToppings.Select(pt => new PizzaToppingDTO
                {
                    PizzaId = pt.PizzaId,
                    ToppingId = pt.ToppingId,
                    Topping = new ToppingDTO
                    {
                        Id = pt.Topping.Id,
                        Name = pt.Topping.Name,
                        Price = pt.Topping.Price
                    }
                }).ToList()
            }).ToList()
        }).Single(i => i.Id == Id));
    }
}