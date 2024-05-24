using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WorkAtAPizzaPlace.Models;

public class UserProfile
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Address { get; set; }
    public string IdentityUserId { get; set; }
    public IdentityUser IdentityUser { get; set; }
    public string FullName {
        get
        {
            return FirstName + " " + LastName;
        }
    }
}