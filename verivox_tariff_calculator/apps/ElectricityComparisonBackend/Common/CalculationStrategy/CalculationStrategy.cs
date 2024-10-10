using ElectricityComparisonBackend.Models;

namespace ElectricityComparisonBackend.Common.CalculationStrategy;

public interface ICalculationStrategy
{
  decimal CalculateAnnualCost(long consumption);
}

public class CalculationStrategyFactory
{
  private readonly Dictionary<int, Func<TariffProduct, ICalculationStrategy>> _strategies = new();

  public void RegisterStrategy(int type, Func<TariffProduct, ICalculationStrategy> strategyFactory)
  {
    _strategies[type] = strategyFactory;
  }

  public ICalculationStrategy GetStrategy(int type, TariffProduct product)
  {
    if (_strategies.ContainsKey(type))
    {
      return _strategies[type](product);
    }
    throw new InvalidOperationException($"No strategy registered for type {type}");
  }
}
