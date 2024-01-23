using DisasterResponse.Domain;
using DisasterResponse.Domain.Repositories;
using MediatR;

namespace DisasterResponse.Application.Donors.Queries.GetAll;

public class GetAllDonorsHandler : IRequestHandler<GetAllDonorsQuery, GetAllDonorsDto>
{
    private readonly IRepository _repository;
    public GetAllDonorsHandler(IRepository repository) => _repository = repository;

    public async Task<GetAllDonorsDto> Handle(GetAllDonorsQuery request, CancellationToken cancellationToken)
    {
        var donors = await _repository.QueryPagination<Donor>(request.PageIndex, request.PageSize);
        return new GetAllDonorsDto(
            donors.Count,
            donors.Entities.Select(e => new GetAllDonorsDto.DonorDto(id: e.Id, name: e.Name)).ToList());
    }
}