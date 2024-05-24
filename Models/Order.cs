using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkAtAPizzaPlace.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public int UserProfileId { get; set; }
        public int? DelivererId { get; set; }
        [Required]
        public DateTime PlacedOn { get; set; }
        [ForeignKey("UserProfileId")]
        public UserProfile UserProfile {get;set;}
        [ForeignKey("DelivererId")]
        public UserProfile DelivererProfile {get;set;}
        public List<Pizza> Pizzas {get;set;}
    }
}
