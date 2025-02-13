namespace YahooScraper.Models.Api;
public class YahooCompanyInfoDto
{
    public QuoteSummary? QuoteSummary { get; set; }
}

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Ask
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class AskSize
{
    public int Raw { get; set; }
    public string? Fmt { get; set; }
    public string? LongFmt { get; set; }
}

public class AsOfDate
{
    public int Raw { get; set; }
    public string? Fmt { get; set; }
}

public class AssetProfile
{
    public string? Address1 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Zip { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public string? Website { get; set; }
    public string? Industry { get; set; }
    public string? IndustryKey { get; set; }
    public string? IndustryDisp { get; set; }
    public string? Sector { get; set; }
    public string? SectorKey { get; set; }
    public string? SectorDisp { get; set; }
    public string? LongBusinessSummary { get; set; }
    public int FullTimeEmployees { get; set; }
    public List<CompanyOfficer>? CompanyOfficers { get; set; }
    public int AuditRisk { get; set; }
    public int BoardRisk { get; set; }
    public int CompensationRisk { get; set; }
    public int ShareHolderRightsRisk { get; set; }
    public int OverallRisk { get; set; }
    public int GovernanceEpochDate { get; set; }
    public int CompensationAsOfEpochDate { get; set; }
    public string? IrWebsite { get; set; }
    public List<object>? ExecutiveTeam { get; set; }
    public int MaxAge { get; set; }
}

public class AverageDailyVolume10Day
{
    public int Raw { get; set; }
    public string? Fmt { get; set; }
    public string? LongFmt { get; set; }
}

public class AverageDailyVolume3Month
{
    public int Raw { get; set; }
    public string? Fmt { get; set; }
    public string? LongFmt { get; set; }
}

public class AverageVolume
{
    public int Raw { get; set; }
    public string? Fmt { get; set; }
    public string? LongFmt { get; set; }
}

public class AverageVolume10days
{
    public int Raw { get; set; }
    public string? Fmt { get; set; }
    public string? LongFmt { get; set; }
}

public class Benchmark
{
    public string? Symbol { get; set; }
    public string? ShortName { get; set; }
}

public class Beta
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class Bid
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class BidSize
{
    public int Raw { get; set; }
    public string? Fmt { get; set; }
    public string? LongFmt { get; set; }
}

public class CalendarEvents
{
    public int MaxAge { get; set; }
    public Earnings? Earnings { get; set; }
    public ExDividendDate? ExDividendDate { get; set; }
    public DividendDate? DividendDate { get; set; }
}

public class CirculatingSupply
{
}

public class CompanyOfficer
{
    public int MaxAge { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Title { get; set; }
    public int YearBorn { get; set; }
    public int FiscalYear { get; set; }
    public TotalPay? TotalPay { get; set; }
    public ExercisedValue? ExercisedValue { get; set; }
    public UnexercisedValue? UnexercisedValue { get; set; }
}

public class CorporateAction
{
    public string? Header { get; set; }
    public string? Message { get; set; }
    public Meta? Meta { get; set; }
    public List<CorporateAction>? CorporateActions { get; set; }
    public int MaxAge { get; set; }
}

public class DayHigh
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class DayLow
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class DividendDate
{
    public int Raw { get; set; }
    public string? Fmt { get; set; }
}

public class DividendRate
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class DividendYield
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class Earnings
{
    public List<EarningsDate>? EarningsDate { get; set; }
    public List<EarningsCallDate>? EarningsCallDate { get; set; }
    public bool IsEarningsDateEstimate { get; set; }
    public EarningsAverage? EarningsAverage { get; set; }
    public EarningsLow? EarningsLow { get; set; }
    public EarningsHigh? EarningsHigh { get; set; }
    public RevenueAverage? RevenueAverage { get; set; }
    public RevenueLow? RevenueLow { get; set; }
    public RevenueHigh? RevenueHigh { get; set; }
}

public class EarningsAverage
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class EarningsCallDate
{
    public int Raw { get; set; }
    public string? Fmt { get; set; }
}

public class EarningsDate
{
    public int Raw { get; set; }
    public string? Fmt { get; set; }
}

public class EarningsHigh
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class EarningsLow
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class ExDividendDate
{
    public int Raw { get; set; }
    public string? Fmt { get; set; }
}

public class ExercisedValue
{
    public int Raw { get; set; }
    public object? Fmt { get; set; }
    public string? LongFmt { get; set; }
}

public class Exhibit
{
    public string? Type { get; set; }
    public string? Url { get; set; }
    public string? DownloadUrl { get; set; }
}

public class ExpireDate
{
}

public class FiftyDayAverage
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class FiftyTwoWeekHigh
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class FiftyTwoWeekLow
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class Filing
{
    public string? Date { get; set; }
    public int EpochDate { get; set; }
    public string? Type { get; set; }
    public string? Title { get; set; }
    public string? EdgarUrl { get; set; }
    public List<Exhibit>? Exhibits { get; set; }
    public int MaxAge { get; set; }
}

public class FinancialsTemplate
{
    public string? Code { get; set; }
    public int MaxAge { get; set; }
}

public class FiveDaysReturn
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class FiveYearAvgDividendYield
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class FiveYearTotalReturn
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class ForwardPE
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class MarketCap
{
    public long Raw { get; set; }
    public string? Fmt { get; set; }
    public string? LongFmt { get; set; }
}

public class MaxReturn
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class MaxSupply
{
}

public class Meta
{
    public string? EventType { get; set; }
    public long DateEpochMs { get; set; }
    public string? Amount { get; set; }
}

public class NavPrice
{
}

public class OneMonthReturn
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class OneYearTotalReturn
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class Open
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class OpenInterest
{
}

public class PageViews
{
    public string? ShortTermTrend { get; set; }
    public string? MidTermTrend { get; set; }
    public string? LongTermTrend { get; set; }
    public int MaxAge { get; set; }
}

public class PayoutRatio
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class PerformanceOverview
{
    public AsOfDate? AsOfDate { get; set; }
    public FiveDaysReturn? FiveDaysReturn { get; set; }
    public OneMonthReturn? OneMonthReturn { get; set; }
    public ThreeMonthReturn? ThreeMonthReturn { get; set; }
    public SixMonthReturn? SixMonthReturn { get; set; }
    public YtdReturnPct? YtdReturnPct { get; set; }
    public OneYearTotalReturn? OneYearTotalReturn { get; set; }
    public TwoYearTotalReturn? TwoYearTotalReturn { get; set; }
    public ThreeYearTotalReturn? ThreeYearTotalReturn { get; set; }
    public FiveYearTotalReturn? FiveYearTotalReturn { get; set; }
    public TenYearTotalReturn? TenYearTotalReturn { get; set; }
    public MaxReturn? MaxReturn { get; set; }
}

public class PerformanceOverviewBenchmark
{
    public AsOfDate? AsOfDate { get; set; }
    public FiveDaysReturn? FiveDaysReturn { get; set; }
    public OneMonthReturn? OneMonthReturn { get; set; }
    public ThreeMonthReturn? ThreeMonthReturn { get; set; }
    public SixMonthReturn? SixMonthReturn { get; set; }
    public YtdReturnPct? YtdReturnPct { get; set; }
    public OneYearTotalReturn? OneYearTotalReturn { get; set; }
    public TwoYearTotalReturn? TwoYearTotalReturn { get; set; }
    public ThreeYearTotalReturn? ThreeYearTotalReturn { get; set; }
    public FiveYearTotalReturn? FiveYearTotalReturn { get; set; }
    public TenYearTotalReturn? TenYearTotalReturn { get; set; }
    public MaxReturn? MaxReturn { get; set; }
}

public class PostMarketChange
{
}

public class PostMarketPrice
{
}

public class PreMarketChange
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class PreMarketChangePercent
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class PreMarketPrice
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class PreviousClose
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class Price
{
    public int MaxAge { get; set; }
    public PreMarketChangePercent? PreMarketChangePercent { get; set; }
    public PreMarketChange? PreMarketChange { get; set; }
    public int PreMarketTime { get; set; }
    public PreMarketPrice? PreMarketPrice { get; set; }
    public string? PreMarketSource { get; set; }
    public PostMarketChange? PostMarketChange { get; set; }
    public PostMarketPrice? PostMarketPrice { get; set; }
    public RegularMarketChangePercent? RegularMarketChangePercent { get; set; }
    public RegularMarketChange? RegularMarketChange { get; set; }
    public int RegularMarketTime { get; set; }
    public PriceHint? PriceHint { get; set; }
    public RegularMarketPrice? RegularMarketPrice { get; set; }
    public RegularMarketDayHigh? RegularMarketDayHigh { get; set; }
    public RegularMarketDayLow? RegularMarketDayLow { get; set; }
    public RegularMarketVolume? RegularMarketVolume { get; set; }
    public AverageDailyVolume10Day? AverageDailyVolume10Day { get; set; }
    public AverageDailyVolume3Month? AverageDailyVolume3Month { get; set; }
    public RegularMarketPreviousClose? RegularMarketPreviousClose { get; set; }
    public string? RegularMarketSource { get; set; }
    public RegularMarketOpen? RegularMarketOpen { get; set; }
    public StrikePrice? StrikePrice { get; set; }
    public OpenInterest? OpenInterest { get; set; }
    public string? Exchange { get; set; }
    public string? ExchangeName { get; set; }
    public int ExchangeDataDelayedBy { get; set; }
    public string? MarketState { get; set; }
    public string? QuoteType { get; set; }
    public string? Symbol { get; set; }
    public object? UnderlyingSymbol { get; set; }
    public string? ShortName { get; set; }
    public string? LongName { get; set; }
    public string? Currency { get; set; }
    public string? QuoteSourceName { get; set; }
    public string? CurrencySymbol { get; set; }
    public object? FromCurrency { get; set; }
    public object? ToCurrency { get; set; }
    public object? LastMarket { get; set; }
    public Volume24Hr? Volume24Hr { get; set; }
    public VolumeAllCurrencies? VolumeAllCurrencies { get; set; }
    public CirculatingSupply? CirculatingSupply { get; set; }
    public MarketCap? MarketCap { get; set; }
}

public class PriceHint
{
    public int Raw { get; set; }
    public string? Fmt { get; set; }
    public string? LongFmt { get; set; }
}

public class PriceToSalesTrailing12Months
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class QtdReturn
{
}

public class QuoteSummary
{
    public List<Result>? Result { get; set; }
    public object? Error { get; set; }
}

public class QuoteUnadjustedPerformanceOverview
{
    public int MaxAge { get; set; }
    public Benchmark? Benchmark { get; set; }
    public PerformanceOverview? PerformanceOverview { get; set; }
    public PerformanceOverviewBenchmark? PerformanceOverviewBenchmark { get; set; }
}

public class RegularMarketChange
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class RegularMarketChangePercent
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class RegularMarketDayHigh
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class RegularMarketDayLow
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class RegularMarketOpen
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class RegularMarketPreviousClose
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class RegularMarketPrice
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class RegularMarketVolume
{
    public int Raw { get; set; }
    public string? Fmt { get; set; }
    public string? LongFmt { get; set; }
}

public class Result
{
    public AssetProfile? AssetProfile { get; set; }
    public SummaryDetail? SummaryDetail { get; set; }
    public CalendarEvents? CalendarEvents { get; set; }
    public PageViews? PageViews { get; set; }
    public Price? Price { get; set; }
    public QuoteUnadjustedPerformanceOverview? QuoteUnadjustedPerformanceOverview { get; set; }
    public FinancialsTemplate? FinancialsTemplate { get; set; }
    public CorporateAction? CorporateActions { get; set; }
    public SecFilings? SecFilings { get; set; }
}

public class RevenueAverage
{
    public long Raw { get; set; }
    public string? Fmt { get; set; }
    public string? LongFmt { get; set; }
}

public class RevenueHigh
{
    public long Raw { get; set; }
    public string? Fmt { get; set; }
    public string? LongFmt { get; set; }
}

public class RevenueLow
{
    public long Raw { get; set; }
    public string? Fmt { get; set; }
    public string? LongFmt { get; set; }
}



public class SecFilings
{
    public List<Filing>? Filings { get; set; }
    public int MaxAge { get; set; }
}

public class SixMonthReturn
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class StartDate
{
}

public class StrikePrice
{
}

public class SummaryDetail
{
    public int MaxAge { get; set; }
    public PriceHint? PriceHint { get; set; }
    public PreviousClose? PreviousClose { get; set; }
    public Open? Open { get; set; }
    public DayLow? DayLow { get; set; }
    public DayHigh? DayHigh { get; set; }
    public RegularMarketPreviousClose? RegularMarketPreviousClose { get; set; }
    public RegularMarketOpen? RegularMarketOpen { get; set; }
    public RegularMarketDayLow? RegularMarketDayLow { get; set; }
    public RegularMarketDayHigh? RegularMarketDayHigh { get; set; }
    public DividendRate? DividendRate { get; set; }
    public DividendYield? DividendYield { get; set; }
    public ExDividendDate? ExDividendDate { get; set; }
    public PayoutRatio? PayoutRatio { get; set; }
    public FiveYearAvgDividendYield? FiveYearAvgDividendYield { get; set; }
    public Beta? Beta { get; set; }
    public TrailingPE? TrailingPE { get; set; }
    public ForwardPE? ForwardPE { get; set; }
    public Volume? Volume { get; set; }
    public RegularMarketVolume? RegularMarketVolume { get; set; }
    public AverageVolume? AverageVolume { get; set; }
    public AverageVolume10days? AverageVolume10days { get; set; }
    public AverageDailyVolume10Day? AverageDailyVolume10Day { get; set; }
    public Bid? Bid { get; set; }
    public Ask? Ask { get; set; }
    public BidSize? BidSize { get; set; }
    public AskSize? AskSize { get; set; }
    public MarketCap? MarketCap { get; set; }
    public Yield? Yield { get; set; }
    public YtdReturn? YtdReturn { get; set; }
    public QtdReturn? GtdReturn { get; set; }
    public TotalAssets? TotalAssets { get; set; }
    public ExpireDate? ExpireDate { get; set; }
    public StrikePrice? StrikePrice { get; set; }
    public OpenInterest? OpenInterest { get; set; }
    public FiftyTwoWeekLow? FiftyTwoWeekLow { get; set; }
    public FiftyTwoWeekHigh? FiftyTwoWeekHigh { get; set; }
    public PriceToSalesTrailing12Months? PriceToSalesTrailing12Months { get; set; }
    public FiftyDayAverage? FiftyDayAverage { get; set; }
    public TwoHundredDayAverage? TwoHundredDayAverage { get; set; }
    public TrailingAnnualDividendRate? TrailingAnnualDividendRate { get; set; }
    public TrailingAnnualDividendYield? TrailingAnnualDividendYield { get; set; }
    public NavPrice? NavPrice { get; set; }
    public string? Currency { get; set; }
    public object? FromCurrency { get; set; }
    public object? ToCurrency { get; set; }
    public object? LastMarket { get; set; }
    public object? CoinMarketCapLink { get; set; }
    public Volume24Hr? Volume24Hr { get; set; }
    public VolumeAllCurrencies? VolumeAllCurrencies { get; set; }
    public CirculatingSupply? CirculatingSupply { get; set; }
    public object? Algorithm { get; set; }
    public MaxSupply? MaxSupply { get; set; }
    public StartDate? StartDate { get; set; }
    public bool Tradeable { get; set; }
}

public class TenYearTotalReturn
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class ThreeMonthReturn
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class ThreeYearTotalReturn
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class TotalAssets
{
}

public class TotalPay
{
    public int Raw { get; set; }
    public string? Fmt { get; set; }
    public string? LongFmt { get; set; }
}

public class TrailingAnnualDividendRate
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class TrailingAnnualDividendYield
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class TrailingPE
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class TwoHundredDayAverage
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class TwoYearTotalReturn
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}

public class UnexercisedValue
{
    public int Raw { get; set; }
    public object? Fmt { get; set; }
    public string? LongFmt { get; set; }
}

public class Volume
{
    public int Raw { get; set; }
    public string? Fmt { get; set; }
    public string? LongFmt { get; set; }
}

public class Volume24Hr
{
}

public class VolumeAllCurrencies
{
}

public class Yield
{
}

public class YtdReturn
{
}

public class YtdReturnPct
{
    public double Raw { get; set; }
    public string? Fmt { get; set; }
}


