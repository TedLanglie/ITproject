using Microsoft.EntityFrameworkCore;

namespace RequestPrototype.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            SymbolCompanyDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<SymbolCompanyDbContext>();
        if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Companies.Any())
            {
                context.Companies.AddRange(
                new SymbolCompany
                {
                    Company = "Apple Inc. Common Stock",
                    Symbol = "AAPL"
                },
                new SymbolCompany
                {
                    Company = "International Business Machines Corporation Common Stock",
                    Symbol = "IBM"
                }
            );
            context.SaveChanges();
            }
        }
    }
}