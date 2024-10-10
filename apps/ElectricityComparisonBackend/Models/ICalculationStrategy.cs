namespace verivox_tariff_calculator_backend.Models;

public interface ICalculationStrategy
{
  decimal CalculateAnnualCost(int consumption);
}
