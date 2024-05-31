using MediatR;
using OperationResult;

namespace BaconBA.Shared;

public class DeleteAnimalRequest : IRequest<Result<DeleteAnimalResponse>>
{
    public string Eartag { get; set; } = default!;
}
