using MediatR;
using OperationResult;

namespace BaconBA.Shared;

public class GetAnimalRequest : IRequest<Result<GetAnimalResponse>>
{
    public string Eartag { get; set; } = default!;
}
