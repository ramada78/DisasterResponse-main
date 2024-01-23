using DisasterResponse.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace DisasterResponse.Domain.Entities;

public class IndividualAffected : Entity<Guid>
{
    private IndividualAffected()
    {
    }

    public IndividualAffected(string name, DateOnly birthDate, List<DamageCase> damageCases)
    {
        Id = Guid.NewGuid();
        Name = name;
        BirthDate = birthDate;
        DamageCases = damageCases;
    }
    
    [Required]
    public string Name { get; private set; }
    [Required]
    public DateOnly BirthDate { get; private set; }
    public List<DamageCase>? DamageCases { get; private set; }

    public void Modify(string name, DateOnly birthDate) => (Name, BirthDate) = (name, birthDate);
}