using System.ComponentModel.DataAnnotations;

namespace RequestPrototype.Models
{
    public class HomeViewModel 
    {
        public IQueryable<SymbolCompany>? Companies { get; set; }
        [Required(ErrorMessage = "Symbol must be set")]
        public string? Ticker { get; set; }
    }
}
