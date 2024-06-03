using BaconBA.Shared.Responses;
using MediatR;
using OperationResult;

namespace BaconBA.Shared.Requests;

public class DeleteAnimalRequest : IRequest<Result<DeleteAnimalResponse>>
{
    public string Eartag { get; set; } = default!;
}
