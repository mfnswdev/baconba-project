namespace BaconBA.Shared.Responses;

public record GetWeightsResponse
{
    public List<GetWeightResponse> Weights { get; set; } = default!;
}
