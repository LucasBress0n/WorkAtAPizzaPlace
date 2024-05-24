using System.ComponentModel.DataAnnotations;

namespace WorkAtAPizzaPlace.Models.DTOs;

public class RegistrationDTO
{
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
    [MaxLength(100)]
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }

}