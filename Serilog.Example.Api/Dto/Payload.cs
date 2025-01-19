

using Destructurama.Attributed;

namespace Serilog.Example.Api.Dto;

public class Payload
{
    [NotLogged]
    public string FirstName { get; set; }
    [NotLogged]
    public string LastName { get; set; }
    [NotLogged]
    public string Email { get; set; }   
    public string PersonId { get; set; }   
}