using DisasterResponse.Domain;
using DisasterResponse.Domain.Repositories;
using MediatR;

namespace DisasterResponse.Application.Request.Queries.GetAll;

public class GetAllAidRequestsHandler : IRequestHandler<GetAllAidRequestsQuery, GetAllAidRequestsDto>
{
    private readonly IRepository _repository;
    public GetAllAidRequestsHandler(IRepository repository) => _repository = repository;

    public async Task<GetAllAidRequestsDto> Handle(GetAllAidRequestsQuery request, CancellationToken cancellationToken)
    {
        var requests = await _repository.QueryPaginationOrderBy<AidRequest>(
            request.PageIndex,
            request.PageSize,
            null,
            a => a.Points);
        
        return new GetAllAidRequestsDto(
            requests.Count,
            requests.Entities.Select(e =>
                new GetAllAidRequestsDto.AidRequestDto(e.Id, e.IndividualAffected.Name, e.Points)).ToList());
    }
}