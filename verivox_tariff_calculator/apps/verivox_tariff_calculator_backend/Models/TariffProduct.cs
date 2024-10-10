using System.Text.Json.Serialization;

namespace verivox_tariff_calculator_backend.Models;

public class TariffProduct
{
  [JsonPropertyName("name")]
  public string Name { get; set; }

  [JsonPropertyName("type")]
  public int Type { get; set; }

  [JsonPropertyName("includedKwh")]
  public long? IncludedKwh { get; set; }

  [JsonPropertyName("baseCost")]
  public decimal BaseCost { get; set; }

  [JsonPropertyName("additionalKwhCost")]
  public decimal AdditionalKwhCost { get; set; }
}
