namespace DisasterResponse.Application.AffectedIndividuals.Queries.GetAll;

public class GetAllIndividualAffectedDto
{
    public GetAllIndividualAffectedDto()
    {
        
    }
    
    public GetAllIndividualAffectedDto(int count, List<IndividualAffectedDto> individualsAffected)
    {
        Count = count;
        IndividualsAffected = individualsAffected;
    }
    
    public int Count { get; set; }
    public List<IndividualAffectedDto> IndividualsAffected { get; set; }
    public class IndividualAffectedDto
    {
        public IndividualAffectedDto()
        {
        }

        public IndividualAffectedDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}