using MediatR;

namespace DisasterResponse.Application.Donors.Queries.GetById;

public class GetDonorByIdQuery : IRequest<GetDonorByIdDto>
{
    public GetDonorByIdQuery()
    {
        
    }
    public GetDonorByIdQuery(Guid id) => Id = id;

    public Guid Id { get; set; }
}