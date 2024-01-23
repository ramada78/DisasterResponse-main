using MediatR;

namespace DisasterResponse.Application.Request.Queries.GetAll;

public class GetAllAidRequestsQuery : IRequest<GetAllAidRequestsDto>
{
    public GetAllAidRequestsQuery(int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
    }

    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}