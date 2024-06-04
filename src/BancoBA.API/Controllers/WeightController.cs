using BaconBA.API.Controllers;
using BaconBA.Shared.Exceptions;
using BaconBA.Shared.Requests;
using BaconBA.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaconBA.API;


[ApiController]
[Route("v1/[controller]")]
public class WeightController : BaseController
{
    private readonly ILogger<WeightController> _logger;
    private readonly IMediator _mediator;

    public WeightController(ILogger<WeightController> logger, IMediator mediator) : base(mediator){
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateWeightResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateWeightResponse>> AddWeightAsync(
        [FromBody] CreateWeightRequest request) => await SendCommand(request);

    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(GetWeightResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetWeightResponse>> GetWeightAsync(
        [FromRoute] GetWeightRequest request) => await SendCommand(request);

    [HttpGet("{Eartag}/All")]
    [ProducesResponseType(typeof(GetWeightsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetWeightsResponse>> GetWeightsAsync(
        [FromRoute] GetWeightsRequest request) => await SendCommand(request);

    [HttpPut]
    [ProducesResponseType(typeof(UpdateWeightResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<UpdateWeightResponse>> UpdateWeightAsync(
        [FromBody] UpdateWeightRequest request) => await SendCommand(request);

    [HttpDelete("{Id}")]
    [ProducesResponseType(typeof(DeleteWeightResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<DeleteWeightResponse>> DeleteWeightAsync(
        [FromRoute] DeleteWeightRequest request) => await SendCommand(request);
    
}
