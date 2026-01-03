namespace ProviderOptimizerService.Domain.Entities;

public class Provider
{
    public int Id { get; }
    public string Name { get; }
    public string Address { get; }
    public double Latitude { get; }
    public double Longitude { get; }
    public bool IsAvailable { get; }
    public string VehicleType { get; }
    public double Rating { get; }

    public Provider(
        int id,
        string name,
        string address,
        double latitude,
        double longitude,
        bool isAvailable,
        string vehicleType,
        double rating)
    {
        Id = id;
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
        IsAvailable = isAvailable;
        VehicleType = vehicleType;
        Rating = rating;
    }
}
