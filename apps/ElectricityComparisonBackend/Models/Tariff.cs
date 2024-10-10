using ElectricityComparisonBackend.Common.CalculationStrategy;

namespace ElectricityComparisonBackend.Models;

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
