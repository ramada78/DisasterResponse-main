using MediatR;

namespace DisasterResponse.Application.Donors.Command.Add;

public class AddDonorCommand : IRequest<Guid>
{
    public AddDonorCommand()
    {
    }
    
    public AddDonorCommand(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}