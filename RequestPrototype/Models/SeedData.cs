using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;

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
                context.Companies.AddRange(GetCompaniesFromFile());
            context.SaveChanges();
            }
        }

        public static IEnumerable<SymbolCompany> GetCompaniesFromFile(string filename = @"App_Data/SymbolCompany/stock_symbols_list.csv") 
        {
            TextFieldParser? parser = GetParser(filename);
            if(parser == null)
                yield break;

            using (parser)
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = parser.ReadFields();
                    string? symbol = null;
                    string? company = null;
                    for (int i = 0; i < fields?.Length; i++)
                    {
                        if (i == 0)
                            symbol = fields[i];
                        else
                            company = fields[i];
                    }
                    if (symbol != null && company != null)
                        yield return new SymbolCompany() { Symbol = symbol, Company = company };
                    }
                }
            
        }

        private static TextFieldParser? GetParser(string filename) 
        {
            try
            {
                return new TextFieldParser(filename);
            }
            catch (IOException)
            {
                return null;
            }
        }
    }
}