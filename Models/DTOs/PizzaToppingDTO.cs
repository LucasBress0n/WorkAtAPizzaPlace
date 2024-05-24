using System.ComponentModel.DataAnnotations.Schema;

namespace WorkAtAPizzaPlace.Models.DTOs
{
    public class PizzaToppingDTO
    {
        public int PizzaId { get; set; }
        public PizzaDTO Pizza {get;set;}
        public int ToppingId { get; set; }
        public ToppingDTO Topping {get;set;}

    }
}
