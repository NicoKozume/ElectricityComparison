using System.Text.Json;
using System.Text.Json.Serialization;
using verivox_tariff_calculator_backend.Models;

namespace verivox_tariff_calculator_backend.Repository;

public class ExternalTariffProvider : IExternalTariffProvider
{

  string json = @"[
            {""name"": ""Product A"", ""type"": 1, ""baseCost"": 5, ""additionalKwhCost"": 22},
            {""name"": ""Product B"", ""type"": 2, ""includedKwh"": 4000, ""baseCost"": 800, ""additionalKwhCost"": 30}
        ]";

  public IEnumerable<TariffProduct>? GetAllTariffs()
  {
    return JsonSerializer.Deserialize<IEnumerable<TariffProduct>>(json);
  }
}
