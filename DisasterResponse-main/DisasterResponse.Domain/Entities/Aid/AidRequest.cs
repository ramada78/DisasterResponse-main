using DisasterResponse.Domain.Core;
using DisasterResponse.Domain.Entities;

namespace DisasterResponse.Domain;

public class AidRequest : Entity<Guid>
{
    private AidRequest()
    {
    }

    public AidRequest(Guid individualAffectedId)
    {
        IndividualAffectedId = individualAffectedId;
        Id = Guid.NewGuid();
    }

    public int Amount { get; private set; }
    public int AmountProvided { get; private set; }

    public Guid? AidId { get; private set; }
    public Aid? Aid { get; private set; }

    public Guid IndividualAffectedId { get; private set; }
    public IndividualAffected IndividualAffected { get; private set; }
    
    public int Points => IndividualAffected.DamageCases.Sum(d => (int)d);

    internal void Expense(int amount)
    {
        AmountProvided += amount;
    }


    public void Handle(Guid aidId, int amount)
    {
        AidId = aidId;
        AmountProvided = amount;
    }
}