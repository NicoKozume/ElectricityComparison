using ElectricityComparisonBackend.Models;

namespace ElectricityComparisonBackend.Repository;

public interface IExternalTariffProvider
{
  Task<IEnumerable<TariffProduct>?> GetAllTariffs(CancellationToken token);
}
