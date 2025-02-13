using System.ComponentModel.DataAnnotations.Schema;
using SQLite;

namespace YahooScraper.Models.Db;

public class CompanyPriceInfoDto
{
    [PrimaryKey]
    public Guid Id { get; set; }
    public DateTime DateTime { get; set; }
    public double? PreviousClosePrice { get; set; }
    public double? OpenPrice { get; set; }
    public string? CurrencyCode { get; set; }
    
    [ForeignKey(nameof(CompanyInfoDto))]
    public Guid CompanyId { get; set; }

}