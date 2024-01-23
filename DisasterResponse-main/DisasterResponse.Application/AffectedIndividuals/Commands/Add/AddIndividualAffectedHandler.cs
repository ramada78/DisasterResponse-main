
using DisasterResponse.Domain.Entities;
using DisasterResponse.Domain.Repositories;
using MediatR;

namespace DisasterResponse.Application.AffectedIndividuals.Commands.Add;

public class AddIndividualAffectedHandler : IRequestHandler<AddIndividualAffectedCommand, Guid>
{
    private readonly IRepository _repository;
    public AddIndividualAffectedHandler(IRepository repository) => _repository = repository;

    public async Task<Guid> Handle(AddIndividualAffectedCommand request, CancellationToken cancellationToken)
    {
        var affected = new IndividualAffected(request.Name, request.BirthDate, request.DamageCases);
        _repository.Add(affected);
        await _repository.SaveChangesAsync(cancellationToken);
        return affected.Id;
    }
}