using DisasterResponse.Domain.Entities;
using DisasterResponse.Domain.Repositories;
using MediatR;

namespace DisasterResponse.Application.AffectedIndividuals.Commands.Update;

public class UpdateIndividualsAffectedHandler : IRequestHandler<UpdateIndividualsAffectedCommand, Guid>
{
    private readonly IRepository _repository;
    public UpdateIndividualsAffectedHandler(IRepository repository) => _repository = repository;

    public async Task<Guid> Handle(UpdateIndividualsAffectedCommand request, CancellationToken cancellationToken)
    {
        var affected = await _repository.GetById<IndividualAffected, Guid>(request.Id);
        affected.Modify(request.Name, request.BirthDate);
        _repository.Update(affected);
        await _repository.SaveChangesAsync(cancellationToken);
        return affected.Id;
    }
}