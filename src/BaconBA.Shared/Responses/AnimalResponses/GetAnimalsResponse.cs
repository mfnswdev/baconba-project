namespace BaconBA.Shared.Responses;

public record GetAnimalsResponse
{
    public ICollection<GetAnimalResponse> Animals { get; set; } = default!;
}