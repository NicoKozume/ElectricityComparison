using ElectricityComparisonBackend.Common.CalculationStrategy;
using ElectricityComparisonBackend.Models;
using CalculationStrategy_ICalculationStrategy = ElectricityComparisonBackend.Common.CalculationStrategy.ICalculationStrategy;
using ICalculationStrategy = ElectricityComparisonBackend.Common.CalculationStrategy.ICalculationStrategy;

namespace ElectricityComparisonBackend.Common.TariffParser;

public class TariffParser
{
  private readonly CalculationStrategyFactory _strategyFactory;

  public TariffParser(CalculationStrategyFactory strategyFactory)
  {
    _strategyFactory = strategyFactory;
  }

  public List<Tariff> ParseTariffs(IEnumerable<TariffProduct> products)
  {
    var tariffs = new List<Tariff>();

    foreach (var product in products)
    {
      string name = product.Name;
      int type = product.Type;

      CalculationStrategy_ICalculationStrategy strategy = _strategyFactory.GetStrategy(type, product);

      if (strategy != null)
      {
        tariffs.Add(new Tariff(name, strategy));
      }
    }

    return tariffs;
  }
}
