using ElectricityComparisonBackend.Models;

namespace ElectricityComparisonBackend.Services;

public interface ICalculationService
{
  Task<IEnumerable<TariffInformation>> CalculateTariffs(long consumption, CancellationToken token);
}
