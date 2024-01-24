using System.Globalization;
using System.Text.Json.Serialization;

namespace Forecast.Models;

public class GeocodingResponse
{
    public required Result Result { get; set; }
}

public class Result
{
    public required Input Input { get; set; }
    public required List<AddressMatch> AddressMatches { get; set; }
}

public class AddressMatch
{
    public required TigerLine TigerLine { get; set; }
    public required Coordinates Coordinates { get; set; }
    public required AddressComponents AddressComponents { get; set; }
    public required string MatchedAddress { get; set; }
}

public class AddressComponents
{
    public long Zip { get; set; }
    public required string StreetName { get; set; }
    public required string PreType { get; set; }
    public required string City { get; set; }
    public required string PreDirection { get; set; }
    public required string SuffixDirection { get; set; }
    public long FromAddress { get; set; }
    public required string State { get; set; }
    public required string SuffixType { get; set; }
    public long ToAddress { get; set; }
    public required string SuffixQualifier { get; set; }
    public required string PreQualifier { get; set; }
}

public class Coordinates
{
    public double X { get; set; }
    public double Y { get; set; }

    public override string ToString()
    {
        return $"{Y.ToString(CultureInfo.GetCultureInfo("en-US"))},{X.ToString(CultureInfo.GetCultureInfo("en-US"))}";
    }
}

public class TigerLine
{
    public required string Side { get; set; }
    public long TigerLineId { get; set; }
}

public class Input
{
    public required Address Address { get; set; }
    public required Benchmark Benchmark { get; set; }
}

public class Address
{
    [JsonPropertyName("address")]
    public required string AddressAddress { get; set; }
}

public class Benchmark
{
    public bool IsDefault { get; set; }
    public required string BenchmarkDescription { get; set; }
    public long Id { get; set; }
    public required string BenchmarkName { get; set; }
}
