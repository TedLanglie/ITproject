using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RequestPrototype.Models
{
    public class SymbolCompany 
    {
        [Key]
        public string? Symbol { get; set; }
        public string? Company { get; set; }
    }

    public class SymbolCompanyDbContext : DbContext
    {
        public DbSet<SymbolCompany> Companies => Set<SymbolCompany>();

        public SymbolCompanyDbContext(DbContextOptions<SymbolCompanyDbContext> options)
            : base(options) { }
    }
}
