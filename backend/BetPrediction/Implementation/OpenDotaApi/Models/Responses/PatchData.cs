using System.Text.Json.Serialization;

namespace Implementation.OpenDotaApi.Models.Responses;

public record PatchData
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }
    
    [JsonPropertyName("id")]
    public int OpenDotaId { get; set; }
}