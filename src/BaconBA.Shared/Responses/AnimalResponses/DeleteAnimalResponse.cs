namespace BaconBA.Shared.Responses;

public record DeleteAnimalResponse
{
    public string Eartag { get; init; } = default!;
}
