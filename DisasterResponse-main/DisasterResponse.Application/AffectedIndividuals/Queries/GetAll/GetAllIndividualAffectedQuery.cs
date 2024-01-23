using MediatR;

namespace DisasterResponse.Application.AffectedIndividuals.Queries.GetAll;

public class GetAllIndividualAffectedQuery : IRequest<GetAllIndividualAffectedDto>
{
    public GetAllIndividualAffectedQuery()
    {
    }

    public GetAllIndividualAffectedQuery(int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
    }

    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}