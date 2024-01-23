using MediatR;

namespace DisasterResponse.Application.AffectedIndividuals.Commands.Update;

public class UpdateIndividualsAffectedCommand : IRequest<Guid>
{
    public UpdateIndividualsAffectedCommand(Guid id, string name, DateOnly birthDate)
    {
        Id = id;
        Name = name;
        BirthDate = birthDate;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateOnly BirthDate { get; set; }
}