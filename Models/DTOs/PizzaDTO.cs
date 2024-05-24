using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkAtAPizzaPlace.Models.DTOs;

namespace WorkAtAPizzaPlace.Models
{
    public class PizzaDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int SizeId { get; set; }
        public int CheeseId { get; set; }
        public int SauceId { get; set; }
        
        public OrderDTO Order {get;set;}
        public SizeDTO Size {get;set;}
        public CheeseDTO Cheese {get; set;}
        public SauceDTO Sauce {get;set;}
        public List<PizzaToppingDTO> PizzaToppings {get;set;}
    }
}
