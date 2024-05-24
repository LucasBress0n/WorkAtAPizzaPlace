

using System.ComponentModel.DataAnnotations;

namespace WorkAtAPizzaPlace.Models.DTOs;

public class SizeDTO {
    public int Id {get;set;}
    public string Name {get;set;}
    public int PizzaSize {get;set;}
    public decimal Price {get;set;}

}