namespace BaconBA.Shared;

public record UpdateAnimalResponse
{
    public string Eartag { get; init; } = default!;

    public DateTime BirthDate { get; init; } 

    public string Status { get; init; } = default!;

    public string Gender { get; init; } = default!;
}
