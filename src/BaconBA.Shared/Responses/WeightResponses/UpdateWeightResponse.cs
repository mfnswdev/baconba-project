namespace BaconBA.Shared.Responses;

public record UpdateWeightResponse
{
    public string Eartag { get; set; } = default!;
    public double WeightValue { get; set; } = default!;
    public DateTime Date { get; set; }
}
