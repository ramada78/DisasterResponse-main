namespace DisasterResponse.Application.Donors.Queries.GetAll;

public class GetAllDonorsDto
{
    public GetAllDonorsDto()
    {
        
    }
    public GetAllDonorsDto(int count, List<DonorDto> donors)
    {
        Count = count;
        Donors = donors;
    }
    
    public int Count { get; set; }
    public List<DonorDto> Donors { get; set; }
    public class DonorDto
    {
        public DonorDto()
        {
        }

        public DonorDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}