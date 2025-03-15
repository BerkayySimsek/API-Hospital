using MongoDB.Bson.Serialization.Attributes;

namespace API_Hospital.Models;

public class Hospital
{
    [BsonId]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
}
