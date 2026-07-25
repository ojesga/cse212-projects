using System.Collections.Generic;
using System.Text.Json.Serialization;

/// <summary>
/// Root object for the USGS GeoJSON earthquake feed.
/// </summary>
public class FeatureCollection
{
    [JsonPropertyName("features")]
    public List<Feature> Features { get; set; } = new();
}

/// <summary>
/// Represents an individual earthquake feature item.
/// </summary>
public class Feature
{
    [JsonPropertyName("properties")]
    public FeatureProperties Properties { get; set; } = new();
}

/// <summary>
/// Represents the properties of an earthquake (place name, magnitude, etc.).
/// </summary>
public class FeatureProperties
{
    [JsonPropertyName("place")]
    public string Place { get; set; } = string.Empty;

    [JsonPropertyName("mag")]
    public double? Mag { get; set; }
}