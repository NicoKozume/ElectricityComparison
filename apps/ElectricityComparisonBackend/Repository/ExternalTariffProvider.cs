using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using ElectricityComparisonBackend.Models;

namespace ElectricityComparisonBackend.Repository;

public class ExternalTariffProvider : IExternalTariffProvider
{

  string _json = @"[
            {""name"": ""Product A"", ""type"": 1, ""baseCost"": 5, ""additionalKwhCost"": 22},
            {""name"": ""Product B"", ""type"": 2, ""includedKwh"": 4000, ""baseCost"": 800, ""additionalKwhCost"": 30}
        ]";

  public async Task<IEnumerable<TariffProduct>?> GetAllTariffs(CancellationToken token)
  {
    var jsonStream = GenerateStreamFromString(_json);
    return await JsonSerializer.DeserializeAsync<IEnumerable<TariffProduct>>(jsonStream, cancellationToken: token);
  }

  private static MemoryStream GenerateStreamFromString(string value)
  {
    return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
  }
}
