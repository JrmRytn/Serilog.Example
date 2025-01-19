 

namespace Serilog.Example.Api.Dto;

public class PayloadRequest
{
    public string Client { get; set; }
    public Payload Payload { get; set; }
}

public class PayloadResponse
{
    public string Status { get; set; }
    public Payload Payload  { get; set; }
}