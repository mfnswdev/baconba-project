﻿using BaconBA.Shared.Responses;
using MediatR;
using OperationResult;

namespace BaconBA.Shared.Requests;

public class UpdateWeightRequest : IRequest<Result<UpdateWeightResponse>>
{
    public int Id { get; set; }
    public double WeightValue { get; set; } = default!;
    public DateTime Date { get; set; }
}
