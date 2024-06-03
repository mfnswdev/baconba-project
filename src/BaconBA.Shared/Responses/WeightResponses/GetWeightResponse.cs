namespace BaconBA.Shared.Responses;

public record GetWeightResponse
{
    public int Id { get; set; }
    public double WeightValue { get; set; }
    public DateTime Date { get; set; }
    public string Eartag { get; set; } = default!;
}

