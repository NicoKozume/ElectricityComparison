using verivox_tariff_calculator_backend.Common.CalculationStrategy;
using verivox_tariff_calculator_backend.Common.TariffParser;
using verivox_tariff_calculator_backend.Models;
using verivox_tariff_calculator_backend.Models.Tariffs;
using verivox_tariff_calculator_backend.Repository;

namespace verivox_tariff_calculator_backend.Services;

public class CalculationService : ICalculationService
{
  private readonly IExternalTariffProvider _extTariffProvider;

  public CalculationService(IExternalTariffProvider extTariffProvider)
  {
    _extTariffProvider = extTariffProvider;
  }

  public async Task<IEnumerable<TariffInformation>> CalculateTariffs(long consumption, CancellationToken token)
  {
    var calcStrategy = RegisterTariffs();
    var allTariffs = await _extTariffProvider.GetAllTariffs(token);

    if (allTariffs == null || !allTariffs.Any())
    {
      return new List<TariffInformation>();
    }

    var tariffParser = new TariffParser(calcStrategy);

    var tariffs = tariffParser.ParseTariffs(allTariffs);

    return tariffs.Select(tariff => new TariffInformation()
      {
        Name = tariff.Name,
        Costs = tariff.GetAnnualCost(consumption)
      }).ToList();
  }

  private CalculationStrategyFactory RegisterTariffs()
  {
    var strategyFactory = new CalculationStrategyFactory();

    // Register basic tariff (type 1)
    strategyFactory.RegisterStrategy(1, (product) =>
    {
      decimal baseCost = product.BaseCost;
      decimal additionalKwhCost = product.AdditionalKwhCost;
      return new BasicTariff(baseCost, additionalKwhCost);
    });

    // Register packaged tariff (type 2)
    strategyFactory.RegisterStrategy(2, (product) =>
    {
      long includedKwh = product.IncludedKwh ?? 0;
      decimal baseCost = product.BaseCost;
      decimal additionalKwhCost = product.AdditionalKwhCost;
      return new PackagedTariff(includedKwh, baseCost, additionalKwhCost);
    });

    //Add here more tariffs if needed
    return strategyFactory;
  }
}
