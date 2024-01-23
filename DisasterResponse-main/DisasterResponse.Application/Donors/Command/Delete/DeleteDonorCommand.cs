using MediatR;

namespace DisasterResponse.Application.Donors.Command.Delete;

public class DeleteDonorCommand : IRequest
{
    public DeleteDonorCommand()
    {
        
    }
    public DeleteDonorCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}