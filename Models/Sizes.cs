

using System.ComponentModel.DataAnnotations;

namespace WorkAtAPizzaPlace.Models;

public class Size {
    public int Id {get;set;}
    [Required]
    public string Name {get;set;}
    [Required]
    public int PizzaSize {get;set;}
    [Required]
    public decimal Price {get;set;}

}