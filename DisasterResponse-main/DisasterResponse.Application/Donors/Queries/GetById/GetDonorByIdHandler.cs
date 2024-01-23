using DisasterResponse.Domain;
using DisasterResponse.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisasterResponse.Application.Donors.Queries.GetById;

public class GetDonorByIdHandler : IRequestHandler<GetDonorByIdQuery, GetDonorByIdDto>
{
    private readonly IRepository _repository;
    public GetDonorByIdHandler(IRepository repository) => _repository = repository;

    public async Task<GetDonorByIdDto> Handle(GetDonorByIdQuery request, CancellationToken cancellationToken)
        => await _repository.Query<Donor>()
            .Where(d => d.Id == request.Id)
            .Select(d => new GetDonorByIdDto(d.Name, d.Id))
            .FirstAsync(cancellationToken: cancellationToken);
}