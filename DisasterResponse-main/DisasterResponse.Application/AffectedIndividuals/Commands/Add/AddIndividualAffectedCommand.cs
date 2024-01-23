using DisasterResponse.Domain.Entities;
using MediatR;

namespace DisasterResponse.Application.AffectedIndividuals.Commands.Add;

public class AddIndividualAffectedCommand : IRequest<Guid>
{
    public AddIndividualAffectedCommand()
    {
    }
    public AddIndividualAffectedCommand(string name, DateOnly birthDate, List<DamageCase> damageCases)
    {
        Name = name;
        BirthDate = birthDate;
        DamageCases = damageCases;
    }

    public string Name { get; set; }
    public DateOnly BirthDate { get; set; }
    public List<DamageCase> DamageCases { get; set; }
}