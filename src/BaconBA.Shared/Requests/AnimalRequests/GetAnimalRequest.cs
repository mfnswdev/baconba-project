using BaconBA.Shared.Responses;
using MediatR;
using OperationResult;

namespace BaconBA.Shared.Requests;

public class GetAnimalRequest : IRequest<Result<GetAnimalResponse>>
{
    public string Eartag { get; set; } = default!;
}
