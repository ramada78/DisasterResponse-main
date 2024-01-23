using DisasterResponse.Domain;
using MediatR;

namespace DisasterResponse.Application.Donors.Command.AddAid;

public class AddAidCommand : IRequest<Guid>
{
    public Guid DonorId { get; set; }
    public Guid AidId { get; set; }
    public string Description { get; set; }
    public int Amount { get; set; }
    public AidType AidType { get; set; }
}