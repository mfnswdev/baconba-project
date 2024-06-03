using BaconBA.Shared.Responses;
using MediatR;
using OperationResult;

namespace BaconBA.Shared.Requests;

public class GetAnimalsRequest : IRequest<Result<GetAnimalsResponse>> { };
