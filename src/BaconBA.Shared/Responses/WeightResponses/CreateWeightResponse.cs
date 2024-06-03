namespace BaconBA.Shared.Responses;

public class CreateWeightResponse
{
    public string Eartag { get; set; } = default!;
    public double WeightValue { get; set; }
    public DateTime Date { get; set; }
}
