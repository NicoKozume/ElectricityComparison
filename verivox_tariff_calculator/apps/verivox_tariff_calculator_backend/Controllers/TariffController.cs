using Microsoft.AspNetCore.Mvc;
using verivox_tariff_calculator_backend.Models;
using verivox_tariff_calculator_backend.Services;

namespace verivox_tariff_calculator_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class TariffController : ControllerBase
{
    private readonly ILogger<TariffController> _logger;
    private readonly ICalculationService _calculationService;

    public TariffController(ILogger<TariffController> logger, ICalculationService calculationService)
    {
      _logger = logger;
      _calculationService = calculationService;
    }

    [HttpGet(Name = "GetTariffs")]
    public async Task<IEnumerable<TariffInformation>> Get(long consumption, CancellationToken token)
    {
      _logger.LogInformation("Retrieved request for GetTariffs");

      try
      {
        return await _calculationService.CalculateTariffs(consumption, token);
      }
      catch (Exception ex)
      {
        _logger.LogError($"Something went wrong while calculating tariffs {ex.Message}");
        throw;
      }
    }

}
