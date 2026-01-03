namespace ProviderOptimizerService.Application.DTOs;

public class OptimizeProviderRequest
{
    public double VehicleLatitude { get; set; }
    public double VehicleLongitude { get; set; }
    public string VehicleType { get; set; } = string.Empty;
}
