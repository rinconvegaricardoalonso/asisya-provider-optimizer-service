using Microsoft.AspNetCore.Mvc;
using ProviderOptimizerService.Application.DTOs;
using ProviderOptimizerService.Application.UseCases;
using ProviderOptimizerService.Application.Interfaces;

namespace ProviderOptimizerService.Api.Controllers;

[ApiController]
[Route("providers")]
public class ProvidersController : ControllerBase
{
    private readonly IProviderRepository _repository;
    private readonly OptimizeProviderUseCase _optimizeProviderUseCase;

    public ProvidersController(IProviderRepository repository, OptimizeProviderUseCase useCase)
    {
        _repository = repository;
        _optimizeProviderUseCase = useCase;
    }

    [HttpGet("available")]
    public IActionResult GetAvailable()
    {
        return Ok(_repository.GetAvailable());
    }

    [HttpPost("optimize")]
    public IActionResult Optimize([FromBody] OptimizeProviderRequest request)
    {
        var result = _optimizeProviderUseCase.Execute(
        request.VehicleLatitude,
        request.VehicleLongitude,
        request.VehicleType);

        return Ok(result);
    }
}
