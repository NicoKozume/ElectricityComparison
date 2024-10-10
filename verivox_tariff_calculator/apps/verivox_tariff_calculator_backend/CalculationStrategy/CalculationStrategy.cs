using Newtonsoft.Json.Linq;
using verivox_tariff_calculator_backend.Models;

namespace verivox_tariff_calculator_backend.CalculationStrategy;

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
