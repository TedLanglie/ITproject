using System.ComponentModel.DataAnnotations;

namespace RequestPrototype.Models
{
    public class userInput
    {
        // holds the user response from the index page
        [Required(ErrorMessage = "Symbol must be set")]
        public string? Ticker { get; set; }
    }
}
