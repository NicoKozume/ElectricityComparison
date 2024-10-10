using verivox_tariff_calculator_backend.Common.CalculationStrategy;

namespace verivox_tariff_calculator_backend.Models;

public class Tariff
{
  public string Name { get; set; }
  public ICalculationStrategy CalculationStrategy { get; set; }

  public Tariff(string name, ICalculationStrategy calculationStrategy)
  {
    Name = name;
    CalculationStrategy = calculationStrategy;
  }

  public decimal GetAnnualCost(long consumption)
  {
    return CalculationStrategy.CalculateAnnualCost(consumption);
  }
}
