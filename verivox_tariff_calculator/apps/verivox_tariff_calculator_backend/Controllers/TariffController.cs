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
    public IEnumerable<TariffInformation> Get(long annualCosts)
    {
      return _calculationService.CalculateTariffs(annualCosts);
    }
}
