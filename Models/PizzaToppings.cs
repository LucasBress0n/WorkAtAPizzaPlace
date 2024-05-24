using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkAtAPizzaPlace.Models
{
    public class PizzaTopping
    {
        [Required]
        public int PizzaId { get; set; }
        [ForeignKey("PizzaId")]
        public Pizza Pizza {get;set;}
        [Required]
        public int ToppingId { get; set; }
        [ForeignKey("ToppingId")]
        public Topping Topping {get;set;}

    }
}
