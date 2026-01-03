using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProviderOptimizerService.Infrastructure.Persistence.Entities;

[Table("providers")]
public class ProviderEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty;

    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public bool IsAvailable { get; set; }

    [Required]
    public string VehicleType { get; set; } = string.Empty;

    public double Rating { get; set; }
}
