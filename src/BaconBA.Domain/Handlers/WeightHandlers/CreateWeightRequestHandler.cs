using BaconBA.Shared.Requests;
using BaconBA.Shared.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace BaconBA.Domain;

public class CreateWeightRequestHandler : IRequestHandler<CreateWeightRequest, Result<CreateWeightResponse>>
{
    public readonly IWeightRepository _weightRepository;
    public readonly IAnimalRepository _animalRepository;
    public readonly ILogger<CreateWeightRequestHandler> _logger;
    public CreateWeightRequestHandler(IWeightRepository weightRepository, IAnimalRepository animalRepository, ILogger<CreateWeightRequestHandler> logger)
    {
        _weightRepository = weightRepository;
        _animalRepository = animalRepository;
        _logger = logger;
    }
    public Task<Result<CreateWeightResponse>> Handle(CreateWeightRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
