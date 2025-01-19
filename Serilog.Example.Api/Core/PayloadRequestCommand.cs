using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Serilog.Example.Api.Dto;
using Serilog.Example.Api.Results;

namespace Serilog.Example.Api.Core;

public record PayloadRequestCommand(PayloadRequest PayloadRequest): IRequest<Result<PayloadResponse>>;

public class PayloadRequestCommandHandler : IRequestHandler<PayloadRequestCommand, Result<PayloadResponse>>
{
    public async Task<Result<PayloadResponse>> Handle(PayloadRequestCommand request, CancellationToken cancellationToken)
    {
        var result = Result.Success(new PayloadResponse()
        {
            Status = "Success",
            Payload = request.PayloadRequest.Payload,
        });
        
        return await Task.FromResult(result);
    }
}

