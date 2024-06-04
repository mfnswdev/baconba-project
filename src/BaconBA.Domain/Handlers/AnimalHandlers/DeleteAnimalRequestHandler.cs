using BaconBA.Shared;
using BaconBA.Shared.Requests;
using BaconBA.Shared.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace BaconBA.Domain.Handlers;

public class DeleteAnimalRequestHandler : IRequestHandler<DeleteAnimalRequest, Result<DeleteAnimalResponse>>
{
    private readonly IAnimalRepository _animalRepository;
    private readonly ILogger<DeleteAnimalRequestHandler> _logger;
    public DeleteAnimalRequestHandler(IAnimalRepository animalRepository, ILogger<DeleteAnimalRequestHandler> logger)
    {
        _animalRepository = animalRepository;
        _logger = logger;
    }
    public async Task<Result<DeleteAnimalResponse>> Handle(DeleteAnimalRequest request, CancellationToken cancellationToken)
    {
        var response = await _animalRepository.GetAnimalAsync(request.Eartag);
        if (response == null)
        {
            return Result.Error<DeleteAnimalResponse>(new Exception("Animal not found"));
        }
        else
        {
            await _animalRepository.DeleteAnimalAsync(response.Eartag);
            return Result.Success<DeleteAnimalResponse>(new DeleteAnimalResponse
            {
                Eartag = response.Eartag
            });
        }
    }
}
