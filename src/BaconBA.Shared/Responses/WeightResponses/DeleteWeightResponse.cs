namespace BaconBA.Shared.Responses;

public record DeleteWeightResponse
{
    public string Eartag { get; set; } = default!;
    public DateTime Date { get; set; }
    public double WeightValue { get; set; }
}
