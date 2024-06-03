using BaconBA.Shared.Responses;
using MediatR;
using OperationResult;

namespace BaconBA.Shared.Requests;

public class DeleteWeightRequest : IRequest<Result<DeleteWeightResponse>>
{
    public int Id { get; set; }
}
