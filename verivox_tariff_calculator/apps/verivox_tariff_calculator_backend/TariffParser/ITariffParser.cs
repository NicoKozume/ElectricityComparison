using verivox_tariff_calculator_backend.Models;

namespace verivox_tariff_calculator_backend.TariffParser;

public interface ITariffParser
{
  List<Tariff> ParseTariffs(string json);
}
