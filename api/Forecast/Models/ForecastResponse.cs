namespace Forecast.Models;


public partial class ForecastResponse
{
    public required string Type { get; set; }
    public required Properties Properties { get; set; }
}


public partial class Properties
{
    public DateTimeOffset Updated { get; set; }
    public required string Units { get; set; }
    public required string ForecastGenerator { get; set; }
    public DateTimeOffset GeneratedAt { get; set; }
    public DateTimeOffset UpdateTime { get; set; }
    public required string ValidTimes { get; set; }
    public required Elevation Elevation { get; set; }
    public required List<Period> Periods { get; set; }
}

public partial class Elevation
{
    public required string UnitCode { get; set; }
    public double? Value { get; set; }
}

public partial class Period
{
    public long Number { get; set; }
    public required string Name { get; set; }
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
    public bool IsDaytime { get; set; }
    public long Temperature { get; set; }
    public required string TemperatureUnit { get; set; }
    public required object TemperatureTrend { get; set; }
    public required Elevation ProbabilityOfPrecipitation { get; set; }
    public required Elevation Dewpoint { get; set; }
    public required Elevation RelativeHumidity { get; set; }
    public required string WindSpeed { get; set; }
    public required string WindDirection { get; set; }
    public required Uri Icon { get; set; }
    public required string ShortForecast { get; set; }
    public required string DetailedForecast { get; set; }
}






