using BaconBA.Shared;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace BaconBA.Domain;

public class UpdateAnimalRequestHandler : IRequestHandler<UpdateAnimalRequest, Result<UpdateAnimalResponse>>
{
    private readonly IAnimalRepository _animalRepository;
    private readonly ILogger<UpdateAnimalRequestHandler> _logger;

    public UpdateAnimalRequestHandler(IAnimalRepository animalRepository, ILogger<UpdateAnimalRequestHandler> logger)
    {
        _animalRepository = animalRepository;
        _logger = logger;
    }
    public async Task<Result<UpdateAnimalResponse>> Handle(UpdateAnimalRequest request, CancellationToken cancellationToken)
    {
        var response = await _animalRepository.GetAnimalAsync(request.EartagInitial);
        if (response == null)
        {
            return Result.Error<UpdateAnimalResponse>(new Exception("Animal not found"));
        }
        else
        {
            response.Update(request.BirthDate,
                            request.CheckoutDate,
                            request.Eartag,
                            request.GenitorEartag,
                            request.MatriarchEartag,
                            request.Status,
                            request.Gender);
            await _animalRepository.UpdateAnimalAsync(response);
            return Result.Success<UpdateAnimalResponse>(new UpdateAnimalResponse
            {
                Eartag = response.Eartag,
                BirthDate = response.BirthDate,
                Status = response.Status,
                Gender = response.Gender
            });
        }
    }
}
// 
