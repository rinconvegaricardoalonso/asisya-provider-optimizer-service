namespace ProviderOptimizerService.Application.DTOs;

public class OptimizeProviderResult
{
    public int ProviderId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public double DistanceKm { get; set; }
    public int EtaMinutes { get; set; }
    public bool IsAvailable { get; set; }
}
