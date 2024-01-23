using DisasterResponse.Domain.Core;
using Guid = System.Guid;

namespace DisasterResponse.Domain;

public class Donor : Entity<Guid>
{
    private Donor()
    {
    }

    public Donor(string name) : base(Guid.NewGuid())
        => Name = name;

    public string Name { get; private set; }

    private readonly List<IncomeAid> _incomeAids = new();
    public IReadOnlyCollection<IncomeAid> IncomeAids => _incomeAids.AsReadOnly();

    public void Update(string requestName) => Name = requestName;

    public Aid AddAid(string description, int amount, AidType aidType)
    {
        throw new NotImplementedException();
        // var aid = new Aid(description, aidType, amount);
        // _incomeAids.Add(aid);
        // return aid;
    }
}