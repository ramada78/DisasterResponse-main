using DisasterResponse.Domain.Core;

namespace DisasterResponse.Domain;

public class Aid : Entity<Guid>
{
    private Aid()
    {
        
    }
    public Aid(string description, AidType aidType, int amount)
    {
        Description = description;
        AidType = aidType;
        Amount = amount;
    }
    
    public string Description { get; private set; }
    public AidType AidType { get; private set; }
    public int Amount { get; private set; }
    
    public Guid DonorId { get; private set; }
    public Donor Donor { get; private set; }

    private readonly List<IncomeAid> _incomeAids = new();
    public IReadOnlyCollection<IncomeAid> IncomeAids => _incomeAids.AsReadOnly();
    
    
    private readonly List<AidRequest> _aidRequests = new();
    public IReadOnlyCollection<AidRequest> AidRequests => _aidRequests.AsReadOnly();
    
    public void Income(Guid donorId, int amount)
    {
        Amount += amount;
        var inc = new IncomeAid(donorId, amount);
        _incomeAids.Add(inc);
    }
}