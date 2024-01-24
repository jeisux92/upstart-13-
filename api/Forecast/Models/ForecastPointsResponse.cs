using System.Text.Json.Serialization;

namespace Forecast.Models;

public partial class ForecastPointsResponse
{
    public required Uri Id { get; set; }
    public required string Type { get; set; }
    public required ForecastPointsResponseProperties Properties { get; set; }
}



public partial class CountyClass
{
    public required string Type { get; set; }
}

public partial class Distance
{
    public required string Id { get; set; }
    public required string Type { get; set; }
}

public partial class Value
{
    public required string Id { get; set; }
}



public partial class ForecastPointsResponseProperties
{
    [JsonPropertyName("@id")]
    public required Uri Id { get; set; }
    [JsonPropertyName("@type")]
    public required string Type { get; set; }
    public required string Cwa { get; set; }
    public required Uri ForecastOffice { get; set; }
    public required string GridId { get; set; }
    public long GridX { get; set; }
    public long GridY { get; set; }
    public required Uri Forecast { get; set; }
    public required Uri ForecastHourly { get; set; }
    public required Uri ForecastGridData { get; set; }
    public required Uri ObservationStations { get; set; }
    public required RelativeLocation RelativeLocation { get; set; }
    public required Uri ForecastZone { get; set; }
    public required Uri County { get; set; }
    public required Uri FireWeatherZone { get; set; }
    public required string TimeZone { get; set; }
    public required string RadarStation { get; set; }
}

public partial class RelativeLocation
{
    public required string Type { get; set; }
    public required RelativeLocationProperties Properties { get; set; }
}

public partial class RelativeLocationProperties
{
    public required string City { get; set; }
    public required string State { get; set; }
    public required DistanceClass Distance { get; set; }
    public required DistanceClass Bearing { get; set; }
}

public partial class DistanceClass
{
    public required string UnitCode { get; set; }
    public double Value { get; set; }
}



