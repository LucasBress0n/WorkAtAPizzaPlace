using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WorkAtAPizzaPlace.Models;

namespace WorkAtAPizzaPlace.Data;
public class WorkAtAPizzaPlaceDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Topping> Toppings {get;set;}
    public DbSet<Size> Sizes {get;set;}
    public DbSet<Sauce> Sauces {get;set;}
    public DbSet<PizzaTopping> PizzaToppings {get;set;}
    public DbSet<Pizza> Pizzas {get;set;}
    public DbSet<Order> Orders {get;set;}
    public DbSet<Cheese> Cheeses {get;set;}

    public WorkAtAPizzaPlaceDbContext(DbContextOptions<WorkAtAPizzaPlaceDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PizzaTopping>().HasKey(pt => new {pt.PizzaId, pt.ToppingId});

        modelBuilder.Entity<PizzaTopping>()
        .HasOne(pt => pt.Pizza);

        modelBuilder.Entity<PizzaTopping>()
        .HasOne(pt => pt.Topping);


        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",
            Address = "101 Main Street",
        });

        modelBuilder.Entity<Topping>().HasData(new Topping[]
        {
            new()
            {
                Id = 1,
                Name = "Sausage",
                Price = 0.50M
            },
            new()
            {
                Id = 2,
                Name = "Pepperoni",
                Price = 0.50M
            },
            new()
            {
                Id = 3,
                Name = "Mushroom",
                Price = 0.50M
            },
            new()
            {
                Id = 4,
                Name = "Onion",
                Price = 0.50M
            },
            new()
            {
                Id = 5,
                Name = "Green Pepper",
                Price = 0.50M
            },
            new()
            {
                Id = 6,
                Name = "Black Olive",
                Price = 0.50M
            },
            new()
            {
                Id = 7,
                Name = "Basil",
                Price = 0.50M
            },
            new()
            {
                Id = 8,
                Name = "Extra Cheese",
                Price = 0.50M
            }
        });

        modelBuilder.Entity<Size>().HasData(new Size[]
        {
            new ()
            {
                Id = 1,
                Name = "Small",
                PizzaSize = 10,
                Price = 10.00M
            },
            new ()
            {
                Id = 2,
                Name = "Medium",
                PizzaSize = 14,
                Price = 12.00M
            },
            new ()
            {
                Id = 3,
                Name = "Large",
                PizzaSize = 18,
                Price = 15.00M
            }
        });

        modelBuilder.Entity<Sauce>().HasData(new Sauce[]
        {
            new ()
            {
                Id = 1,
                Name = "Marinara"
            },
            new ()
            {
                Id = 2,
                Name = "Arrabbiata"
            },
            new ()
            {
                Id = 3,
                Name = "Garlic White"
            },
            new ()
            {
                Id = 4,
                Name = "None (sauceless pizza)"
            }
        });

        modelBuilder.Entity<Cheese>().HasData(new Cheese[]
        {
            new ()
            {
                Id = 1,
                Name = "Buffalo Mozzarella"
            },
            new ()
            {
                Id = 2,
                Name = "Four Cheese"
            },
            new ()
            {
                Id = 3,
                Name = "Vegan"
            },
            new ()
            {
                Id = 4,
                Name = "None (cheeseless)"
            }
        });

        modelBuilder.Entity<PizzaTopping>().HasData(new PizzaTopping[]
        {
            new ()
            {
                PizzaId = 1,
                ToppingId = 4
            },
            new ()
            {
                PizzaId = 1,
                ToppingId = 3
            },
            new()
            {
                PizzaId = 1,
                ToppingId = 2
            },
            new ()
            {
                PizzaId = 1,
                ToppingId = 5
            },
            new ()
            {
                PizzaId = 1,
                ToppingId = 6
            },
            new ()
            {
                PizzaId = 1,
                ToppingId = 8
            },
            new ()
            {
                PizzaId = 1,
                ToppingId = 7
            },
        });

        modelBuilder.Entity<Pizza>().HasData(new Pizza[]
        {
            new()
            {
                Id = 1,
                OrderId = 1,
                SizeId = 2,
                CheeseId = 2,
                SauceId = 1
            }
        });

        modelBuilder.Entity<Order>().HasData(new Order[]
        {
            new()
            {
                Id = 1,
                UserProfileId = 1,
                DelivererId = 1,
                PlacedOn = DateTime.Now
            }
        });
    }
}