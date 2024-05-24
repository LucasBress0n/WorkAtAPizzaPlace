


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkAtAPizzaPlace.Data;
using WorkAtAPizzaPlace.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private WorkAtAPizzaPlaceDbContext db;

    public UserProfileController(WorkAtAPizzaPlaceDbContext context)
    {
        db = context;
    }



    [HttpGet]
    public IActionResult GetAllUsers()
    {
        return Ok(db.UserProfiles.Include(up => up.IdentityUser).Select(up => new UserProfileDTO
        {
            Id = up.Id,
            FirstName = up.FirstName,
            LastName = up.LastName,
            Address = up.Address,
            Email = up.IdentityUser.Email,
            UserName = up.IdentityUser.UserName
        }));
    }
}