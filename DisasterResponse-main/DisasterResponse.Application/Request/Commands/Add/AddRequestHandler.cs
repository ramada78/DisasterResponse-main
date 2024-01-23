using DisasterResponse.Domain;
using DisasterResponse.Domain.Repositories;
using MediatR;

namespace DisasterResponse.Application.Request.Add;

public class AddRequestHandler : IRequestHandler<AddRequestCommand,Guid>
{
    private readonly IRepository _repository;
    public AddRequestHandler(IRepository repository) => _repository = repository;

    public async Task<Guid> Handle(AddRequestCommand request, CancellationToken cancellationToken)
    {
        var aidRequest = new AidRequest(request.IndividualAffectedId);
        _repository.Add(request);
        await _repository.SaveChangesAsync(cancellationToken);
        return aidRequest.Id;
    }
}