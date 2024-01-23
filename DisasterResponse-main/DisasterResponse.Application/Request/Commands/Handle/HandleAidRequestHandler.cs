using DisasterResponse.Domain;
using DisasterResponse.Domain.Repositories;
using MediatR;

namespace DisasterResponse.Application.Request.Commands.Handle;

public class HandleAidRequestHandler : IRequestHandler<HandleAidRequestCommand, Guid>
{
    private readonly IRepository _repository;

    public HandleAidRequestHandler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(HandleAidRequestCommand request, CancellationToken cancellationToken)
    {
        var aidRequest = await _repository.GetById<AidRequest, Guid>(request.Id);
        aidRequest.Handle(request.AidId, request.Amount);
        _repository.Update(aidRequest);
        await _repository.SaveChangesAsync(cancellationToken);
        return aidRequest.Id;
    }
}