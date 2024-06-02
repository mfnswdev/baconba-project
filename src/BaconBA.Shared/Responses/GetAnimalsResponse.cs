namespace BaconBA.Shared;

public record GetAnimalsResponse
{
    public ICollection<GetAnimalResponse> Animals { get; set; } = default!;
}