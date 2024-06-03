using BaconBA.Shared.Responses;
using MediatR;
using OperationResult;

namespace BaconBA.Shared.Requests;

public class GetWeightRequest : IRequest<Result<GetWeightResponse>>
{
    public int Id { get; set; }
}
