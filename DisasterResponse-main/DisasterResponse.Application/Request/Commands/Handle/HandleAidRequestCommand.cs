using MediatR;

namespace DisasterResponse.Application.Request.Commands.Handle;

public class HandleAidRequestCommand : IRequest<Guid>
{
    public HandleAidRequestCommand(Guid id, Guid aidId, int amount)
    {
        Id = id;
        AidId = aidId;
        Amount = amount;
    }

    public Guid Id { get; set; }
    public Guid AidId { get; set; }
    public int Amount { get; set; }
}