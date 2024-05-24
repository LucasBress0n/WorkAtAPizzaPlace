using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkAtAPizzaPlace.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int SizeId { get; set; }
        [Required]
        public int CheeseId { get; set; }
        [Required]
        public int SauceId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order {get;set;}
        [ForeignKey("SizeId")]
        public Size Size {get;set;}
        [ForeignKey("CheeseId")]
        public Cheese Cheese {get; set;}
        [ForeignKey("SauceId")]
        public Sauce Sauce {get;set;}
        public List<PizzaTopping> PizzaToppings {get;set;}
    }
}
