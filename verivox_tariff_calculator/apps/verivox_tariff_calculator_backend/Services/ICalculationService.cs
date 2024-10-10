using verivox_tariff_calculator_backend.Models;

namespace verivox_tariff_calculator_backend.Services;

public interface ICalculationService
{
  IEnumerable<TariffInformation> CalculateTariffs(long annualCost);
}
