using DisasterResponse.Domain;
using DisasterResponse.Domain.Repositories;
using MediatR;

namespace DisasterResponse.Application.Donors.Command.Add;

public class AddDonorHandler : IRequestHandler<AddDonorCommand,Guid>
{
    private readonly IRepository _repository;
    public AddDonorHandler(IRepository repository) => _repository = repository;

    public async Task<Guid> Handle(AddDonorCommand request, CancellationToken cancellationToken)
    {
        var donor = new Donor(request.Name);
        _repository.Add(donor);
        await _repository.SaveChangesAsync(cancellationToken);
        return donor.Id;
    }
}