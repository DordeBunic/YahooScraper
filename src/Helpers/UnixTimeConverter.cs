namespace YahooScraper.Helpers;

public static class UnixTimeConverter
{
    public static long ToUnixTime(this DateTime dateTime)
    {
        TimeSpan timeSpan = dateTime.Date - DateTime.UnixEpoch;
        
        return Convert.ToInt64(timeSpan.TotalSeconds);
    }
}