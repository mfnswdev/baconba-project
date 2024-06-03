using BaconBA.Shared.Responses;
using MediatR;
using OperationResult;

namespace BaconBA.Shared.Requests;

public class CreateWeightRequest : IRequest<Result<CreateWeightResponse>>
{
    public string Eartag { get; set; } = default!;
    public double WeightValue { get; set; } = default!;
    public DateTime Date { get; set; }

}
