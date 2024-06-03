using BaconBA.Shared.Responses;
using MediatR;
using OperationResult;

namespace BaconBA.Shared.Requests;

public class UpdateAnimalRequest : IRequest<Result<UpdateAnimalResponse>>
{
    public string EartagInitial { get; set; } = default!;
    public string Eartag { get; set; } = default!;

    public string GenitorEartag { get; set; } = default!;

    public string MatriarchEartag { get; set; } = default!;

    public DateTime BirthDate { get; set; } = default!;

    public DateTime CheckoutDate { get; set; } = default!;

    public string Status { get; set; } = default!;

    public string Gender { get; set; } = default!;

}
