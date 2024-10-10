using ElectricityComparisonBackend.Common.CalculationStrategy;

namespace ElectricityComparisonBackend.Models.Tariffs;

public class PackagedTariff : ICalculationStrategy
{
  private readonly long _includedKwh;
  private readonly decimal _baseCost;
  private readonly decimal _additionalKwhCost;

  public PackagedTariff(long includedKwh, decimal baseCost, decimal additionalKwhCost)
  {
    _includedKwh = includedKwh;
    _baseCost = baseCost;
    _additionalKwhCost = additionalKwhCost;
  }

  public decimal CalculateAnnualCost(long consumption)
  {
    if (consumption <= _includedKwh)
    {
      return _baseCost;
    }
    var additionalConsumption = consumption - _includedKwh;
    var additionalCosts = additionalConsumption * (_additionalKwhCost / 100); // Convert cent to €
    return _baseCost + additionalCosts;
  }

}
