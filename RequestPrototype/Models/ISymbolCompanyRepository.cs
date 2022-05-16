namespace RequestPrototype.Models
{
    public interface ISymbolCompanyRepository
    {
        IQueryable<SymbolCompany> Companies { get; }
    }
}
