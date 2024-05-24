using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkAtAPizzaPlace.Models.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public int? DelivererId { get; set; }
        public DateTime PlacedOn { get; set; }
        public UserProfileDTO UserProfile {get;set;}
        public UserProfileDTO DelivererProfile {get;set;}
        public List<PizzaDTO> Pizzas {get;set;}
        public string CompletedOnDate
    {
        get { return PlacedOn.Date.ToString("MM/dd/yyyy"); }
    }
    }
}
