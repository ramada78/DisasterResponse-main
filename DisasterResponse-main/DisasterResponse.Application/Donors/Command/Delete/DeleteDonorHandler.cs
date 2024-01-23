using DisasterResponse.Domain;
using DisasterResponse.Domain.Repositories;
using MediatR;

namespace DisasterResponse.Application.Donors.Command.Delete;

public class DeleteDonorHandler : IRequestHandler<DeleteDonorCommand>
{
    private readonly IRepository _repository;
    public DeleteDonorHandler(IRepository repository) => _repository = repository;

    public async Task Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
    {
        var donor = await _repository.GetById<Donor, Guid>(request.Id);
        _repository.Delete(donor);
        await _repository.SaveChangesAsync(cancellationToken);
    }
}