using DisasterResponse.Domain.Entities;
using DisasterResponse.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisasterResponse.Application.AffectedIndividuals.Queries.GetById;

public class
    GetIndividualAffectedByIdHandler : IRequestHandler<GetIndividualAffectedByIdQuery, GetIndividualAffectedByIdDto>
{
    private readonly IRepository _repository;
    public GetIndividualAffectedByIdHandler(IRepository repository) => _repository = repository;

    public async Task<GetIndividualAffectedByIdDto> Handle(GetIndividualAffectedByIdQuery request,
        CancellationToken cancellationToken)
        => await _repository
            .Query<IndividualAffected>()
            .Where(i => i.Id == request.Id)
            .Select(i => new GetIndividualAffectedByIdDto(i.Id, i.Name, i.BirthDate))
            .FirstAsync(cancellationToken);
}