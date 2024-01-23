namespace DisasterResponse.Application.Donors.Queries.GetById;

public class GetDonorByIdDto
{
    public GetDonorByIdDto(string name, Guid id)
    {
        Name = name;
        Id = id;
    }

    public GetDonorByIdDto()
    {
        
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
}