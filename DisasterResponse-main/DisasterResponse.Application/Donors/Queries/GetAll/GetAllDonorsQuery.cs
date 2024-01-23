using MediatR;

namespace DisasterResponse.Application.Donors.Queries.GetAll;

public class GetAllDonorsQuery : IRequest<GetAllDonorsDto>
{
    public GetAllDonorsQuery()
    {
    }
    
    public GetAllDonorsQuery(int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
    }

    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}