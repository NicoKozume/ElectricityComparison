using Newtonsoft.Json.Linq;
using verivox_tariff_calculator_backend.CalculationStrategy;
using verivox_tariff_calculator_backend.Models;
using ICalculationStrategy = verivox_tariff_calculator_backend.CalculationStrategy.ICalculationStrategy;

namespace verivox_tariff_calculator_backend.TariffParser;

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

      ICalculationStrategy strategy = _strategyFactory.GetStrategy(type, product);

      if (strategy != null)
      {
        tariffs.Add(new Tariff(name, strategy));
      }
    }

    return tariffs;
  }
}
