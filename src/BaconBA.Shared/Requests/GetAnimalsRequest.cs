using MediatR;
using OperationResult;

namespace BaconBA.Shared;

public class GetAnimalsRequest : IRequest<Result<GetAnimalsResponse>> { };
