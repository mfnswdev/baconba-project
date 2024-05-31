using BaconBA.Shared.Exceptions;
using MediatR;
using OperationResult;

namespace BaconBA.Shared;

public class CreateAnimalRequest : IRequest<Result<CreateAnimalResponse>>
{
    public string Eartag { get; set; } = default!;
    public string GenitorEartag { get; set; } = default!;
    public string MatriarchEartag { get; set; } = default!;
    public DateTime BirthDate { get; set; }
    public DateTime CheckoutDate { get; set; }
    public string Status { get; set; } = default!;
    public string Gender { get; set; } = default!;
}
