using ElectricityComparisonBackend.Models;

namespace ElectricityComparisonBackend.Common.TariffParser;

public interface ITariffParser
{
  List<Tariff> ParseTariffs(string json);
}
