using Microsoft.EntityFrameworkCore;

namespace RequestPrototype.Models
{
    public class SymbolCompany 
    {
        public long? Id { get; set; }
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
