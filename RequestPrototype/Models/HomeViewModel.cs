using System.ComponentModel.DataAnnotations;

namespace RequestPrototype.Models
{
    public class HomeViewModel 
    {
        IQueryable<SymbolCompany>? Companies { get; set; }
        public UserInput? UserInput { get; set; }
    }
    public class UserInput
    {
        [Required(ErrorMessage = "Symbol must be set")]
        public string? Ticker { get; set; }
    }
}
