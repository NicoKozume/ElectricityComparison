using verivox_tariff_calculator_backend.Models;

namespace verivox_tariff_calculator_backend.Repository;

public interface IExternalTariffProvider
{
  Task<IEnumerable<TariffProduct>?> GetAllTariffs(CancellationToken token);
}
