namespace BaconBA.Shared;

public record GetAnimalResponse{
    public string Eartag { get; set; } = default!;
    public DateTime BirthDate { get; set; }
    public string Status { get; set; } = default!;
    public string Gender { get; set; } = default!;
}
