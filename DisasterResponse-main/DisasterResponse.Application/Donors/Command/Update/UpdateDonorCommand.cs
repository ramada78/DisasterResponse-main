using MediatR;

namespace DisasterResponse.Application.Donors.Command.Update;

public class UpdateDonorCommand : IRequest<Guid>
{
    public UpdateDonorCommand()
    {
    }
    
    public UpdateDonorCommand(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
}