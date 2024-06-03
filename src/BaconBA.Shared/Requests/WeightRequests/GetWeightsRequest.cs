using BaconBA.Shared.Responses;
using MediatR;
using OperationResult;

namespace BaconBA.Shared.Requests;

public class GetWeightsRequest : IRequest<Result<GetWeightsResponse>>
{
    public string Eartag { get; set; } = default!;
}
