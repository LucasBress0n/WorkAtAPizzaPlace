using System.ComponentModel.DataAnnotations;

namespace WorkAtAPizzaPlace.Models
{
    public class Sauce
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
