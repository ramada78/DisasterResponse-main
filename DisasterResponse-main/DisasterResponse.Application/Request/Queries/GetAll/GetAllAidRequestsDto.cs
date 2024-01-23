namespace DisasterResponse.Application.Request.Queries.GetAll;

public class GetAllAidRequestsDto
{
    public GetAllAidRequestsDto()
    {
        
    }
    
    public GetAllAidRequestsDto(int count, List<AidRequestDto> requests)
    {
        Count = count;
        Requests = requests;
    }

    public int Count { get; set; }
    public List<AidRequestDto> Requests { get; set; }

    public class AidRequestDto
    {
        public AidRequestDto()
        {
            
        }
        public AidRequestDto(Guid id, string individualAffectedName, int points)
        {
            Id = id;
            IndividualAffectedName = individualAffectedName;
            Points = points;
        }

        public Guid Id { get; set; }
        public string IndividualAffectedName { get; set; }
        public int Points { get; set; }
    }
}