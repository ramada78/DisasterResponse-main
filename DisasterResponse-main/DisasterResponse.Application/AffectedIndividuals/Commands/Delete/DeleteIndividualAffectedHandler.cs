using DisasterResponse.Domain;
using DisasterResponse.Domain.Entities;
using DisasterResponse.Domain.Repositories;
using MediatR;

namespace DisasterResponse.Application.AffectedIndividuals.Commands.Delete;

public class DeleteIndividualAffectedHandler : IRequestHandler<DeleteIndividualAffectedCommand>
{
    private readonly IRepository _repository;
    public DeleteIndividualAffectedHandler(IRepository repository) => _repository = repository;

    public async Task Handle(DeleteIndividualAffectedCommand request, CancellationToken cancellationToken)
    {
        var affected = await _repository.GetById<IndividualAffected, Guid>(request.Id);
        _repository.Delete(affected);
        await _repository.SaveChangesAsync(cancellationToken);
    }
}