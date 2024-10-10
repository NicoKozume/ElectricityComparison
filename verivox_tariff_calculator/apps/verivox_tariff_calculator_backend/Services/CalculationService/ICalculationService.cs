using verivox_tariff_calculator_backend.Models;

namespace verivox_tariff_calculator_backend.Services;

public interface ICalculationService
{
  Task<IEnumerable<TariffInformation>> CalculateTariffs(long consumption, CancellationToken token);
}
