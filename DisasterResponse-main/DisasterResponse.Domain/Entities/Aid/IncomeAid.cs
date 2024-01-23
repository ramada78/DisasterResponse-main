using DisasterResponse.Domain.Core;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DisasterResponse.Domain;

public class IncomeAid : Entity<Guid>
{
    private IncomeAid()
    {
    }
    public IncomeAid(Guid donorId, int amount)
    {
        Id = Guid.NewGuid();
        DonorId = donorId;
        Amount = amount;
    }

    public int Amount { get; private set; }
    public Guid DonorId { get; private set; }
    public Donor Donor { get; private set; }
    public Guid AidId { get; private set; }
    public Aid Aid { get; private set; }  
}