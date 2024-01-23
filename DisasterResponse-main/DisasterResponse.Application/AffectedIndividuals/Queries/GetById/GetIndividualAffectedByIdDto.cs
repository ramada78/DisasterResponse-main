namespace DisasterResponse.Application.AffectedIndividuals.Queries.GetById;

public class GetIndividualAffectedByIdDto
{
    public GetIndividualAffectedByIdDto()
    {
        
    }
    
    public GetIndividualAffectedByIdDto(Guid id, string name, DateOnly birthDate)
    {
        Id = id;
        Name = name;
        BirthDate = birthDate;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateOnly BirthDate { get; set; }
}