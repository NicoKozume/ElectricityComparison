using verivox_tariff_calculator_backend.Models;

namespace verivox_tariff_calculator_backend.Repository;

public interface IExternalTariffProvider
{
  IEnumerable<TariffProduct>? GetAllTariffs();
}
