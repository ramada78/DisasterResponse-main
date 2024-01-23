using DisasterResponse.Domain.Entities;
using DisasterResponse.Domain.Repositories;
using MediatR;

namespace DisasterResponse.Application.AffectedIndividuals.Queries.GetAll;

public class GetAllIndividualAffectedHandler : IRequestHandler<GetAllIndividualAffectedQuery,GetAllIndividualAffectedDto>
{
    private readonly IRepository _repository;
    public GetAllIndividualAffectedHandler(IRepository repository) => _repository = repository;

    public async Task<GetAllIndividualAffectedDto> Handle(GetAllIndividualAffectedQuery request, CancellationToken cancellationToken)
    {
        var donors = await _repository.QueryPagination<IndividualAffected>(request.PageIndex, request.PageSize);
        return new GetAllIndividualAffectedDto(
            donors.Count,
            donors.Entities.Select(e => new GetAllIndividualAffectedDto.IndividualAffectedDto(id: e.Id, name: e.Name)).ToList());
    }
}