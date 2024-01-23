using MediatR;

namespace DisasterResponse.Application.Request.Add;

public class AddRequestCommand : IRequest<Guid>
{
    public AddRequestCommand(Guid individualAffectedId)
    {
        IndividualAffectedId = individualAffectedId;
    }

    public Guid IndividualAffectedId { get; set; }
}