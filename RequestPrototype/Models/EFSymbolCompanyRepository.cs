namespace RequestPrototype.Models
{
    public class EFSymbolCompanyRepository : ISymbolCompanyRepository
    {
        private SymbolCompanyDbContext context;

        public EFSymbolCompanyRepository(SymbolCompanyDbContext context) 
        {
            this.context = context;
        }

        public IQueryable<SymbolCompany> Companies => context.Companies;
    }
}
