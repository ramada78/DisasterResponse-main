using MediatR;

namespace DisasterResponse.Application.AffectedIndividuals.Queries.GetById;

public class GetIndividualAffectedByIdQuery : IRequest<GetIndividualAffectedByIdDto>
{
    public GetIndividualAffectedByIdQuery()
    {
    }
    
    public GetIndividualAffectedByIdQuery(Guid id) => Id = id;

    public Guid Id { get; set; }
}