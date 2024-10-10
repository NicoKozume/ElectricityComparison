using ElectricityComparisonBackend.Common.CalculationStrategy;

namespace ElectricityComparisonBackend.Models.Tariffs;

public class BasicTariff: ICalculationStrategy
{
  private readonly decimal _baseCost;
  private readonly decimal _additionalKwhCost;

  public BasicTariff(decimal baseCost, decimal additionalKwhCost)
  {
    _baseCost = baseCost;
    _additionalKwhCost = additionalKwhCost;
  }

  public decimal CalculateAnnualCost(long consumption)
  {
    var baseCosts = _baseCost * 12;
    var consumptionCosts = consumption * (_additionalKwhCost / 100); // Convert cent to €
    return baseCosts + consumptionCosts;
  }
}
