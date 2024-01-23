using System.Data.Common;
using DisasterResponse.Domain;
using DisasterResponse.Domain.Repositories;
using MediatR;

namespace DisasterResponse.Application.Donors.Command.Update;

public class UpdateDonorHandler : IRequestHandler<UpdateDonorCommand, Guid>
{
    private readonly IRepository _repository;
    public UpdateDonorHandler(IRepository repository) => _repository = repository;

    public async Task<Guid> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
    {
        var donor = await _repository.GetById<Donor, Guid>(request.Id);
        donor.Update(request.Name);
        await _repository.SaveChangesAsync(cancellationToken);
        return donor.Id;
    }
}