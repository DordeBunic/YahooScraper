using SQLite;
using SQLiteNetExtensions.Attributes;
using YahooScraper.Models.Domain;

namespace YahooScraper.Models.Db;

public class CompanyInfoDto
{
    [PrimaryKey]
    public Guid Id { get; set; }
    
    public string? Symbol{ get; set; }
    public string? CompanyName{ get; set; }
    public string? MarketCap{ get; set; }
    public string? YearFounded{ get; set; }
    public int NumberOfEmployees{ get; set; }
    public string? City{ get; set; }
    public string? State{ get; set; }
    
    [OneToMany(CascadeOperations = CascadeOperation.All)]
    public CompanyPriceInfo? PriceInfo { get; set; }
}